﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.WebUICore.Middlewares
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder CustomStaticFiles(this IApplicationBuilder app)
        {

            var path = Path.Combine(Directory.GetCurrentDirectory(), "node_modules");

            var options = new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(path),
                RequestPath = "/modules"         //node_modules kasörü modules ismiyle kullanılsın.
            };

            app.UseStaticFiles(options);
            return app;
        }
    }
}
