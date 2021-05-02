namespace Models.DTO
{
    public class ResultResponseViewModel
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
    }

    public class ResultResponseViewModel<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
    }
}
