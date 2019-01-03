using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuItemController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public ItemMenu value;

    public void OnPointerClick(PointerEventData eventData)
    {
        MainMenuInit.instance.menuItemAction(value);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        MainMenu.instance.selected = value;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MainMenu.instance.selected = (ItemMenu)1000;
    }
}
