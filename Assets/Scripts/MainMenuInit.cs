using System.Linq;
using UnityEngine;

public class MainMenuInit : MonoBehaviour
{
    public MainSceneLoader sceneLoader;
    private static MainMenuInit _instance;
    public static MainMenuInit instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;

        UnityEngine.Cursor.visible = true;
        UnityEngine.Cursor.lockState = CursorLockMode.None;

        MainMenuData.instance.menu.populate(MainMenuData.instance.menuItems.Keys.ToList());
    }

    public void menuItemAction(ItemMenu item)
    {
        switch (item)
        {
            case ItemMenu.Start:
                sceneLoader.load();
                break;
            case ItemMenu.Credits:
                UnityEngine.Cursor.visible = false;
                UnityEngine.Cursor.lockState = CursorLockMode.Locked;

                UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
                break;
            case ItemMenu.Exit:
                Application.Quit();
                break;
        }

    }
}
