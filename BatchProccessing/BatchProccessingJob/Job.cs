using BatchProccessing.ChunkProccess;
using BatchProccessing.Settings;

namespace BatchProccessing.BatchProccessingJob;

public class Job
{
    private readonly int _chunkSize;
    private readonly IReader _reader;
    private readonly IProccessExecuter _proccessExecuter;
    private readonly IWriter _writer;

    
    public Job(
        int chunkSize,
        IReader reader,
        IProccessExecuter proccessExecuter,
        IWriter writer)
    {
        _chunkSize = chunkSize;
        _reader = reader;
        _proccessExecuter = proccessExecuter;
        _writer = writer;
    }



    public JobInstance GetInstance()
    {
        return JobInstance.Create(
            _chunkSize, _reader, _proccessExecuter, _writer);
    }
}
