namespace GlobalData.Common
{
    public class ResponseDto<T>
    {
        public T Result { get; set; }
        public string ErrorMessage { get; set; }
    }
}
