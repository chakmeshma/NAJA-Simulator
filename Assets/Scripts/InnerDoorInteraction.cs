using UnityEngine;

public class InnerDoorInteraction : MonoBehaviour, IInteraction
{
    private static string description = "خارج شدن از ماشين";
    private bool running = false;
    public Door door;
    public InnerDoorInteraction referedInstance = null;
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

    public bool isInputBlocking()
    {
        return true;
    }

    public void run()
    {
        instance.running = true;

        ReferencesAndValues.instance.outerCar.SetActive(true);
        ReferencesAndValues.instance.innerCar.SetActive(false);

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

    public bool isRunning()
    {
        return instance.running;
    }

    public string getDescription()
    {
        return description;
    }
}
