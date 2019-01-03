public abstract class Interaction : UnityEngine.MonoBehaviour
{
    [UnityEngine.SerializeField]
    protected bool found = false;
    protected bool _interactable = true;
    protected bool running = false;

    public bool interactable
    {
        get
        {
            return _interactable;
        }

        set
        {
            _interactable = value;
        }
    }

    public abstract bool isInputBlocking();
    public abstract void execute();
    protected void checkFound()
    {
        if (found)
            GameController.instance.found(this);
    }
    public abstract string getDescription();
    public bool isRunning()
    {
        return this.running;
    }
}
