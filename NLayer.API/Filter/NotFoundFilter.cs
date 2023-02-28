using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayer.Core.DTO;
using NLayer.Core.Entity;
using NLayer.Core.Service;

namespace NLayer.API.Filter
{
    /*
     *  Kullanımı: Action'ların başına aynı attribute gibi ama [ServiceFilter()] ile olmak zorunda,
     *
     *  [ServiceFilter(type: typeof(NotFoundFilter<Product>))]
     */

    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();

            if (idValue != null)
            {
                var id = (int)idValue;
                var any = await _service.AnyAsync(x => x.Id == id);
                if (!any)
                {
                    context.Result =
                        new NotFoundObjectResult(CustomResponseDTO<T>.Error(404, $"{typeof(T).Name} not found."));
                }
            }

            _ = next.Invoke();
        }
    }
}