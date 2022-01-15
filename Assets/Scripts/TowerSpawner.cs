using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] List<Texture2D> cursorIcons = new List<Texture2D>();
    [SerializeField] List<GameObject> placebleTowers = new List<GameObject>();
    [SerializeField] Texture2D defaultCursorIcon;
    [SerializeField] Texture2D cleanCursorIcon;
    bool canPlaceTower = false;
    bool canCleanTower = true;
    int indexCurrentTower;
    Vector2 mousePosition;
    TowerInput towerInput;

    void Awake()
    {
        towerInput = new TowerInput();

        //Cursor.lockState = CursorLockMode.Confined;
    }

    void Start()
    {
        ChangeCursor(defaultCursorIcon);
        towerInput.Mouse.MouseClick.performed += _ => MouseClick();
    }

    void Update()
    {

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
    }

    void PlaceTower()
    {
        Instantiate(placebleTowers[indexCurrentTower],
                        mousePosition, Quaternion.identity);
    }

    public void ChangeCursor(Texture2D cursor)
    {
        Vector2 hotspot = new Vector2(cursor.width / 2, cursor.height / 2);
        Cursor.SetCursor(cursor, hotspot, CursorMode.Auto);
    }

    public void BuyTower(int index)
    {
        ChangeCursor(cursorIcons[index]);
        indexCurrentTower = index;
        canPlaceTower = true;
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
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.up, 0.5f);

        if (hit.collider != null && hit.collider.tag == "Tower")
        {
            GameObject clickedTower = hit.collider.gameObject;
            Destroy(clickedTower);
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
