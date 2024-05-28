using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Buffers;
using System.Text;
using System.IO;
using System.IO.Pipelines;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace WebApplication4
{
    public class DemoMiddleware
    {
        private RequestDelegate _next;
        public DemoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {


            var path = context.Request.Path;
            var url = GetRequestUrl(context.Request);
            if (context.Request.Headers != null)
            {
                var hander = JsonConvert.SerializeObject(context.Request.Headers);
            }

            context.Request.EnableBuffering();
            using StreamReader sr = new StreamReader(context.Request.Body);
            var requestBody = sr.ReadToEndAsync().Result;

            var postType = context.Request.Method.ToString();
          

            // 在响应完成后获取响应体的内容
            var response = context.Response;
            var originalBodyStream = response.Body;
            try
            {
                using (var memStream = new MemoryStream())
                {
                    // 将响应流重定向到内存流
                    response.Body = memStream;
                    await _next.Invoke(context);
                    // 读取响应内容
                    memStream.Seek(0, SeekOrigin.Begin);
                    string responseBody = await new StreamReader(memStream).ReadToEndAsync();

                    // 在这里可以对响应内容进行处理
                    Console.WriteLine("Response Body: " + responseBody);

                    // 将响应内容写回原始的响应流
                    memStream.Seek(0, SeekOrigin.Begin);
                    await memStream.CopyToAsync(originalBodyStream);
                }
            }
            finally
            {
                // 恢复原始的响应流
                response.Body = originalBodyStream;
            }


        }

        private string GetString(ReadOnlySequence<byte> readOnlySequence)
        {
            ReadOnlySpan<byte> span = readOnlySequence.IsSingleSegment ? readOnlySequence.First.Span : readOnlySequence.ToArray().AsSpan();
            return Encoding.UTF8.GetString(span);
        }

        private static string GetRequestUrl(HttpRequest request)
        {
            return $"{request.Scheme}://{request.Host}{request.Path}{request.QueryString.Value}";
        }


        private async Task<List<string>> GetListOfStringsFromStream(Stream requestBody)
        {
            // Build up the request body in a string builder.
            StringBuilder builder = new StringBuilder();

            // Rent a shared buffer to write the request body into.
            byte[] buffer = ArrayPool<byte>.Shared.Rent(4096);

            while (true)
            {
                var bytesRemaining = await requestBody.ReadAsync(buffer, offset: 0, buffer.Length);
                if (bytesRemaining == 0)
                {
                    break;
                }

                // Append the encoded string into the string builder.
                var encodedString = Encoding.UTF8.GetString(buffer, 0, bytesRemaining);
                builder.Append(encodedString);
            }

            ArrayPool<byte>.Shared.Return(buffer);

            var entireRequestBody = builder.ToString();

            // Split on \n in the string.
            return new List<string>(entireRequestBody.Split("\n"));
        }

        private async Task<List<string>> GetListOfStringFromPipe(PipeReader reader)
        {
            List<string> results = new List<string>();

            while (true)
            {
                ReadResult readResult = await reader.ReadAsync();
                var buffer = readResult.Buffer;

                SequencePosition? position = null;

                do
                {
                    // Look for a EOL in the buffer
                    position = buffer.PositionOf((byte)'\n');

                    if (position != null)
                    {
                        var readOnlySequence = buffer.Slice(0, position.Value);
                        AddStringToList(results, in readOnlySequence);

                        // Skip the line + the \n character (basically position)
                        buffer = buffer.Slice(buffer.GetPosition(1, position.Value));
                    }
                }
                while (position != null);


                if (readResult.IsCompleted && buffer.Length > 0)
                {
                    AddStringToList(results, in buffer);
                }

                reader.AdvanceTo(buffer.Start, buffer.End);

                // At this point, buffer will be updated to point one byte after the last
                // \n character.
                if (readResult.IsCompleted)
                {
                    break;
                }
            }

            return results;
        }

        private static void AddStringToList(List<string> results, in ReadOnlySequence<byte> readOnlySequence)
        {
            // Separate method because Span/ReadOnlySpan cannot be used in async methods
            ReadOnlySpan<byte> span = readOnlySequence.IsSingleSegment ? readOnlySequence.First.Span : readOnlySequence.ToArray().AsSpan();
            results.Add(Encoding.UTF8.GetString(span));
        }
    }

    public static class DemoExtenstion
    {
        public static IApplicationBuilder UseDemo(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DemoMiddleware>();
        }
    }
}
