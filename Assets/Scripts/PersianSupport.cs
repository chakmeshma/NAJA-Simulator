using UnityEngine;

public class PersianSupport : MonoBehaviour
{
    private bool done = false;

    // Use this for initialization
    void Start()
    {
        if (!done)
        {
            GetComponent<UnityEngine.UI.Text>().text = ArabicSupport.ArabicFixer.Fix(GetComponent<UnityEngine.UI.Text>().text);
            done = true;
        }
    }
}
