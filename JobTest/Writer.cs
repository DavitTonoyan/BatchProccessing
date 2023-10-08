using BatchProccessing.ChunkProccess;
using BatchProccessing.Models;
using JobTest.Models;

namespace JobTest;

public class Writer : IWriter
{
    public async Task Write(WriteModel writeModel)
    {
        MessageWriteModel messageWriteModel = (MessageWriteModel)writeModel;

        await File.AppendAllTextAsync("BatchProccessing.txt", messageWriteModel.Text);
    }
}
