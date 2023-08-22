namespace ClientApi.DTO
{
    public class ResponsePayloadDto<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T? Results { get; set; }
    }
}
