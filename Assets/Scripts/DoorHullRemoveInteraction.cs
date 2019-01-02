using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHullRemoveInteraction : Interaction
{
    [SerializeField]
    private GameObject doorHull;
    private static string description = "بررسی داخل در";

    private void Awake()
    {
        interactable = false;
    }

    public override void execute()
    {
        doorHull.SetActive(false);

        interactable = false;
    }

    public override string getDescription()
    {
        return description;
    }

    public override bool isInputBlocking()
    {
        return false;
    }
}
