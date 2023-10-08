using BatchProccessing.Models;

namespace BatchProccessing.ChunkProccess;

public interface IReader
{
    Task<ReadModel[]> Read(int start, int end);
}
