using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using NLayer.Core.DTO;

namespace NLayer.Service.Validation
{
    public class ProductDTOValidator:AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required.").NotEmpty()
                .WithMessage("{PropertyName} is required.");
            
            RuleFor(x => x.Price).NotEqual(0).InclusiveBetween(1,int.MaxValue).WithMessage("{PropertyName} must be grather 0.");
            RuleFor(x => x.Stock).NotEqual(0).InclusiveBetween(0,int.MaxValue).WithMessage("{PropertyName} must be grather 0.");
            RuleFor(x => x.CategoryId).NotEqual(0).InclusiveBetween(0,int.MaxValue).WithMessage("{PropertyName} must be grather 0.");
        }
    }
}
