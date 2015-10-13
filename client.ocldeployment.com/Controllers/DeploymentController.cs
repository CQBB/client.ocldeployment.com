using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using client.ocldeployment.com.Models;
using client.ocldeployment.com.ServiceHelper;
using System.Threading;
using client.ocldeployment.com.AsyncLock;

namespace client.ocldeployment.com.Controllers
{
    public class DeploymentController : Controller
    {
        //
        // GET: /Deployment/
        private BatRESTService service = new BatRESTService();
        //The URLs of the live servers
        private string[] serverUrlsandNames = new string[10]{ 
        "http://vpn.web01.ocldeployment.com//api//BatExecution//",
        "http://vpn.web02.ocldeployment.com//api//BatExecution//",
        "http://vpn.web03.ocldeployment.com//api//BatExecution//",
        "http://vpn.web04.ocldeployment.com//api//BatExecution//",
        "http://vpn.stage.ocldeployment.com//api//BatExecution//",
        "<br><b>Deploy to Web01:</b><br>",
        "<br><b>Deploy to Web02:</b><br>",
        "<br><b>Deploy to Web03:</b><br>",
        "<br><b>Deploy to Web04:</b><br>",
        "<br><b>Deploy to Stage:</b><br>"};

        private client.ocldeployment.com.AsyncLock.AsyncLock _asyncLock = new AsyncLock.AsyncLock();
        
        public ActionResult Index()
        {

            return View();
        }

        public async Task<ActionResult> GetResult(string siteId, string serverId)        
        {
            int id = Convert.ToInt32(serverId);
            string uri = serverUrlsandNames[id] + siteId;
            BatExecInfo batinfo = await service.GetBatsAsync(uri);
            batinfo.BatExecResult.Insert(0,serverUrlsandNames[id+5]);
            batinfo.BatExecResult.Insert(0,"<div id='div_closemodal'></div>");
            return PartialView("_PartialDeploymentResult",batinfo);
        }

        public ActionResult TestModal()
        {
            return View();
        }

        //public async Task<ActionResult> Result(int id, int isLive)
        //{
           
        //        if (isLive == 0)
        //        {
        //            using (var releaser = await _asyncLock.LockAsync())
        //            {
        //                string uri = "http://vpn.stage.ocldeployment.com//api//BatExecution//" + id;
        //                BatExecInfo batinfo = await service.GetBatsAsync(uri);                 
        //                ViewBag.results = batinfo.BatExecResult;
        //            }
        //        }
        //        else
        //        {
        //            using (var releaser = await _asyncLock.LockAsync())
        //            {
        //                List<string> results = new List<string>();
        //                BatExecInfo batinfo = new BatExecInfo();
        //                switch (id)// deploy ce.nurse.com or www.continudingeducation.com
        //                {
        //                    case 1:
        //                    case 2:
        //                    case 3:
        //                    case 4:
        //                    case 5:
        //                    case 6:
        //                    case 7:
        //                        {
        //                            //deploy to web01
        //                            batinfo = await service.GetBatsAsync(liveurls[0] + id);
        //                            results.Add("<b>Deploy to web01</b><br>");
        //                            results.AddRange(batinfo.BatExecResult);
        //                            ViewBag.results = results;                                  
                                    
        //                            //deploy to web02
        //                            batinfo = await service.GetBatsAsync(liveurls[1] + id);
        //                            results.Add("<br><b>Deploy to web02</b><br>");
        //                            results.AddRange(batinfo.BatExecResult);
        //                            ViewBag.results = results;                                  

        //                            //deploy to web03
        //                            batinfo = await service.GetBatsAsync(liveurls[2] + id);
        //                            results.Add("<br><b>Deploy to web03</b><br>");
        //                            results.AddRange(batinfo.BatExecResult);
        //                            ViewBag.results = results;

        //                            //deploy to web04
        //                            batinfo = await service.GetBatsAsync(liveurls[3] + id);
        //                            results.Add("<br><b>Deploy to web04</b><br>");
        //                            results.AddRange(batinfo.BatExecResult);
        //                            ViewBag.results = results;

        //                            break;
        //                        }
        //                    case 0:
        //                    case 8:
        //                    case 9:
        //                    case 10:
        //                        {
        //                            //deploy to web03
        //                            batinfo = await service.GetBatsAsync(liveurls[2] + id);
        //                            results.Add("<b>Deploy to web03</b><br>");
        //                            results.AddRange(batinfo.BatExecResult);


        //                            //deploy to web04
        //                            batinfo = await service.GetBatsAsync(liveurls[3] + id);
        //                            results.Add("<br><b>Deploy to web04</b><br>");
        //                            results.AddRange(batinfo.BatExecResult);


        //                            break;
        //                        }
        //                } 
        //                ViewBag.results = results;
        //            }
        //        }

        //        return View("index");
            
        //}
      
        


    }

}