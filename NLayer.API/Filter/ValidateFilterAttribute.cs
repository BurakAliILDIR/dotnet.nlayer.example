using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NLayer.Core.DTO;

namespace NLayer.API.Filter
{
    public class ValidateFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
               
                var actionArgumentsKeys = context.ActionArguments.Keys;

                foreach (var key in actionArgumentsKeys)
                {
                    Console.WriteLine("deneme : " + key );
                }

                throw new NullReferenceException("Deneme 1");

                List<string> errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)
                    .ToList();

                // Başarısız olma durumu için ayrı custom response yazılabilir.
                context.Result = new BadRequestObjectResult(errors);
            }
        }
    }
}