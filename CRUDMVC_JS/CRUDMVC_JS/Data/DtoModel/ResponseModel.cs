namespace CRUDMVC_JS.Data.DtoModel
{
    public class ResponseModel<T>
    {
        /*Estructurar mejor la respuestas*/
        public string? message { get; set; }
        public T? Data { get; set; }
        public bool success { get; set; }
    }
}
