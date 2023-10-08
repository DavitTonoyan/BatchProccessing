using BatchProccessing.Models;

namespace BatchProccessing.ChunkProccess;

public interface IWriter
{
    Task Write(WriteModel writeModel);
}
