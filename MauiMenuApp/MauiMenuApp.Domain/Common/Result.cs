﻿using System.Net;

namespace MauiMenuApp.Domain.Common
{
    public class Result
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get { return Errors.Count == 0; } }
        public List<Error> Errors { get; set; } = new();
    }

    public class Result<TValue> : Result
    {
        private TValue? _value;
        public Result()
        {
            _value = default;
            Errors = new();
        }
        public TValue? Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
    }
}