using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemMenu
{
    Resume,
    Again,
    Exit,
    ExitToMainMenu,
    Start,
    Help,
    Pictures,
    Settings,
    Credits,
}

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance
    {
        get
        {
            return _instance;
        }
    }
    private static MainMenu _instance;

    public ItemMenu selected
    {
        get
        {
            return _selected;
        }
        set
        {
            _selected = value;
            updateUI();
        }
    }
    public Object itemPrefab;
    public Color selectedColor;
    public Color unselectedColor;
    private RectTransform rectTransform;
    private ItemMenu _selected = (ItemMenu)1000;

    //Populates the menu with the items
    public void populate(List<ItemMenu> menuItems)
    {
        rectTransform = GetComponent<RectTransform>();

        //Clear the menu items before populating with new ones
        foreach (Transform trans in transform)
        {
            Destroy(trans.gameObject);
        }

        float n = menuItems.Count;
        float maxY = 0.5f + ((n / 9f) / 2f);
        float minY = 0.5f - ((n / 9f) / 2f);


        rectTransform.anchorMin = new Vector2(0.333333f, minY);
        rectTransform.anchorMax = new Vector2(0.666666f, maxY);
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;


        //Instanting menu item prefabs, setting their text and adjusting UI geometry
        for (int i = 0; i < menuItems.Count; ++i)
        {
            ItemMenu item = menuItems[i];

            GameObject newItem = Instantiate(itemPrefab) as GameObject;

            newItem.GetComponentInChildren<MainMenuItemController>().value = item;

            newItem.GetComponentInChildren<UnityEngine.UI.Text>().text = ArabicSupport.ArabicFixer.Fix(MainMenuData.instance.menuItems[item]);
            RectTransform newItemRectTransform = newItem.GetComponent<RectTransform>();

            newItemRectTransform.SetParent(rectTransform);

            float normalizedItemHeight = 1.0f / menuItems.Count;

            newItemRectTransform.anchorMax = new Vector2(1f, 1f - (normalizedItemHeight * i));
            newItemRectTransform.anchorMin = new Vector2(0f, 1f - (normalizedItemHeight * (i + 1)));

            float itemPadding = 8f;

            newItemRectTransform.offsetMax = new Vector2(-itemPadding, -itemPadding);
            newItemRectTransform.offsetMin = new Vector2(itemPadding, itemPadding);

            if (i < menuItems.Count - 1)
            {
                newItemRectTransform.offsetMin = new Vector2(itemPadding, itemPadding / 2f);
            }

            if (i > 0)
            {
                newItemRectTransform.offsetMax = new Vector2(-itemPadding, -itemPadding / 2f);
            }
        }

        updateUI();
    }
    private void updateUI()
    {
        int i = 0;

        foreach (MainMenuItemController item in GetComponentsInChildren<MainMenuItemController>())
        {
            if (item.value == selected)
            {
                transform.GetChild(i).GetComponent<Image>().color = selectedColor;
            }
            else
            {
                transform.GetChild(i).GetComponent<Image>().color = unselectedColor;
            }

            i++;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
}
