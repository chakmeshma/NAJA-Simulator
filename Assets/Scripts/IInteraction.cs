public abstract class Interaction : UnityEngine.MonoBehaviour
{
    protected bool running = false;

    public abstract bool isInputBlocking();
    public abstract void execute();
    public abstract string getDescription();
    public bool isRunning()
    {
        return this.running;
    }
}
