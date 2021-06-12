using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.IO;
using ProcesoTareas.Models;

namespace ProcesoTareas.Controllers
{
    public class BaseController : Controller
    {
        public void Notify(string message, string title = "Alerta:",
                                    NotificationType notificationType = NotificationType.success)
        {
            var msg = new
            {
                message = message,
                title = title,
                icon = notificationType.ToString(),
                type = notificationType.ToString(),
                provider = GetProvider()
            };

            TempData["Message"] = JsonConvert.SerializeObject(msg);
        }

        private string GetProvider()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();

            var value = configuration["NotificationProvider"];

            return value;
        }
    }
}
