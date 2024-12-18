using System.Text.Json;
using AuthSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuthSystem.Filters
{
    public class RestrictPageOnlyAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            string userSection = context.HttpContext.Session.GetString("UserLoggedSection");
            if(string.IsNullOrEmpty(userSection))
            {

                context.Result = new RedirectToRouteResult(new RouteValueDictionary{ {"controller","Login" },{"action","Index" } });

            }
            else
            {

                    UserModel user = JsonSerializer.Deserialize<UserModel>(userSection);

                if(user == null)
                {

                 context.Result = new RedirectToRouteResult(new RouteValueDictionary{ {"controller","Login" },{"action","Index" } });

                }
                if(user.Profile != Enums.EnumProfile.Admin)
                {
                 context.Result = new RedirectToRouteResult(new RouteValueDictionary{ {"controller","Restrict" },{"action","Index" } });

                }

            }




            base.OnActionExecuting(context);
        }
    }
}