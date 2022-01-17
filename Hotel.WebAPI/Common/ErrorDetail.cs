using Newtonsoft.Json;

namespace Hotel.WebAPI.Common
{
    public class ErrorDetail
    {
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}