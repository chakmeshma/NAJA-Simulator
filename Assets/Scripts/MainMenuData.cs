using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuData : MonoBehaviour {
    public static MainMenuData instance = null;

    public MainMenu menu;
    public Dictionary<ItemMenu, string> menuItems;

    private void Awake()
    {
        instance = this;

        menuItems = new Dictionary<ItemMenu, string>();

        menuItems[ItemMenu.Start] = "شروع";
        menuItems[ItemMenu.Help] = "راهنما";
        menuItems[ItemMenu.Pictures] = "آموزش و تصاوير";
        menuItems[ItemMenu.Settings] = "تنظيمات";
        menuItems[ItemMenu.Credits] = "درباره ما";
        menuItems[ItemMenu.Exit] = "خروج";
    }
}
