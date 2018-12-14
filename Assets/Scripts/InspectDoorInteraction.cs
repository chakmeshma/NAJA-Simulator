using System.Collections;
using UnityEngine;

public class InspectDoorInteraction : ReferencingInteraction
{
    private static string description = "بررسی در";
    [SerializeField]
    private bool suspicious;
    [SerializeField]
    private AudioClip normalSound;
    [SerializeField]
    private AudioClip suspiciousSound;
    private AudioSource audioSource;

    protected override void Awake()
    {
        base.Awake();

        if (instance == this)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public override void execute()
    {
        if (instance == this)
        {

            if (suspicious)
            {
                audioSource.clip = suspiciousSound;
            }
            else
            {
                audioSource.clip = normalSound;
            }

            running = true;

            audioSource.Play();

            StopAllCoroutines();
            StartCoroutine(soundPlayRunning());
        }
        else
        {
            instance.execute();
        }
    }

    private IEnumerator soundPlayRunning()
    {
        yield return new WaitForSeconds(audioSource.clip.length);

        running = false;
    }

    public override string getDescription()
    {
        return description;
    }

    public override bool isInputBlocking()
    {
        return false;
    }
}