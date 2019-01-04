using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private int initialTime = 60;
    [SerializeField]
    private float time;
    public UnityEngine.UI.Text timerText;
    private bool finished = false;
    public bool freezing = false;
    public float elapsedTime
    {
        get
        {
            return ((float)initialTime) - time;
        }
    }

    public static Timer instance { get { return _instance; } }
    private static Timer _instance;

    private void Awake()
    {
        _instance = this;

        time = initialTime;
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
