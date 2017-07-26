using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DedKorchma.BL.Infrastructure
{
    public class NotFoundException : Exception
    {
        public string Property { get; protected set; }
        public NotFoundException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}