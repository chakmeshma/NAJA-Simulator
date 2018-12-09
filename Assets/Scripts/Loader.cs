using UnityEngine;

public class Loader : MonoBehaviour
{
    public static Loader instance = null;
    public int maxProgress = 2;
    private int progress = 0;
    private Interaction[] innerCarInteractionScripts;
    private Renderer[] innerCarRenderers;
    private Collider[] innerCarColliders;
    private Interaction[] outerCarInteractionScripts;
    private Renderer[] outerCarRenderers;
    private Collider[] outerCarColliders;

    void Awake()
    {
        instance = this;

        innerCarInteractionScripts = ReferencesAndValues.instance.innerCar.GetComponentsInChildren<Interaction>();
        innerCarRenderers = ReferencesAndValues.instance.innerCar.GetComponentsInChildren<Renderer>();
        innerCarColliders = ReferencesAndValues.instance.innerCar.GetComponentsInChildren<MeshCollider>();

        outerCarInteractionScripts = ReferencesAndValues.instance.outerCar.GetComponentsInChildren<Interaction>();
        outerCarRenderers = ReferencesAndValues.instance.outerCar.GetComponentsInChildren<Renderer>();
        outerCarColliders = ReferencesAndValues.instance.outerCar.GetComponentsInChildren<MeshCollider>();
    }

    void applyInitialState()
    {
        switchOutdoor();

        ReferencesAndValues.instance.player.GetComponent<CharacterController>().enabled = true;
        ReferencesAndValues.instance.player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
        ReferencesAndValues.instance.cursorController.cursorImage.enabled = true;
    }

    void Start()
    {
        applyInitialState();

        Destroy(GameObject.Find("Splash Canvas").gameObject);
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
