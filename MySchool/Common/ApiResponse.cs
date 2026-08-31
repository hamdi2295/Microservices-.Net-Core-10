namespace MySchool.Common
{
    public class ApiResponse<T>
    {
        public Metadata Metadata { get; set; } = new();
        public T? Data { get; set; }
    }

    public class Metadata
    {
        public bool Success { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
