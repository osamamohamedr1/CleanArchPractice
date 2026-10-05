using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Application.Products.Commands.CreateProduct;

public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Product name is required.");
        RuleFor(x => x.Price).NotEmpty().GreaterThan(0).WithMessage("Product price must be greater than zero.");
    }
}
