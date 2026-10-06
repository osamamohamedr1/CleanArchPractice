using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Application.Products.Dtos;

public record ProductDto(Guid Id, string Name, decimal Price);
