using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExceptionLib
{
    public class OnlineSoppingException:Exception
    {
        public OnlineSoppingException(string errMsg):base(errMsg)
            {

            }
    }
}
