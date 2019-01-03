using UnityEngine;

public class InnerDoorInteraction : Interaction
{
    private static string description = "خارج شدن از ماشين";

    [SerializeField]
    private Door door;


    private void enableResetPlayerMovement()
    {
        Data.instance.player.GetComponent<CharacterController>().enabled = true;
        Data.instance.player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().stopping = false;
    }

    public override bool isInputBlocking()
    {
        return true;
    }

    public override void execute()
    {
        running = true;

        Loader.instance.switchOutdoor();

        switch (door)
        {
            case Door.FrontLeft:
                Data.instance.player.transform.position = Data.instance.playerOutsideCarFrontLeft.position;
                Data.instance.player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().ForceRotateView(Data.instance.playerOutsideCarFrontLeft.rotation.eulerAngles);
                break;
            case Door.FrontRight:
                Data.instance.player.transform.position = Data.instance.playerOutsideCarFrontRight.position;
                Data.instance.player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().ForceRotateView(Data.instance.playerOutsideCarFrontRight.rotation.eulerAngles);
                break;
            case Door.BackLeft:
                Data.instance.player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().ForceRotateView(Data.instance.playerOutsideCarBackLeft.rotation.eulerAngles);
                Data.instance.player.transform.position = Data.instance.playerOutsideCarBackLeft.position;
                break;
            case Door.BackRight:
                Data.instance.player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().ForceRotateView(Data.instance.playerOutsideCarBackRight.rotation.eulerAngles);
                Data.instance.player.transform.position = Data.instance.playerOutsideCarBackRight.position;
                break;
        }


        enableResetPlayerMovement();

        running = false;

        checkFound();
    }

    public override string getDescription()
    {
        return description;
    }
}
