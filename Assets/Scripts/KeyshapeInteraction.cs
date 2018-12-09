using System.Collections;
using UnityEngine;

public abstract class KeyshapeInteraction : Interaction
{
    [SerializeField]
    private float animationSpeed = 1.0f;
    [SerializeField]
    private AnimationCurve animationCurve;
    [SerializeField]
    private AnimationCurve reverseAnimationCurve;
    private bool running = false;
    private SkinnedMeshRenderer meshRenderer;

    void Awake()
    {
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
    }

    public override bool isInputBlocking()
    {
        return false;
    }

    public void execute(bool reverse)
    {
        running = true;

        StopAllCoroutines();
        StartCoroutine(animationKeyshape(reverse));
    }

    public override void execute()
    {
        running = true;

        StopAllCoroutines();
        StartCoroutine(animationKeyshape(false));
    }

    private IEnumerator animationKeyshape(bool reverse)
    {
        if (reverse)
        {
            float progress = 1.0f;

            while (progress > 0.0f)
            {
                progress -= 0.01f * animationSpeed;

                meshRenderer.SetBlendShapeWeight(0, 100.0f * reverseAnimationCurve.Evaluate(Mathf.Clamp(progress, 0.0f, 1.0f)));

                yield return new WaitForSeconds(0.0166f);
            }
        }
        else
        {
            float progress = 0.0f;

            while (progress < 1.0f)
            {
                progress += 0.01f * animationSpeed;

                meshRenderer.SetBlendShapeWeight(0, 100.0f * animationCurve.Evaluate(Mathf.Clamp(progress, 0.0f, 1.0f)));

                yield return new WaitForSeconds(0.0166f);
            }
        }

        running = false;
    }

    public override bool isRunning()
    {
        return running;
    }

    public abstract override string getDescription();
}
