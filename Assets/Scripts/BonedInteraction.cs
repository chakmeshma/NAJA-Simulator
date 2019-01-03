using System.Collections;
using UnityEngine;

public abstract class BonedInteraction : Interaction
{
    [SerializeField]
    private float animationSpeed;
    [SerializeField]
    private AnimationCurve animationCurve;
    [SerializeField]
    private AnimationCurve reverseAnimationCurve;
    [SerializeField]
    private Transform bone;
    [SerializeField]
    private Vector3 restBonePos;
    [SerializeField]
    private Vector3 restBoneRot;
    [SerializeField]
    private Vector3 operBonePos;
    [SerializeField]
    private Vector3 operBoneRot;
    private delegate bool LoopCondition();
    private float progress = 0.0f;

    public override bool isInputBlocking()
    {
        return false;
    }

    public override void execute()
    {
        running = true;

        StopAllCoroutines();
        StartCoroutine(boneMove(false));
    }

    public virtual void execute(bool reverse)
    {
        running = true;

        StopAllCoroutines();
        StartCoroutine(boneMove(reverse));
    }

    private IEnumerator boneMove(bool reverse)
    {
        LoopCondition condition = () =>
        {
            if (reverse)
            {
                return progress > 0.0f;
            }
            else
            {
                return progress < 1.0f;
            }
        };

        while (condition())
        {
            progress += (0.01f * this.animationSpeed * ((reverse) ? (-1.0f) : (1.0f)));

            float effectiveProgress;

            if (reverse)
                effectiveProgress = reverseAnimationCurve.Evaluate(progress);
            else 
                effectiveProgress = animationCurve.Evaluate(progress);


            bone.localRotation = Quaternion.Lerp(
                Quaternion.Euler(restBoneRot.x, restBoneRot.y, restBoneRot.z),
                Quaternion.Euler(operBoneRot.x, operBoneRot.y, operBoneRot.z), effectiveProgress);

            //meshRenderer.SetBlendShapeWeight(0, 100.0f * animationCurve.Evaluate(Mathf.Clamp(progress, 0.0f, 1.0f)));

            yield return new WaitForSeconds(0.0166f);
        }


        running = false;
    }


    public abstract override string getDescription();
}
