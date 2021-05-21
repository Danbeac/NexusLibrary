namespace NexusLibrary.API.Responses
{
    public class Response<T>
    {
        public T Data { get; set; }

        public Response(T data)
        {
            Data = data;
        }
    }
}
