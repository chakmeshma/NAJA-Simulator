using UnityEngine;

public class TextFixer : MonoBehaviour
{
    public string text;

    void Awake()
    {
        GetComponent<UnityEngine.UI.Text>().text = ArabicSupport.ArabicFixer.Fix(text);
    }
}
