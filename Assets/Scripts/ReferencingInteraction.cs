using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ReferencingInteraction : Interaction {
    [SerializeField]
    protected ReferencingInteraction referedInstance = null;
    protected ReferencingInteraction instance;


    protected virtual void Awake()
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
}
