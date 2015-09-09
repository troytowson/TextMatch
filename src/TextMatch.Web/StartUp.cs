using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Newtonsoft.Json.Serialization;
using Owin;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using System.Web.Http.ValueProviders.Providers;
using TextMatch.Services;

namespace TextMatch
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            var serverFiles = new FileServerOptions
            {
                FileSystem = new PhysicalFileSystem(@"..\..\wwwroot\"),
                EnableDirectoryBrowsing = false,
                EnableDefaultFiles = true,
            };
            serverFiles.DefaultFilesOptions.DefaultFileNames.Add("index.html");

            app.UseFileServer(serverFiles);

            var configuration = new HttpConfiguration();
            configuration.MapHttpAttributeRoutes();
            configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            Register(configuration);
            app.UseWebApi(configuration);
        }

        private void Register(HttpConfiguration config)
        {
            var container = new Container(cfg =>
            {
                cfg.For<ITextMatchingService>().Use<TextMatchingService>();
            });
            config.DependencyResolver = new StructuremapResolver(container, false);
        }
    }
}
