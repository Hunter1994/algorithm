using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json.Serialization;

namespace WebApplication1
{
    public class DemoModel
    {
        public string UserName { get; set; }
        [BindNever]
        public string Password { get; set; }

        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId objectId { get; set; }
    }
}
