namespace FarmaControlAPI.Https.Responses
{
    public class Response<T> : ApiResponse
    {
        public T? Data { get; set; }
    }
}
