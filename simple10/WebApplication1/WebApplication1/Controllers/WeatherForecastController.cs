using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Buffers;
using System.Globalization;
using System.IO.Pipelines;
using System.Text;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        [HttpPost("a/{id}")]
        public Author a([ModelBinder(Name = "id")] Author author)
        {

            return author;
        }
        [HttpGet("get10")]
        public Author get10([ModelBinder(Name = "id")][FromQuery] Author author)
        {
            return author;
        }

        [HttpPost("profile")]
        public string Post(ProfileViewModel profileViewModel)
        {

            return "ok";
        }

        [HttpGet]
        [Route("/{locale}/[controller]/get")]
        public KeyValuePair<string,string> Get([FromRoute] CultureInfo locale,[FromQuery]DateRange2 range)
        {
            CultureInfo.CurrentCulture=locale;
            CultureInfo.CurrentUICulture=locale;
            return new KeyValuePair<string, string>(CultureInfo.CurrentCulture.Name + ":" + range.From.ToString(), range.To.ToString());
        }
        [HttpGet]
        [Route("get3")]
        public string Get3()
        {

            var str = "12\n3\n4\n";
            var bs = Encoding.UTF8.GetBytes(str);
            MemoryStream ms = new MemoryStream(bs);
            var aaaa = GetListOfStringsFromStreamMoreEfficient(ms).Result;
            return "ok";
        }
        private async Task<List<string>> GetListOfStringsFromStreamMoreEfficient(PipeReader  pipeReader)
        {
            List<string> result = new List<string>();
            while (true)
            {
                var readResult = await pipeReader.ReadAsync();
                var buffer=readResult.Buffer;
                SequencePosition? position = null;
                do
                {
                    position = buffer.PositionOf((byte)'\n');
                    if (position != null)
                    {
                        var readOnlySequence = buffer.Slice(0, position.Value);
                        AddStringToList(result, readOnlySequence);
                    }
                   


                } while (position != null);


            }

        }

        private void AddStringToList(List<string> result, ReadOnlySequence<byte> reads)
        {
            var spans = reads.IsSingleSegment ? reads.FirstSpan : reads.ToArray().AsSpan();
            result.Add(Encoding.UTF8.GetString(spans));
        }


        private async Task<List<string>> GetListOfStringsFromStreamMoreEfficient(Stream requestBody)
        {
            StringBuilder builder = new StringBuilder();
            byte[] buffer = ArrayPool<byte>.Shared.Rent(4);
            List<string> results = new List<string>();

            while (true)
            {
                var bytesRemaining = await requestBody.ReadAsync(buffer, offset: 0, buffer.Length);

                if (bytesRemaining == 0)
                {
                    results.Add(builder.ToString());
                    break;
                }

                // Instead of adding the entire buffer into the StringBuilder
                // only add the remainder after the last \n in the array.
                var prevIndex = 0;
                int index;
                while (true)
                {
                    index = Array.IndexOf(buffer, (byte)'\n', prevIndex);
                    if (index == -1)
                    {
                        break;
                    }

                    var encodedString = Encoding.UTF8.GetString(buffer, prevIndex, index - prevIndex);

                    if (builder.Length > 0)
                    {
                        // If there was a remainder in the string buffer, include it in the next string.
                        results.Add(builder.Append(encodedString).ToString());
                        builder.Clear();
                    }
                    else
                    {
                        results.Add(encodedString);
                    }

                    // Skip past last \n
                    prevIndex = index + 1;
                }

                var remainingString = Encoding.UTF8.GetString(buffer, prevIndex, bytesRemaining - prevIndex);
                builder.Append(remainingString);
            }

            ArrayPool<byte>.Shared.Return(buffer);

            return results;
        }
        [HttpPost]
        [Route("get2")]
        public DemoModel Get2(DemoModel demoModel)
        {
            return demoModel;
        }

        [HttpGet("get9")]
        public string Get9([FromQuery]Get9Model get9Model)
        {
            return "ok";
        }

        [AcceptVerbs("GET","POST")]
        public bool VerifyUserName(string username)
        {

            return username == "admin" ? true : false;
        }

    }
}
