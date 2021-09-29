using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActorsRazorPagesSample
{
    public static class ApplicationBuilderExtensions
    {
        public static void ValidarParametro(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/Actors/Details" && !context.Request.Query.ContainsKey("Id"))
                {
                    await context.Response.WriteAsync("Id é obrigatório");
                }
                else
                {
                    await next.Invoke();
                }                
            });
        }

        public static void ExibirDocumentacao(this IApplicationBuilder app)
        {
            app.Map("/documentacao", action =>
            {
                action.Run(async (context) =>
                {
                    await context.Response.WriteAsync("documentação solicitada");
                });
            });
        }
    }
}
