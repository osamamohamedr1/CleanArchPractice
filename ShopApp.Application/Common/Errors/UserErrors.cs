using ShopApp.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Application.Common.Errors;

public static class UserError
{
    public static Error NotFound = new(Code: "UserNotFound", "The specified user was not found.",404);
    public static Error InvalidCredentials = new(Code: "InvalidCredentials", "User name or password in incorrect", 404);
    public static Error InvalidToken = new(Code: "InvalidToken", "The provided token is invalid.", 401);
}