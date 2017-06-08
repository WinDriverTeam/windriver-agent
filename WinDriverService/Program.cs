using System;
using System.Web.Http;
using Owin;
using Microsoft.Owin.Hosting;
using System.Net.Http;
using System.Collections.Generic;
using System.Net;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;

namespace WinDriverService
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "WinAuto/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string url = GetParamValue(args[0], "url=");
            string hub = GetParamValue(args[1], "hub=");
            // Start OWIN host 
            using (WebApp.Start<Startup>(url: url))
            {
                Console.WriteLine("driver agent - {0}", url);
                Console.WriteLine("hub controller - {0}", hub);
                var values = new NameValueCollection();
                values["nodeUrl"] = url;

                var client = new WebClient();
                var response = client.UploadValues(hub + "/register", values);

                var responseString = Encoding.Default.GetString(response);
                Console.WriteLine(responseString);

                Console.WriteLine("CONGRATS!!! You've launched WinDriver on {0} ...", url);
                Console.ReadLine();
            }
        }
        static String GetParamValue(string param, string pattern)
        {
            string value = Regex.Replace(param, pattern, String.Empty);
            return value;
        }
    }
}
