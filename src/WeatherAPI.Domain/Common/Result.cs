using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Domain.Common
{
    // Generic wrapper class that represents the outcome of an operation.
    // Used to encapsulate both the result data and operation status (success/failure) with optional error messages.    
    public class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public T? Data { get; private set; }
        public string? Error { get; private set; }

        private Result(bool isSuccess, T? data, string? error)
        {
            IsSuccess = isSuccess;
            Data = data;
            Error = error;
        }
        // Factory method to create a successful result
        public static Result<T> Success(T data) => new(true, data, null);
        // Factory method to create a failed result
        public static Result<T> Failure(string error) => new(false, default, error);
    }
}