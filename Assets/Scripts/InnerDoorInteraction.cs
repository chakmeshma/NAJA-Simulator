using UnityEngine;

public class InnerDoorInteraction : Interaction
{
    private static string description = "خارج شدن از ماشين";
    private bool running = false;
    [SerializeField]
    private Door door;
    [SerializeField]
    private InnerDoorInteraction referedInstance = null;
    private InnerDoorInteraction instance;


    void Awake()
    {
        if (referedInstance)
        {
            instance = referedInstance;
        }
        else
        {
            instance = this;
        }
    }


    private void enableResetPlayerMovement()
    {
        ReferencesAndValues.instance.player.GetComponent<CharacterController>().enabled = true;
        ReferencesAndValues.instance.player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().stopping = false;
    }

    public override bool isInputBlocking()
    {
        return true;
    }

    public override void execute()
    {
        instance.running = true;

        Loader.instance.switchOutdoor();

        ReferencesAndValues.instance.player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().ForceRotateView(ReferencesAndValues.instance.playerOutsideCarRotation);
        switch (instance.door)
        {
            case Door.FrontLeft:
                ReferencesAndValues.instance.player.transform.position = ReferencesAndValues.instance.playerOutsideCarPositionFrontLeft;
                break;
            case Door.FrontRight:
                ReferencesAndValues.instance.player.transform.position = ReferencesAndValues.instance.playerOutsideCarPositionFrontRight;
                break;
            case Door.BackLeft:
                ReferencesAndValues.instance.player.transform.position = ReferencesAndValues.instance.playerOutsideCarPositionBackLeft;
                break;
            case Door.BackRight:
                ReferencesAndValues.instance.player.transform.position = ReferencesAndValues.instance.playerOutsideCarPositionBackRight;
                break;
        }


        instance.enableResetPlayerMovement();

        instance.running = false;
    }

    public override bool isRunning()
    {
        return instance.running;
    }

    public override string getDescription()
    {
        return description;
    }
}
