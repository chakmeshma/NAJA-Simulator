using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {
    public static Data instance = null;
    public Transform player;
    public Transform playerInsideCarFrontLeft;
    public Transform playerInsideCarFrontRight;
    public Transform playerInsideCarBackLeft;
    public Transform playerInsideCarBackRight;
    public Transform playerOutsideCarFrontLeft;
    public Transform playerOutsideCarFrontRight;
    public Transform playerOutsideCarBackLeft;
    public Transform playerOutsideCarBackRight;
    public GameObject outerCar;
    public GameObject innerCar;
    public Cursor cursor;
    public Menu menu;
    public Dictionary<Menu.MenuItem, string> inGameMenuItems;

    private void Awake()
    {
        instance = this;

        inGameMenuItems = new Dictionary<Menu.MenuItem, string>();

        inGameMenuItems[Menu.MenuItem.Resume] = "ادامه";
        inGameMenuItems[Menu.MenuItem.Again] = "مجدد";
        inGameMenuItems[Menu.MenuItem.Exit] = "خروج از برنامه";
    }
}
