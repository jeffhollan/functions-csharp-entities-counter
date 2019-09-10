using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Hollan.Function
{
    public class Counter
    {
        private readonly ILogger _log;
        public Counter(ILogger log)
        {
            _log = log;
        }
        public int Count = 0;
        public void Increment() => Count++;
        public void Decrement() => Count--;
        public void End() => Entity.Current.DestructOnExit();

        [FunctionName(nameof(Counter))]
        public static Task Run(
            [EntityTrigger] IDurableEntityContext ctx,
            ILogger log) 
            => ctx.DispatchAsync<Counter>(log);
    }
}
