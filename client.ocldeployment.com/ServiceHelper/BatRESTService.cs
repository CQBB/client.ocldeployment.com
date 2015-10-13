using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using client.ocldeployment.com.Models;
using System.Net;
using Newtonsoft.Json;

namespace client.ocldeployment.com.ServiceHelper
{
    public class BatRESTService{
        
        //get the bat. execution result
        public async Task<BatExecInfo> GetBatsAsync(string uri)
        {

            using (HttpClient httpClient = new HttpClient())
            {

                return JsonConvert.DeserializeObject<BatExecInfo > (
                    await httpClient.GetStringAsync(uri)
                );
            }
        }
    }
}