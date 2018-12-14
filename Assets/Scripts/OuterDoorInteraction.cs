using UnityEngine;

public enum Door
{
    FrontLeft,
    FrontRight,
    BackLeft,
    BackRight
}

public class OuterDoorInteraction : ReferencingInteraction
{
    private static string description = "نشستن در ماشين";

    [SerializeField]
    private Door door;

    private void disableResetPlayerMovement()
    {
        if (instance == this)
        {

            ReferencesAndValues.instance.player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().stopping = true;
            ReferencesAndValues.instance.player.GetComponent<CharacterController>().Move(Vector3.zero);
            ReferencesAndValues.instance.player.GetComponent<CharacterController>().enabled = false;
            Vector3 cameraLocalPosition = Camera.main.transform.localPosition;
            Camera.main.transform.localPosition = new Vector3(0.0f, cameraLocalPosition.y, cameraLocalPosition.z);
        }
        else
        {
            (instance as OuterDoorInteraction).execute();
        }
    }

    public override bool isInputBlocking()
    {
        return true;
    }

    public override void execute()
    {
        if (instance == this)
        {
            running = true;

            disableResetPlayerMovement();

            Loader.instance.switchIndoor();

            switch (door)
            {
                case Door.FrontLeft:
                    ReferencesAndValues.instance.player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().ForceRotateView(ReferencesAndValues.instance.playerInsideCarFrontLeft.rotation.eulerAngles);
                    ReferencesAndValues.instance.player.transform.position = ReferencesAndValues.instance.playerInsideCarFrontLeft.position;
                    break;
                case Door.FrontRight:
                    ReferencesAndValues.instance.player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().ForceRotateView(ReferencesAndValues.instance.playerInsideCarFrontRight.rotation.eulerAngles);
                    ReferencesAndValues.instance.player.transform.position = ReferencesAndValues.instance.playerInsideCarFrontRight.position;
                    break;
                case Door.BackLeft:
                    ReferencesAndValues.instance.player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().ForceRotateView(ReferencesAndValues.instance.playerInsideCarBackLeft.rotation.eulerAngles);
                    ReferencesAndValues.instance.player.transform.position = ReferencesAndValues.instance.playerInsideCarBackLeft.position;
                    break;
                case Door.BackRight:
                    ReferencesAndValues.instance.player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().ForceRotateView(ReferencesAndValues.instance.playerInsideCarBackRight.rotation.eulerAngles);
                    ReferencesAndValues.instance.player.transform.position = ReferencesAndValues.instance.playerInsideCarBackRight.position;
                    break;
            }


            running = false;
        }
        else
        {
            (instance as OuterDoorInteraction).execute();
        }
    }

    public override string getDescription()
    {
        return description;
    }
}
