using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuterDoorInteraction : MonoBehaviour , IInteraction {
    private static string description = "نشستن در ماشين";
    private static bool running = false;

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
        running = true;

        disableResetPlayerMovement();

        ReferencesAndValues.instance.outerCar.SetActive(false);
        ReferencesAndValues.instance.innerCar.SetActive(true);

        ReferencesAndValues.instance.player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().ForceRotateView(ReferencesAndValues.instance.playerInsideCarRotation);
        ReferencesAndValues.instance.player.transform.position = ReferencesAndValues.instance.playerInsideCarPosition;

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
