public abstract class Interaction : UnityEngine.MonoBehaviour
{
    protected bool _interactable = true;
    protected bool running = false;

    protected virtual bool interactable
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
    public abstract string getDescription();
    public bool isRunning()
    {
        return this.running;
    }
}
