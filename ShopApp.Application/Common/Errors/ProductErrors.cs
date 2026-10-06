using ShopApp.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ShopApp.Application.Common.Errors;

public static class ProductErrors
{
    public static Error NotFound= new("ProductNotFound","this product not found",404  );
}
