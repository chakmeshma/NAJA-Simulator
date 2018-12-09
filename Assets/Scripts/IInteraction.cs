public abstract class Interaction : UnityEngine.MonoBehaviour
{
    public abstract bool isInputBlocking();
    public abstract void execute();
    public abstract bool isRunning();
    public abstract string getDescription();
}
