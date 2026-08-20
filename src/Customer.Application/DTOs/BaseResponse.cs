using System.Text.Json.Serialization;

namespace Customer.Application.DTOs
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object Data { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string> Notifications { get; set; }

        public BaseResponse() 
        {
            Notifications = new List<string>();
        }

        public void AddNotification(string notification)
        {
            Notifications.Add(notification);
            Success = false;
        }

    }
}
