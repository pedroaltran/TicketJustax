using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace TicketsAPI.Api.Filters
{
    public class RequestFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                TokenData.Clear();

                var access_code = context.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
                var tkn = new JwtSecurityToken(access_code);

                TokenData.UserId = Convert.ToInt64(tkn.Claims.Where(m => m.Type == "UserId").Select(n => n.Value).FirstOrDefault());
                TokenData.UserEmail = tkn.Claims.Where(m => m.Type == "email").Select(n => n.Value).FirstOrDefault();
                TokenData.UserFullName = tkn.Claims.Where(m => m.Type == "UserFullName").Select(n => n.Value).FirstOrDefault();
            }

            base.OnActionExecuting(context);
        }
    }
}
