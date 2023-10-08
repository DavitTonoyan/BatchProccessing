using BatchProccessing.ChunkProccess;
using BatchProccessing.Models;
using JobTest.Models;

namespace JobTest
{
    public class ProccessExecuter : IProccessExecuter
    {
        MessageWriteModel writeModel = new MessageWriteModel();

        public WriteModel Proccess(ReadModel[] readModels)
        {
            MessageWriteModel writeModel = new MessageWriteModel();

            foreach (var readModel in readModels)
            {
                MessageReadModel messageReadModel = (MessageReadModel)readModel;
                string text = @$"{messageReadModel.Id},
                                 {messageReadModel.FromMemberId},
                                 {messageReadModel.ToMemberId},
                                 {messageReadModel.Text}";

                writeModel.Text += readModel.ToString();
            }

            return writeModel;
        }
    }
}
