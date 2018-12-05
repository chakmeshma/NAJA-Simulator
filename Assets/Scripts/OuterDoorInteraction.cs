using UnityEngine;

public enum Door
{
    FrontLeft,
    FrontRight,
    BackLeft,
    BackRight
}


public class OuterDoorInteraction : MonoBehaviour, IInteraction
{
    private static string description = "نشستن در ماشين";
    private bool running = false;
    public Door door;
    public OuterDoorInteraction referedInstance = null;
    private OuterDoorInteraction instance;


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

    private void disableResetPlayerMovement()
    {
        ReferencesAndValues.instance.player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().stopping = true;
        ReferencesAndValues.instance.player.GetComponent<CharacterController>().Move(Vector3.zero);
        ReferencesAndValues.instance.player.GetComponent<CharacterController>().enabled = false;
        Vector3 cameraLocalPosition = Camera.main.transform.localPosition;
        Camera.main.transform.localPosition = new Vector3(0.0f, cameraLocalPosition.y, cameraLocalPosition.z);
    }

    public bool isInputBlocking()
    {
        return true;
    }

    public void run()
    {
        instance.running = true;

        instance.disableResetPlayerMovement();

        ReferencesAndValues.instance.outerCar.SetActive(false);
        ReferencesAndValues.instance.innerCar.SetActive(true);

        ReferencesAndValues.instance.player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().ForceRotateView(ReferencesAndValues.instance.playerInsideCarRotation);


        switch (instance.door)
        {
            case Door.FrontLeft:
                ReferencesAndValues.instance.player.transform.position = ReferencesAndValues.instance.playerInsideCarPositionFrontLeft;
                break;
            case Door.FrontRight:
                ReferencesAndValues.instance.player.transform.position = ReferencesAndValues.instance.playerInsideCarPositionFrontRight;
                break;
            case Door.BackLeft:
                ReferencesAndValues.instance.player.transform.position = ReferencesAndValues.instance.playerInsideCarPositionBackLeft;
                break;
            case Door.BackRight:
                ReferencesAndValues.instance.player.transform.position = ReferencesAndValues.instance.playerInsideCarPositionBackRight;
                break;
        }


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
