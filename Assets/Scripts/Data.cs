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
    public InGameMenu menu;
    public Dictionary<ItemMenu, string> menuItems;

    private void Awake()
    {
        instance = this;

        menuItems = new Dictionary<ItemMenu, string>();

        menuItems[ItemMenu.Resume] = "ادامه";
        menuItems[ItemMenu.Again] = "مجدد";
        menuItems[ItemMenu.ExitToMainMenu] = "منوی اصلی";
        menuItems[ItemMenu.Exit] = "خروج از برنامه";
    }
}
