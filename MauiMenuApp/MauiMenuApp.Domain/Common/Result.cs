using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MauiMenuApp.Domain.Common
{
    public class Result
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get { return Errors.Count == 0; } }
        public string Message { get; set; }
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