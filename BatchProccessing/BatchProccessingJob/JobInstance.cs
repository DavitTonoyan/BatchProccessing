using BatchProccessing.ChunkProccess;
using BatchProccessing.Context;
using BatchProccessing.Exceptions;

namespace BatchProccessing.BatchProccessingJob;

public class JobInstance
{
    private JobExecuter _executer;

    private JobInstance(
        int chunkSize,
        IReader reader,
        IProccessExecuter proccessExexcuter,
        IWriter writer)
    {
        _executer = new JobExecuter(
            chunkSize, reader, proccessExexcuter, writer);
    }

    public JobCallerContext Context => _executer.GetJobCallerContext();

    public async Task Start()
    {
       await _executer.Execute();
    }


    public static JobInstance Create(
        int chunkSize,
        IReader reader,
        IProccessExecuter proccessExexcuter,
        IWriter writer)
    {
        if (chunkSize <= 0)
        {
            throw new CanNotCreateJobInstanceException(
                "Chunk size should be greater than 0");
        }

        var jobInstance = new JobInstance(chunkSize, reader, proccessExexcuter, writer);

        return jobInstance;
    }
}
