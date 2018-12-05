using System.Collections;
using UnityEngine;

public class DashboardInteraction : MonoBehaviour, IInteraction
{
    public AnimationCurve animationCurve;
    private static string description = "باز کردن داشبورد";
    private bool running = false;
    private SkinnedMeshRenderer meshRenderer;

    void Awake()
    {
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
    }

    public bool isInputBlocking()
    {
        return false;
    }

    public void run()
    {
        running = true;

        StopAllCoroutines();
        StartCoroutine("openDashboard");
    }

    private IEnumerator openDashboard()
    {
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            progress += 0.01f;

            meshRenderer.SetBlendShapeWeight(0, 100.0f * animationCurve.Evaluate(progress));

            yield return new WaitForSeconds(0.0166f);
        }

        running = false;
    }

    public bool isRunning()
    {
        return running;
    }

    public string getDescription()
    {
        return description;
    }
}
