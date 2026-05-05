namespace OnionApp.WebUI.Base
{
    public class BaseResult<T>
    {
        public T? Data { get; set; }

        public List<Error>? Errors { get; set; }

        public bool IsSuccessful => Errors == null || !Errors.Any();

        public bool IsFailure => !IsSuccessful;
    }

    public class Error
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}