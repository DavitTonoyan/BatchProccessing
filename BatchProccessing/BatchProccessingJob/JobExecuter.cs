using BatchProccessing.ChunkProccess;
using BatchProccessing.Context;

namespace BatchProccessing.BatchProccessingJob;

internal class JobExecuter
{
    private readonly IReader _reader;
    private readonly IProccessExecuter _proccessExecuter;
    private readonly IWriter _writer;

    private readonly JobCallerContext _context = new();

    private int chunkSize { get; set; }

    internal JobExecuter(
        int chunkSize,  
        IReader reader,
        IProccessExecuter proccessExecuter,
        IWriter writer)
    {
        this.chunkSize = chunkSize;
        _reader = reader;
        _proccessExecuter = proccessExecuter;
        _writer = writer;
    }


    internal async Task Execute()
    {
        int page = 0;
        _context.State = State.Started;

        while(true)
        {
           
            int start = page * chunkSize;
            int end = start + chunkSize;

            try
            {
                bool hasData = await ChunkProccess(start, end);

                if (!hasData)
                    break;
            }
            catch
            {
                break;
            }
            page++;
        }

        _context.State = State.Finished;
    }

    private async Task<bool> ChunkProccess(int start, int end)
    {
        var readData = await _reader.Read(start, end);

        if (readData is null || readData.Length == 0)
            return false;

        _context.Statistic.UpdateReadCount(readData.Length);

        var writeData = _proccessExecuter.Proccess(readData);

        await _writer.Write(writeData);
        _context.Statistic.UpdateWriteCount();

        return readData.Length == chunkSize;
    }


    internal JobCallerContext GetJobCallerContext()
    {
        return _context;
    }
}
