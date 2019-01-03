using System.Linq;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameController : MonoBehaviour
{
    public static GameController instance { get { return _instance; } }
    private static GameController _instance;

    public GameObject menuContainer;
    public UnityEngine.UI.Text inputHelpText;
    public UnityEngine.UI.Text objectiveText;
    public UnityEngine.UI.Text resultText;
    public KeyCode[] keyCodes;
    private bool lastSelectedState = false; // breaks when camera is initially positioned so, that the item is selected
    private Interaction lastInputBlockingInteraction = null;
    private System.Collections.Generic.HashSet<Interaction> foundInteractions = new System.Collections.Generic.HashSet<Interaction>();
    [SerializeField]
    private int numObjectives = 2;

    public void found(Interaction interaction)
    {
        foundInteractions.Add(interaction);

        updateObjective();
    }

    private void updateObjective()
    {
        if (foundInteractions.Count >= numObjectives)
        {
            gameOver(true);
        }

        updateObjectiveUI();
    }

    private void updateObjectiveUI()
    {
        objectiveText.text = ArabicSupport.ArabicFixer.Fix("موارد کشف شده: " + foundInteractions.Count.ToString() + " از " + numObjectives.ToString());
    }

    private bool menuShown
    {
        get { return _menuShown; }
        set { _menuShown = value; updateMenuGame(); }
    }
    private bool _menuShown = false;

    public void gameOver(bool win)
    {
        Data.instance.inGameMenuItems.Remove(Menu.MenuItem.Resume);
        Data.instance.menu.populate(Data.instance.inGameMenuItems.Keys.ToList());

        if (win)
        {
            int score = Mathf.RoundToInt(1000.0f / Timer.instance.elapsedTime);

            resultText.text = ArabicSupport.ArabicFixer.Fix("برنده شديد\nامتياز شما: " + score.ToString());
        }
        else
        {
            resultText.text = ArabicSupport.ArabicFixer.Fix("باختيد");
        }

        menuShown = true;
    }
    public void menuItemAction(Menu.MenuItem item)
    {
        switch (item)
        {
            case Menu.MenuItem.Resume:
                menuShown = false;
                break;
            case Menu.MenuItem.Again:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
                break;
            case Menu.MenuItem.Exit:
                Application.Quit();
                break;
        }

    }

    private void Start()
    {
        updateObjectiveUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuShown = !menuShown;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            Camera.main.fieldOfView = 15f;
        }
        else
        {
            Camera.main.fieldOfView = 60f;
        }

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
                Data.instance.cursor.select();
            }
            else
            {
                Data.instance.cursor.unselect();
            }
        }

        lastSelectedState = currentSelectedState;
    }
    private void updateMenuGame()
    {
        Data.instance.player.GetComponentInChildren<FirstPersonController>().stopping = menuShown;
        Data.instance.player.GetComponentInChildren<FirstPersonController>().freezing = menuShown;
        Timer.instance.freezing = menuShown;
        UnityEngine.Cursor.lockState = (menuShown) ? (CursorLockMode.None) : (CursorLockMode.Locked);
        UnityEngine.Cursor.visible = menuShown;
        menuContainer.SetActive(menuShown);
    }

    private void Awake()
    {
        _instance = this;

        Data.instance.menu.populate(Data.instance.inGameMenuItems.Keys.ToList());

        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

}
