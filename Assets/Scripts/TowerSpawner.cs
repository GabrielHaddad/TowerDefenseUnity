using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] List<Texture2D> cursorIcons = new List<Texture2D>();
    [SerializeField] List<GameObject> placebleTowers = new List<GameObject>();
    [SerializeField] Texture2D defaultCursorIcon;
    [SerializeField] Transform placebleCanvas;
    bool canPlaceTower = false;
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
        if (canPlaceTower)
        {
            mousePosition = towerInput.Mouse.MousePosition.ReadValue<Vector2>();
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            PlaceTower();
            DisableTowerPlacing();
        }
    }

    void PlaceTower()
    {
        Instantiate(placebleTowers[indexCurrentTower], 
                        mousePosition, Quaternion.identity, placebleCanvas);
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

    public void DisableTowerPlacing()
    {
        canPlaceTower = false;
        ChangeCursor(defaultCursorIcon);
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
