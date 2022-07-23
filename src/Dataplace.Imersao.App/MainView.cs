using Dataplace.Core.Infra.CrossCutting.EventAggregator.Contracts;
using Dataplace.Core.win.Views;
using Dataplace.Imersao.Presentation.Views.Providers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace Dataplace.Imersao.App
{
    public partial class MainView : dpLibrary05.fMNU_Principal
    {
        private readonly IServiceProvider serviceProvider;

        public MainView(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            AddMenu(new ToolStripMenuItem("Orcamento", null, (object sender, EventArgs e) => {
                Dataplace.Core.win.Views.Managers.ViewManager.ShowViewOnForm<InterfaceView, OrcamentoViewProvider>();
            }), TipoMenuEnun.Arquivo);

            this.serviceProvider = serviceProvider;


            using (var scope = serviceProvider.CreateScope())
            {
               

            }
        }
    }
}
