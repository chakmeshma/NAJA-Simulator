using UnityEngine;
using UnityEngine.EventSystems;

public class InGameMenuItemController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public ItemMenu value;


    public void OnPointerClick(PointerEventData eventData)
    {
        GameController.instance.menuItemAction(value);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        InGameMenu.instance.selected = value;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InGameMenu.instance.selected = (ItemMenu)1000;
    }
}
