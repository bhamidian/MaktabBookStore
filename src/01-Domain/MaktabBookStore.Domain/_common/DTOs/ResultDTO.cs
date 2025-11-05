using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaktabBookStore.Domain._common.DTOs
{
    public class ResultDTO<T>
    {
        public string? Message { get; set; }
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }

        public static ResultDTO<T> Success(string message = "", T? data = default) =>
            new() { IsSuccess = true, Message = message, Data = data };

        public static ResultDTO<T> Fail(string message = "", T? data = default) =>
            new() { IsSuccess = false, Message = message, Data = data };
    }
}