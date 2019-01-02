public class OpenDoorInteraction : BonedInteraction
{
    public enum State
    {
        Opened,
        Closed
    }
    private State _state = State.Closed;
    public State state
    {
        get
        {
            return _state;
        }
    }

    private static string description = "باز کردن";
    private static string reverseDescription = "بستن";

    public override void execute()
    {
        base.execute(_state == State.Opened);

        _state = (_state == State.Closed) ? (State.Opened) : (State.Closed);
    }

    public override string getDescription()
    {
        return (_state == State.Closed) ? (description) : (reverseDescription);
    }
}
