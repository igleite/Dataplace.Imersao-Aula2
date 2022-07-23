using Dataplace.Core.Comunications;
using Dataplace.Core.Infra.CrossCutting.EventAggregator.Contracts;
using Dataplace.Core.win.Controls.Commands;
using Dataplace.Core.win.Views.Providers;
using Dataplace.Core.win.Views.Providers.Configurations;
using Dataplace.Core.win.Views.Providers.Contracts;
using Dataplace.Imersao.Core.Application.Orcamentos.Commands;
using Dataplace.Imersao.Core.Application.Orcamentos.Queries;
using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;
using Dataplace.Imersao.Presentation.Views.Orcamentos;
using System;

namespace Dataplace.Imersao.Presentation.Views.Providers
{
    public class OrcamentoViewProvider : RegisterViewProvider<OrcamentoViewModel, OrcamentoQuery>, IRegisterViewProvider<OrcamentoViewModel, OrcamentoQuery>
    {
        #region fields

        #endregion


        #region contructors
        public OrcamentoViewProvider(IServiceProvider serviceProvider, IMediatorHandler mediatorHandler, IEventAggregator eventAggregator) : base(serviceProvider,mediatorHandler)
        {

        }
        #endregion


        #region methods
        public override void Configure(RegisterViewConfigurationBuilder<OrcamentoViewModel, OrcamentoQuery> builder)
        {

            builder.HasCaption("Orçamentos");
            builder.HasSecurityId(467);

            // views
            builder.UseLayoutView<OrcamentoView>();
            builder.WithSearch(opt =>
            {
                opt.Add(new DelegateCommand("Pesquisa", (p) => this.Search(), (p) => true));
            });


            // output
            builder.WithQueryItem<OrcamentoRefreshQuery>(q =>
            {
                q.NumOrcamento = q.CurrentItem.NumOrcamento;
            });
            builder.WithQueryMove<OrcamentoMoveQuery>(q =>
            {
                
            });

            // inputs
            builder.OnInsertItem((x, c) => {

                x.CdEmpresa = dpLibrary05.mGenerico.SymPRM.cdempresa;
                x.CdFilial = dpLibrary05.mGenerico.SymPRM.cdfilial;

            });
            builder.WithRegisterCommand<AdicionarOrcamentoCommand>();
            builder.WithUpdateCommand<AtualizarOrcamentoCommand>();
            builder.WithDeleteCommand<ExcluirOrcamentoCommand>();


            // tools
            //builder.WithTools(options =>
            //{
            //    options
            //        .Add(TOOL_VISUALIZAR_IMPOSTO, new DelegateCommand($"{64527} {"(Alt + V)"}", (p) => VisualizarImpostos()))
                   

        }
        #endregion



    }
}
