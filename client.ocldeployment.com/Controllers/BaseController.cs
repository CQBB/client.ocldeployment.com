using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace client.ocldeployment.com.Controllers
{
    public class BaseController : Controller
    {
        public void Flush(ActionResult result)
        {
            result.ExecuteResult(ControllerContext);
            Response.Flush();
        }


    }
}
