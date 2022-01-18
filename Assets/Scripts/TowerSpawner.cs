using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] List<Texture2D> cursorIcons = new List<Texture2D>();
    [SerializeField] List<GameObject> placebleTowers = new List<GameObject>();
    [SerializeField] List<Button> towerButtons = new List<Button>();
    [SerializeField] List<Button> upgradeButtons = new List<Button>();
    [SerializeField] Texture2D defaultCursorIcon;
    [SerializeField] Texture2D cleanCursorIcon;
    bool canPlaceTower = false;
    bool canCleanTower = false;
    int indexBoughtTower;
    Vector2 mousePosition;
    TowerInput towerInput;
    UIController uIController;
    UpgradeTowers upgradeTowers;
    GameObject currentTowerClicked;
    GameManager gameManager;

    void Awake()
    {
        towerInput = new TowerInput();
        uIController = FindObjectOfType<UIController>();
        gameManager = FindObjectOfType<GameManager>();
        upgradeTowers = GetComponent<UpgradeTowers>();

        //Cursor.lockState = CursorLockMode.Confined;
    }

    void Start()
    {
        ChangeCursor(defaultCursorIcon);
        StartTowerValues();
        towerInput.Mouse.MouseClick.performed += _ => MouseClick();
    }

    void StartTowerValues()
    {
        for(int i = 0; i < placebleTowers.Count; i++)
        {
            UpgradeConfigs config = placebleTowers[i].GetComponent<UpgradeConfigs>();
            towerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = config.GetTowerValue().ToString();
        }
    }

    void MouseClick()
    {
        mousePosition = towerInput.Mouse.MousePosition.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (canCleanTower)
        {
            CheckAndDestroyTower(mousePosition);
            canCleanTower = false;
            ChangeCursor(defaultCursorIcon);
        }

        if (canPlaceTower && !CheckIfPositionIsOccupied(mousePosition))
        {
            PlaceTower();
            DisableTowerPlacing();
        }

        if (!canCleanTower && !canPlaceTower)
        {
            GameObject tower = GetClickedTower();
            ChangeUI(tower);
        }
    }

    void ModifyUIButtonState()
    {
        UpgradeConfigs config = currentTowerClicked.GetComponent<UpgradeConfigs>();

        upgradeButtons[0].interactable = config.CheckIfCanUpgradeSpeed();
        upgradeButtons[1].interactable = config.CheckIfCanUpgradeDamage();
        upgradeButtons[2].interactable = config.CheckIfCanUpgradeRange();

        upgradeButtons[0].GetComponentInChildren<TextMeshProUGUI>().text = "Speed\n" + config.GetSpeedCost();
        upgradeButtons[1].GetComponentInChildren<TextMeshProUGUI>().text = "Damage\n" + config.GetDamageCost();
        upgradeButtons[2].GetComponentInChildren<TextMeshProUGUI>().text = "Range\n" + config.GetRangeCost();
    }


    GameObject GetClickedTower()
    {
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.up, 0.5f);

        if (hit.collider != null && hit.collider.tag == "Tower")
        {
            return hit.collider.gameObject;
        }

        return null;
    }

    void ChangeUI(GameObject tower)
    {
        if (tower != null)
        {
            uIController.EnableUpgrading();
            currentTowerClicked = tower;
            ModifyUIButtonState();
            return;
        }
        else if (CheckIfClickedUI())
        {
            return;
        }

        uIController.EnableBuying();
        currentTowerClicked = null;
    }

    bool CheckIfClickedUI()
    {

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return true;
        }

        return false;
    }

    public void UpgradeTowerSpeed()
    {
        UpgradeConfigs config = currentTowerClicked.GetComponent<UpgradeConfigs>();

        if (config != null && gameManager.GetTotalMoney() >= config.GetSpeedCost()) 
        {
            upgradeTowers.UpgradeSpeed(currentTowerClicked);
            ModifyUIButtonState();
            gameManager.DecreaseTotalMoney(config.GetSpeedCost());
        }
    }

    public void UpgradeTowerRange()
    {
        UpgradeConfigs config = currentTowerClicked.GetComponent<UpgradeConfigs>();

        if (config != null && gameManager.GetTotalMoney() >= config.GetRangeCost()) 
        {
            upgradeTowers.UpgradeRange(currentTowerClicked);
            ModifyUIButtonState();
            gameManager.DecreaseTotalMoney(config.GetRangeCost());
        }
    }

    public void UpgradeTowerDamage()
    {
        UpgradeConfigs config = currentTowerClicked.GetComponent<UpgradeConfigs>();

        if (config != null && gameManager.GetTotalMoney() >= config.GetDamageCost()) 
        {
            upgradeTowers.UpgradeDamage(currentTowerClicked);
            ModifyUIButtonState();
            gameManager.DecreaseTotalMoney(config.GetDamageCost());
        }
    }

    void PlaceTower()
    {
        GameObject instance = Instantiate(placebleTowers[indexBoughtTower],
                        mousePosition, Quaternion.identity);

        currentTowerClicked = instance;
    }

    public void ChangeCursor(Texture2D cursor)
    {
        Vector2 hotspot = new Vector2(cursor.width / 2, cursor.height / 2);
        Cursor.SetCursor(cursor, hotspot, CursorMode.Auto);
    }

    public void BuyTower(int index)
    {
        UpgradeConfigs config = placebleTowers[index].GetComponent<UpgradeConfigs>();

        if (config != null && gameManager.GetTotalMoney() >= config.GetTowerValue()) 
        {
            gameManager.DecreaseTotalMoney(config.GetTowerValue());
            ChangeCursor(cursorIcons[index]);
            indexBoughtTower = index;
            canPlaceTower = true;
        }
    }

    public void CleanTower()
    {
        ChangeCursor(cleanCursorIcon);
        canPlaceTower = false;
        canCleanTower = true;
    }

    public void DisableTowerPlacing()
    {
        canPlaceTower = false;
        ChangeCursor(defaultCursorIcon);
    }

    bool CheckIfPositionIsOccupied(Vector2 mousePosition)
    {
        //check if there is something at that position
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.up, 0.5f);

        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }

    void CheckAndDestroyTower(Vector2 mousePosition)
    {
        GameObject tower = GetClickedTower();

        if (tower != null)
        {
            Destroy(tower);
        }
    }

    void OnEnable()
    {
        towerInput.Enable();
    }

    void OnDisable()
    {
        towerInput.Disable();
    }

}
