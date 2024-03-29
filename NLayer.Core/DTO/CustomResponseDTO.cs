﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayer.Core.DTO
{
    public class CustomResponseDTO<T>

    {
        public T Data { get; set; }
        [JsonIgnore] public int StatusCode { get; set; }
        public List<String> Errors { get; set; }

        public static CustomResponseDTO<T> Success(T data, int statusCode)
        {
            return new CustomResponseDTO<T>() { Data = data, StatusCode = statusCode };
        }

        public static CustomResponseDTO<T> Success(IEnumerable<ProductDTO> products, int statusCode)
        {
            return new CustomResponseDTO<T>() { StatusCode = statusCode };
        }

        public static CustomResponseDTO<T> Error(int statusCode, List<String> errors)
        {
            return new CustomResponseDTO<T>() { StatusCode = statusCode, Errors = errors };
        }

        public static CustomResponseDTO<T> Error(int statusCode, String error)
        {
            return new CustomResponseDTO<T>() { StatusCode = statusCode, Errors = new List<string>() { error } };
        }
    }
}