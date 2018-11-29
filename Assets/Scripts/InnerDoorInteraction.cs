using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerDoorInteraction : MonoBehaviour , IInteraction  {
    private static string description = "خارج شدن از ماشين";
    private static bool running = false;

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
        running = true;

        ReferencesAndValues.instance.outerCar.SetActive(true);
        ReferencesAndValues.instance.innerCar.SetActive(false);

        ReferencesAndValues.instance.player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().ForceRotateView(ReferencesAndValues.instance.playerOutsideCarRotation);
        ReferencesAndValues.instance.player.transform.position = ReferencesAndValues.instance.playerOutsideCarPosition;

        enableResetPlayerMovement();

        running = false;
    }

    public bool isRunning()
    {
        return running;
    }

    public string getDescription()
    {
        return description;
    }
}
