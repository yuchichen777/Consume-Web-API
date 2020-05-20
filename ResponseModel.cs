namespace ConsoleApp
{
    public class ResponseModel<T>
    {
        public string IsOk { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
