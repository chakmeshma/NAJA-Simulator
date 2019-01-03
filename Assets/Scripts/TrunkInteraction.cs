public class TrunkInteraction : BonedInteraction
{
    public enum State
    {
        Opened,
        Closed
    }

    private State state = State.Closed;

    private static string description = "باز کردن";
    private static string reverseDescription = "بستن";

    public override void execute()
    {
        base.execute(state == State.Opened);

        state = (state == State.Closed) ? (State.Opened) : (State.Closed);

        checkFound();
    }

    public override string getDescription()
    {
        return (state == State.Closed) ? (description) : (reverseDescription);
    }
}
