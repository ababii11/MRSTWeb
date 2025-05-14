using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic
{
    public class SessionBL : UserApi, ISession
    {
        public dynamic UserLogin(ULoginData data)
        {
            return new
            {
                Status = true,
                StatusMsg = "Login successful"
            };
        }
    }
}
