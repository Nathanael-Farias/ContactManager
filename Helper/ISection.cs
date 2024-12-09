using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthSystem.Models;

namespace AuthSystem.Helper
{
    public interface ISection
    {
        void CreateUserSection(UserModel user);
        void RemoveUserSection();
        UserModel FindUserSection();
    }
}