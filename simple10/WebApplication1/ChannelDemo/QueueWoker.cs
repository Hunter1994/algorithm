using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ChannelDemo
{
    public class QueueWoker
    {
        private Channel<Func<CancellationToken, ValueTask>> channel;
        public QueueWoker()
        {
            channel= Channel.CreateBounded<Func<CancellationToken, ValueTask>>(new BoundedChannelOptions(100)
            {
                FullMode = BoundedChannelFullMode.Wait
            });
        }

        public async Task Queue(Func<CancellationToken, ValueTask> func)
        {
            await channel.Writer.WriteAsync(func);
        }

        public async Task<Func<CancellationToken, ValueTask>> Dequeue()
        {
            return await channel.Reader.ReadAsync();
        }

    }
}
