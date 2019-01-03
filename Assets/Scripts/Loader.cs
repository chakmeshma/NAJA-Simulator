using UnityEngine;
using System.Collections.Generic;

public class Loader : MonoBehaviour
{
    public static Loader instance = null;
    public int maxProgress = 2;
    private int progress = 0;
    private Interaction[] innerCarInteractionScripts;
    private Renderer[] innerCarRenderers;
    private List<Collider> innerCarColliders;
    private Interaction[] outerCarInteractionScripts;
    private Renderer[] outerCarRenderers;
    private List<Collider> outerCarColliders;

    void Awake()
    {
        instance = this;

        innerCarInteractionScripts = Data.instance.innerCar.GetComponentsInChildren<Interaction>();
        innerCarRenderers = Data.instance.innerCar.GetComponentsInChildren<Renderer>();
        innerCarColliders = new List<Collider>(Data.instance.innerCar.GetComponentsInChildren<Collider>());

        innerCarColliders.RemoveAll(item => item.tag != "Interactable");

        foreach (Collider i in innerCarColliders)

        outerCarInteractionScripts = Data.instance.outerCar.GetComponentsInChildren<Interaction>();
        outerCarRenderers = Data.instance.outerCar.GetComponentsInChildren<Renderer>();
        outerCarColliders = new List<Collider>(Data.instance.outerCar.GetComponentsInChildren<Collider>());

        outerCarColliders.RemoveAll(item => item.tag != "Interactable");
    }

    void applyInitialState()
    {
        switchOutdoor();

        Data.instance.player.GetComponent<CharacterController>().enabled = true;
        Data.instance.player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
        Data.instance.cursor.cursorImage.enabled = true;
    }

    void Start()
    {
        applyInitialState();

        try
        {
            Destroy(GameObject.Find("Splash Canvas").gameObject);
        } catch(System.NullReferenceException e)
        {
            e.GetType();
        }
    }

    public void switchIndoor()
    {
        foreach (Interaction i in outerCarInteractionScripts)
            i.enabled = false;

        foreach (Collider i in outerCarColliders)
            i.gameObject.layer = 0;

        foreach (Renderer i in outerCarRenderers)
            i.enabled = false;

        foreach (Interaction i in innerCarInteractionScripts)
            i.enabled = true;

        foreach (Collider i in innerCarColliders)
            i.gameObject.layer = 9;

        foreach (Renderer i in innerCarRenderers)
            i.enabled = true;
    }

    public void switchOutdoor()
    {
        foreach (Interaction i in innerCarInteractionScripts)
            i.enabled = false;

        foreach (Collider i in innerCarColliders)
            i.gameObject.layer = 0;

        foreach (Renderer i in innerCarRenderers)
            i.enabled = false;


        foreach (Interaction i in outerCarInteractionScripts)
            i.enabled = true;

        foreach (Collider i in outerCarColliders)
            i.gameObject.layer = 9;

        foreach (Renderer i in outerCarRenderers)
            i.enabled = true;
    }



    void incrementProgress()
    {
        progress++;

        if (progress >= maxProgress)
        {
            loadingFinished();
        }
    }

    void loadingFinished()
    {

    }
}
