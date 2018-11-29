using UnityEngine;

public class Cursor : MonoBehaviour
{
    public Sprite unselectedStateCursor;
    public Sprite selectedStateCursor;
    public UnityEngine.UI.Image cursorImage;

    public void select()
    {
        cursorImage.sprite = selectedStateCursor;
    }

    public void unselect()
    {

        cursorImage.sprite = unselectedStateCursor;
    }
}
