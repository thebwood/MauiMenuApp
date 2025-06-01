using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiMenuApp.Domain.Common
{
    public class Error
    {
        public string Code { get; set; }
        public string Name { get; set; }


        public Error(string code, string name)

        {
            Code = code;
            Name = name;
        }

    }
}