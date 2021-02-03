using OnlineBusiness;
using OnlineEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineWebAPI.Controllers
{
    public class SecurityController : ApiController
    {
        [Route("api/Security/GetUserName/{name}")]
        public Login1 GetUserName(string name)
        {
            BusinessLib bll = new BusinessLib();
            var username = bll.GetUserName(name);
            return username;
        }

        [Route("api/Security/GetPassword/{pwd}")]
        public Login1 GetPassword(string pwd)
        {
            BusinessLib bll = new BusinessLib();
            var pswd= bll.GetPassword(pwd);
            return pswd;
        }
    }
}
