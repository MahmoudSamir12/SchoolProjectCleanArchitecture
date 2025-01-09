using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Bases
{
    public class Response<T>
    {
        public Response()
        {
            // Default constructor with property initialization
            Succeeded = false;
            Errors = new List<string>();
        }
        public Response(T data, string? message = null) : this()// Call to the default constructor to initialize default values
        {
            Succeeded = true;
            Message = message;
            Data = data;
            StatusCode = HttpStatusCode.OK; // Default for successful responses
        } 
        public Response(string message, bool succeeded) : this()
        {
            Succeeded = succeeded;
            Message = message;
            StatusCode = succeeded ? HttpStatusCode.OK : HttpStatusCode.BadRequest; // Default based on successs
        }

        public HttpStatusCode StatusCode { get; set; }
        public bool Succeeded { get; set; }
        public string? Message { get; set; }
        public object? Meta { get; set; }
        public List<string> Errors { get; set; }
        public T? Data { get; set; }
    }
}
