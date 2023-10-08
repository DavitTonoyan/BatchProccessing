namespace BatchProccessing.Context;

public class Statistic
{
    public int ReadCount { get; private set; } = 0;

    public int WriteCount { get; private set; } = 0;

    //public int Total => ReadCount + WriteCount;

    internal void UpdateReadCount(int readCount)
    {
        ReadCount += readCount;
    }

    internal void UpdateWriteCount()
    {
        WriteCount++;
    }
}
