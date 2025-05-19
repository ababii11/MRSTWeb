using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.Interfaces
{
    public interface ISession
    {
        SessionResponse UserLogin(ULoginData data);
        SessionResponse RegisterUser(User model);
    }

    public class SessionResponse
    {
        public bool Status { get; set; }
        public string StatusMsg { get; set; }
        public User User { get; set; }
    }
}
