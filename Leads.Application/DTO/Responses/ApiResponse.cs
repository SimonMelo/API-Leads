using System.Net;

namespace Leads.Application.DTO.Responses
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
        public string DetailsResponse { get; set; }

        public ApiResponse(bool Success, T? Data, HttpStatusCode Status, string Message, string DetailsResponse)
        {
            this.Success = Success;
            this.Data = Data;
            this.Status = Status;
            this.Message = Message;
            this.DetailsResponse = DetailsResponse;
        }
    }
}
