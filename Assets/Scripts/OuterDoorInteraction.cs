using UnityEngine;

public enum Door
{
    FrontLeft,
    FrontRight,
    BackLeft,
    BackRight
}

public class OuterDoorInteraction : Interaction
{
    private static string description = "نشستن در ماشين";

    [SerializeField]
    private Door door;

    private void disableResetPlayerMovement()
    {
        Data.instance.player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().stopping = true;
        Data.instance.player.GetComponent<CharacterController>().Move(Vector3.zero);
        Data.instance.player.GetComponent<CharacterController>().enabled = false;
        Vector3 cameraLocalPosition = Camera.main.transform.localPosition;
        Camera.main.transform.localPosition = new Vector3(0.0f, cameraLocalPosition.y, cameraLocalPosition.z);
    }

    public override bool isInputBlocking()
    {
        return true;
    }

    public override void execute()
    {
        running = true;

        disableResetPlayerMovement();

        Loader.instance.switchIndoor();

        switch (door)
        {
            case Door.FrontLeft:
                Data.instance.player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().ForceRotateView(Data.instance.playerInsideCarFrontLeft.rotation.eulerAngles);
                Data.instance.player.transform.position = Data.instance.playerInsideCarFrontLeft.position;
                break;
            case Door.FrontRight:
                Data.instance.player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().ForceRotateView(Data.instance.playerInsideCarFrontRight.rotation.eulerAngles);
                Data.instance.player.transform.position = Data.instance.playerInsideCarFrontRight.position;
                break;
            case Door.BackLeft:
                Data.instance.player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().ForceRotateView(Data.instance.playerInsideCarBackLeft.rotation.eulerAngles);
                Data.instance.player.transform.position = Data.instance.playerInsideCarBackLeft.position;
                break;
            case Door.BackRight:
                Data.instance.player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().ForceRotateView(Data.instance.playerInsideCarBackRight.rotation.eulerAngles);
                Data.instance.player.transform.position = Data.instance.playerInsideCarBackRight.position;
                break;
        }

        running = false;
    }

    public override string getDescription()
    {
        return description;
    }
}
