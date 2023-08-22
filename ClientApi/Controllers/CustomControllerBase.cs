using ClientApi.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ClientApi.Controllers
{

    public class CustomControllerBase : ControllerBase
    {
        //private protected string GetLoggedInUserId()
        //{
        //    return (User?.FindFirstValue("id")) ?? string.Empty;
        //}

        protected IActionResult OkResult(object data, string? message = null)
        {
            var response = new ResponsePayloadDto<object>
            {
                Message = !string.IsNullOrEmpty(message) ? message : "Success",
                StatusCode = StatusCodes.Status200OK,
                Results = data
            };
            return Ok(response);
        }

        protected IActionResult NotFoundResult(string? message = null)
        {
            var response = new ResponsePayloadDto<object>
            {
                StatusCode = StatusCodes.Status404NotFound,
                Results = false,
                Message = !string.IsNullOrEmpty(message) ? message : "Resource not found"
            };
            return NotFound(response);
        }

        protected IActionResult ConflictResult(string? message = null)
        {
            var response = new ResponsePayloadDto<object>
            {
                StatusCode = StatusCodes.Status409Conflict,
                Results = false,
                Message = message
            };
            return NotFound(response);
        }

        protected IActionResult ServerErrorResult(string? message = null)
        {
            var response = new ResponsePayloadDto<object>
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Results = false,
                Message = !string.IsNullOrEmpty(message) ? message : "Something went wrong"
            };
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }

        public static BadRequestObjectResult InvalidRequestPayload(string message = "")
        {
            var response = new ResponsePayloadDto<bool>
            {
                Results = false,
                StatusCode = StatusCodes.Status400BadRequest,
                Message = $"Invalid request payload."
            };

            if (!string.IsNullOrEmpty(message))
                response.Message += $" Error: {message}";

            return new BadRequestObjectResult(response);
        }


    }
}
