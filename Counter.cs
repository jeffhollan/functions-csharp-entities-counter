using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Hollan.Function
{
    public class Counter
    {
        private readonly IDurableEntityContext _ctx;
        private readonly ILogger _log;
        public Counter(IDurableEntityContext ctx, ILogger log)
        {
            _ctx = ctx;
            _log = log;
        }
        public int Count = 0;
        public void Increment() => Count++;
        public void Decrement() => Count--;

        [FunctionName(nameof(Counter))]
        public static Task Run(
            [EntityTrigger] IDurableEntityContext ctx,
            ILogger log) 
            => ctx.DispatchAsync<Counter>(ctx, log);
    }
}
