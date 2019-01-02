using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HonkHullRemoveInteraction : Interaction
{
    [SerializeField]
    private GameObject honkHull;
    private static string description = "بررسی داخل بوق";

    private void Awake()
    {
        interactable = true;
    }

    public override void execute()
    {
        honkHull.SetActive(false);

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
