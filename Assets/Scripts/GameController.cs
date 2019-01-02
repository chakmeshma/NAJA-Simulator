﻿using UnityEngine;

public class GameController : MonoBehaviour
{
    public Cursor cursorController;
    private bool lastSelectedState = false; // breaks when camera is initially positioned so, that the item is selected
    private Interaction lastInputBlockingInteraction = null;
    public UnityEngine.UI.Text inputHelpText;
    public KeyCode[] keyCodes;

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl))
        {
            Camera.main.fieldOfView = 15f;
        } else
            Camera.main.fieldOfView = 60f;


        if (lastInputBlockingInteraction == null || !lastInputBlockingInteraction.isRunning())
        {
            bool currentSelectedState;
            Interaction[] interactions = getInteractions();

            currentSelectedState = (interactions != null);

            updateCursor(ref currentSelectedState);
            updateInputGUI(interactions);

            for (int i = 0; i < keyCodes.Length; i++)
            {
                if (Input.GetKeyDown(keyCodes[i]))
                {
                    if (interactions != null && i < interactions.Length && interactions[i].interactable)
                    {

                        try
                        {
                            interactions[i].execute();

                            if (interactions[i] is OpenDoorInteraction)
                            {
                                if ((interactions[i] as OpenDoorInteraction).state == OpenDoorInteraction.State.Opened)
                                {
                                    interactions[i].gameObject.GetComponent<DoorHullRemoveInteraction>().interactable = true;
                                }
                                else
                                {
                                    interactions[i].gameObject.GetComponent<DoorHullRemoveInteraction>().interactable = false;
                                }
                            }
                        }
                        catch (System.Exception e)
                        {
                            e.GetType();
                        }

                        if (interactions[i].isInputBlocking())
                        {
                            lastInputBlockingInteraction = interactions[i];
                        }
                        else
                        {
                            lastInputBlockingInteraction = null;
                        }

                    }

                    break;
                }
            }

        }
    }

    private void updateInputGUI(Interaction[] interactions)
    {
        if (interactions == null)
        {
            inputHelpText.transform.parent.GetComponent<UnityEngine.UI.Image>().enabled = false;
            inputHelpText.enabled = false;
        }
        else
        {
            inputHelpText.transform.parent.GetComponent<UnityEngine.UI.Image>().enabled = true;
            inputHelpText.enabled = true;

            string inputHelpString = "";

            for (int i = 0; i < interactions.Length; i++)
            {
                if (interactions[i].interactable)
                {
                    if (i > 0)
                    {
                        inputHelpString += "\n";
                    }

                    inputHelpString += "برای " + interactions[i].getDescription() + " دکمه ی " + keyCodes[i] + " را بفشاريد.";
                }
            }

            inputHelpText.text = ArabicSupport.ArabicFixer.Fix(inputHelpString);
        }
    }

    private Interaction[] getInteractions()
    {
        RaycastHit raycastHit;

        if (Physics.Raycast(transform.position, transform.forward, out raycastHit, 1.3f, LayerMask.GetMask("Interactable")))
        {
            Interaction[] interactions = raycastHit.transform.GetComponents<Interaction>();

            return (interactions.Length > 0) ? (interactions) : (null);
        }

        return null;
    }

    private void updateCursor(ref bool currentSelectedState)
    {
        if (currentSelectedState != lastSelectedState)
        {
            if (currentSelectedState)
            {
                cursorController.select();
            }
            else
            {
                cursorController.unselect();
            }
        }

        lastSelectedState = currentSelectedState;
    }
}
