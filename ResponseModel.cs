using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ResponseModel<T>
    {
        public string Message { get; set; }
        public int HttpStatusCode { get; set; }
        public List<T> Data { get; set; }
    }
}
