using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace OnionApp.Application.Base
{
    public class BaseResult<T>
    {
        public T? Data { get; set; }

        public List<Error>? Errors { get; set; }

        public bool IsSuccessful => Errors == null || !Errors.Any();

        public bool IsFailure => !IsSuccessful;

        public static BaseResult<T> Success(T? data)
        {
            return new BaseResult<T>
            {
                Data = data,
                Errors = null
            };
        }

        public static BaseResult<T> Success()
        {
            return new BaseResult<T>
            {
                Errors = null
            };
        }

        public static BaseResult<T> Fail(string message)
        {
            return new BaseResult<T>
            {
                Errors = new List<Error>
                {
                    new Error
                    {
                        PropertyName = "",
                        ErrorMessage = message
                    }
                }
            };
        }

        public static BaseResult<T> Fail(List<ValidationFailure> validationErrors)
        {
            return new BaseResult<T>
            {
                Errors = validationErrors.Select(e => new Error
                {
                    PropertyName = e.PropertyName,
                    ErrorMessage = e.ErrorMessage
                }).ToList()
            };
        }

        public static BaseResult<T> Fail(IEnumerable<IdentityError> identityErrors)
        {
            return new BaseResult<T>
            {
                Errors = identityErrors.Select(e => new Error
                {
                    PropertyName = e.Code,
                    ErrorMessage = e.Description
                }).ToList()
            };
        }
    }

    public class Error
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}