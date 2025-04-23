namespace MVCCORE_CRUD.Data.DtoModel
{
    public class ResponseModel<T>
    {
        public string? message { get; set; }
        public T? Data { get; set; }
        public bool success { get; set; }

    }
}
