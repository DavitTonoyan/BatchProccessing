using BatchProccessing.Models;

namespace BatchProccessing.ChunkProccess;

public interface IProccessExecuter
{
    WriteModel Proccess(ReadModel[] readModels);
}
