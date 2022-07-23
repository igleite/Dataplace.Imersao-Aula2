using Dataplace.Core;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dataplace.Imersao.App
{
    internal static class Program
    {



        //[STAThread]
        //static void Main(string[] args)
        //{
        //    Application.EnableVisualStyles();
        //    dpLibrary05.BootStrapper.CreateContainer();
        //    Dataplace.Core.win.BootStrapper.Bootstrap(dpLibrary05.BootStrapper.Container);
        //    Dataplace.Imersao.Presentation.BootStrapper.Bootstrap(dpLibrary05.BootStrapper.Container);
        //    Dataplace.Imersao.Core.Infra.BootStrapper.Bootstrap(dpLibrary05.BootStrapper.Container);
        //    var main = new MainView();
        //    CreateApp("SALESAPP", SymphonyApplication.EnumMenuType.Basic, main);
        //    SymphonyApp.ValidaLogin = true;
        //    if (SymphonyApp.LoadApplication())
        //    {
        //        System.Windows.Forms.Application.Run(SymphonyApp.MainForm);
        //    }
        //}

        [STAThread]
        static void Main(string[] args)
        {
            var builder = Dataplace.Core.DataplaceApplication.CreateBuilder(args)
                .UseAppName("SALESAPP")
                .UseLayout(AppLayoutEnum.Basic);

            ConfigureServices(builder.Services);
            Dataplace.Imersao.Presentation.BootStrapper.Bootstrap(dpLibrary05.BootStrapper.Container);
            Dataplace.Imersao.Core.Infra.BootStrapper.Bootstrap(dpLibrary05.BootStrapper.Container);

            var app = builder.Build();
            app.Run<MainView>();

        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MainView>();
        }

    }

}
