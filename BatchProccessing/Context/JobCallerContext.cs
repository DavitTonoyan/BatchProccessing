namespace BatchProccessing.Context;

public class JobCallerContext
{
    internal JobCallerContext()
    {
        State = State.NotStarted;
        Statistic = new Statistic();
    }


    public State State { get; internal set; }

    public Statistic Statistic { get; internal set; }
}
