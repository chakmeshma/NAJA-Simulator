using System.Collections;
using UnityEngine;

public class InspectDoorInteraction : Interaction
{
    private static string description = "بررسی در";
    [SerializeField]
    private bool suspicious;
    [SerializeField]
    private AudioClip normalSound;
    [SerializeField]
    private AudioClip suspiciousSound;
    private AudioSource audioSource;

    protected void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public override void execute()
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

        checkFound();
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