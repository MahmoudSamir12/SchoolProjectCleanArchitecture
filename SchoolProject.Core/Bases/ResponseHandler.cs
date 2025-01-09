using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;
using System.Net;

namespace SchoolProject.Core.Bases
{
    public class ResponseHandler
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        public ResponseHandler(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
        }

        public Response<T> Deleted<T>(string? message = null)
        {
            return CreateResponse<T>(HttpStatusCode.OK, true, message ??
                                            _localizer[SharedResourcesKeys.Deleted]);

            //return new Response<T>()
            //{
            //    StatusCode = System.Net.HttpStatusCode.OK,
            //    Succeeded = true,
            //    Message = Message == null ? "Deleted successfully" : Message
            //};
        }

        public Response<T> Success<T>(T entity, object? meta = null)
        {
            return CreateResponse<T>(HttpStatusCode.OK, true,
                                _localizer[SharedResourcesKeys.Success], meta, entity);
        }

        public Response<T> UnAuthorized<T>()
        {
            return CreateResponse<T>(HttpStatusCode.Unauthorized, false,
                                _localizer[SharedResourcesKeys.UnAuthorized]);
        }

        public Response<T> BadRequest<T>(string? message = null)
        {
            return CreateResponse<T>(HttpStatusCode.BadRequest, false,
                                message ?? _localizer[SharedResourcesKeys.BadRequest]);
        }

        public Response<T> UnprocessableEntity<T>(string? message = null)
        {
            return CreateResponse<T>(HttpStatusCode.UnprocessableEntity, false,
                                 message ?? _localizer[SharedResourcesKeys.UnprocessableEntity]);
        }
        public Response<T> NotFound<T>(string? message = null)
        {
            return CreateResponse<T>(HttpStatusCode.NotFound, false,
                                 message ?? _localizer[SharedResourcesKeys.NotFound]);
        }

        public Response<T> Created<T>(T entity, object? meta = null)
        {
            return CreateResponse<T>(HttpStatusCode.Created, true,
                                 _localizer[SharedResourcesKeys.Created], meta, entity);
        }

        // Private method to create a response, reducing code duplication
        private Response<T> CreateResponse<T>(HttpStatusCode statusCode, bool succeeded,
            string message, object? meta = null, T? data = default)
        {
            return new Response<T>
            {
                StatusCode = statusCode,
                Succeeded = succeeded,
                Message = message,
                Meta = meta,
                Data = data
            };
        }

    }
}
