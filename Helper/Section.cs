using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AuthSystem.Models;



namespace AuthSystem.Helper
{
    public class Section : ISection
    {

        private readonly IHttpContextAccessor _httpContext;

        public Section(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public void CreateUserSection(UserModel user)
        {
            string value = JsonSerializer.Serialize(user);
            _httpContext.HttpContext.Session.SetString("UserLoggedSection", value );
        }

        public UserModel FindUserSection()
        {
            string UserSection = _httpContext.HttpContext.Session.GetString("UserLoggedSection");
            if(string.IsNullOrEmpty(UserSection)) return null;
            return JsonSerializer.Deserialize<UserModel>(UserSection);
        }

        public void RemoveUserSection()
        {
            
            _httpContext.HttpContext.Session.Remove("UserLoggedSection");

        }
    }
}