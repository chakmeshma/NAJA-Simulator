using UnityEngine;
using UnityEngine.EventSystems;

public class MenuItemController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Menu.MenuItem value;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameController.instance.menuItemAction(value);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Menu.instance.selected = value;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Menu.instance.selected = (Menu.MenuItem)1000;
    }
}
