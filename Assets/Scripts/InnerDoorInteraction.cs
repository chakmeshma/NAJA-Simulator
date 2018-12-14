using UnityEngine;

public class InnerDoorInteraction : ReferencingInteraction
{
    private static string description = "خارج شدن از ماشين";

    [SerializeField]
    private Door door;


    private void enableResetPlayerMovement()
    {
        if (instance == this)
        {

            ReferencesAndValues.instance.player.GetComponent<CharacterController>().enabled = true;
            ReferencesAndValues.instance.player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().stopping = false;
        }
        else
            (instance as InnerDoorInteraction).enableResetPlayerMovement();
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

            Loader.instance.switchOutdoor();

            switch (door)
            {
                case Door.FrontLeft:
                    ReferencesAndValues.instance.player.transform.position = ReferencesAndValues.instance.playerOutsideCarFrontLeft.position;
                    ReferencesAndValues.instance.player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().ForceRotateView(ReferencesAndValues.instance.playerOutsideCarFrontLeft.rotation.eulerAngles);
                    break;
                case Door.FrontRight:
                    ReferencesAndValues.instance.player.transform.position = ReferencesAndValues.instance.playerOutsideCarFrontRight.position;
                    ReferencesAndValues.instance.player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().ForceRotateView(ReferencesAndValues.instance.playerOutsideCarFrontRight.rotation.eulerAngles);
                    break;
                case Door.BackLeft:
                    ReferencesAndValues.instance.player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().ForceRotateView(ReferencesAndValues.instance.playerOutsideCarBackLeft.rotation.eulerAngles);
                    ReferencesAndValues.instance.player.transform.position = ReferencesAndValues.instance.playerOutsideCarBackLeft.position;
                    break;
                case Door.BackRight:
                    ReferencesAndValues.instance.player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().ForceRotateView(ReferencesAndValues.instance.playerOutsideCarBackRight.rotation.eulerAngles);
                    ReferencesAndValues.instance.player.transform.position = ReferencesAndValues.instance.playerOutsideCarBackRight.position;
                    break;
            }


            enableResetPlayerMovement();

            running = false;
        }
        else
        {
            instance.execute();
        }
    }

    public override string getDescription()
    {
        return description;
    }
}
