using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Helper
{
    public interface IEmail
    {
        
        bool Send(string email , string assunto, string message);

    }
}