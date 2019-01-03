using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float time = 20f;
    public UnityEngine.UI.Text timerText;
    public bool stopped = false;
    private bool finished = false;
    public bool freezing = false;

    public static Timer instance { get { return _instance; } }
    private static Timer _instance;

    private void Awake()
    {
        _instance = this;
    }

    void Update()
    {
        if (!finished && time <= 0.0f)
        {
            timerText.transform.parent.gameObject.SetActive(false);
            GameController.instance.gameOver(false);

            finished = true;
        }

        if (!finished)
        {
            if (!freezing)
            {
                time -= Time.deltaTime;
            }

            int shownTime = Mathf.RoundToInt(time);

            timerText.text = shownTime.ToString();
        }
    }
}
