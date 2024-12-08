using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CalculaterApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpPost("add")]
        public ActionResult<decimal> Add(Calculation calculation)
        {
            var result = _calculatorService.Add(calculation);
            // Log the request and response
            using (var context = new LoggingContext())
            {
                var logEntry = new LogEntry
                {
                    Method = HttpContext.Request.Method,
                    Path = HttpContext.Request.Path,
                    Query = HttpContext.Request.QueryString.Value,
                    RequestBody = JsonSerializer.Serialize(calculation),
                    ResponseBody = result.ToString(),
                    Timestamp = DateTime.UtcNow
                };

                context.LogEntries.Add(logEntry);
                context.SaveChanges();
            }

            return Ok(result);
        }

        [HttpPost("subtract")]
        public ActionResult<decimal> Subtract(Calculation calculation)
        {
            var result = _calculatorService.Subtract(calculation);
            // Log the request and response
            using (var context = new LoggingContext())
            {
                var logEntry = new LogEntry
                {
                    Method = HttpContext.Request.Method,
                    Path = HttpContext.Request.Path,
                    Query = HttpContext.Request.QueryString.Value,
                    RequestBody = JsonSerializer.Serialize(calculation),
                    ResponseBody = result.ToString(),
                    Timestamp = DateTime.UtcNow
                };

                context.LogEntries.Add(logEntry);
                context.SaveChanges();
            }

            return Ok(result);
        }

        [HttpPost("multiply")]
        public ActionResult<decimal> Multiply(Calculation calculation)
        {
            var result = _calculatorService.Multiply(calculation);
            // Log the request and response
            using (var context = new LoggingContext())
            {
                var logEntry = new LogEntry
                {
                    Method = HttpContext.Request.Method,
                    Path = HttpContext.Request.Path,
                    Query = HttpContext.Request.QueryString.Value,
                    RequestBody = JsonSerializer.Serialize(calculation),
                    ResponseBody = result.ToString(),
                    Timestamp = DateTime.UtcNow
                };

                context.LogEntries.Add(logEntry);
                context.SaveChanges();
            }


            return Ok(result);
        }

        [HttpPost("divide")]
        public ActionResult<decimal> Divide(Calculation calculation)
        {
            try
            {
                var result = _calculatorService.Divide(calculation);
                // Log the request and response
                using (var context = new LoggingContext())
                {
                    var logEntry = new LogEntry
                    {
                        Method = HttpContext.Request.Method,
                        Path = HttpContext.Request.Path,
                        Query = HttpContext.Request.QueryString.Value,
                        RequestBody = JsonSerializer.Serialize(calculation),
                        ResponseBody = result.ToString(),
                        Timestamp = DateTime.UtcNow
                    };

                    context.LogEntries.Add(logEntry);
                    context.SaveChanges();
                }


                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}