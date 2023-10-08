using BatchProccessing.BatchProccessingJob;
using Microsoft.AspNetCore.Mvc;

namespace JobTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTestController : ControllerBase
    {
        [HttpGet("Run")]
        public async Task<IActionResult> BatchProccess()
        {
            Reader reader = new Reader();
            Writer writer = new Writer();
            ProccessExecuter executer = new ProccessExecuter();

            int chunkSize = 3;

            Job job = new Job(chunkSize, reader, executer, writer);

            JobInstance jobInstance = job.GetInstance();

            string state = jobInstance.Context.State.ToString();
            Console.WriteLine(state);
            Task task = jobInstance.Start();

            state = jobInstance.Context.State.ToString();
            int readCount = jobInstance.Context.Statistic.ReadCount;
            int writeCount = jobInstance.Context.Statistic.WriteCount;

            Console.WriteLine("state: " + state);
            Console.WriteLine("ReadCount: " + readCount);
            Console.WriteLine("WriteCount: " + writeCount);

            await task;



            state = jobInstance.Context.State.ToString();
            readCount = jobInstance.Context.Statistic.ReadCount;
            writeCount = jobInstance.Context.Statistic.WriteCount;

            Console.WriteLine("state: " + state);
            Console.WriteLine("ReadCount: " + readCount);
            Console.WriteLine("WriteCount: " + writeCount);

            return Ok();
        }

    }
}
