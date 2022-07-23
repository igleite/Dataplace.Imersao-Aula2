using Dataplace.Core.Domain.Events;
using Dataplace.Core.Domain.Query;
using Dataplace.Core.Shared.Catalog.Produto.Queries;
using Dataplace.Core.Shared.Catalog.Produto.ViewModels;
using Dataplace.Core.win.Views;
using Dataplace.Core.win.Views.Extensions;
using Dataplace.Imersao.Core.Application.Orcamentos.Commands;
using Dataplace.Imersao.Core.Application.Orcamentos.Events;
using Dataplace.Imersao.Core.Application.Orcamentos.Queries;
using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;
using Dataplace.Imersao.Core.Application.Produtos.Queries;
using Dataplace.Imersao.Core.Domain.Orcamentos.Repositories;
using Dataplace.Imersao.Core.Domain.Produtos.Repositories;
using Dataplace.Imersao.Core.Domain.Services;
using Dataplace.Imersao.Core.Infra.Data.Repositories;
using Dataplace.Imersao.Presentation.Views.Providers;
using dpLibrary05.Infrastructure.ServiceLocator;
using MediatR;
using System.Collections.Generic;

namespace Dataplace.Imersao.Presentation
{
    public static class BootStrapper
    {
        public static Container Container;
        public static void Bootstrap(Container container)
        {
            Container = container;

            // presentation - view provider
            Container.RegisterViewProvider<InterfaceView, OrcamentoViewProvider>();
            Container.RegisterViewProvider<InterfaceView, OrcamentoItemViewProvider>();


            // product - queries
            //IRequestHandler
            container.Register<IQueryHandler<ProdutoSearchQuery, IEnumerable<ProdutoSearchModel>>, ProdutoSerachQueryHandler>();
            container.Register<IQueryHandler<ProdutoVariacaoSearchQuery, IEnumerable<ProdutoSearchModel>>, ProdutoSerachQueryHandler>();
            container.Register<IQueryHandler<ProdutoGradeSearchQuery, IEnumerable<ProdutoSearchModel>>, ProdutoSerachQueryHandler>();


            // application - queries
            container.Register<IRequestHandler<OrcamentoQuery, IEnumerable<OrcamentoViewModel>>, OrcamentoQueryHandler>();
            container.Register<IRequestHandler<OrcamentoRefreshQuery, OrcamentoViewModel>, OrcamentoQueryHandler>();
            container.Register<IRequestHandler<OrcamentoMoveQuery, OrcamentoViewModel>, OrcamentoQueryHandler>();
            container.Register<IRequestHandler<OrcamentoItemQuery, IEnumerable<OrcamentoItemViewModel>>, OrcamentoQueryHandler>();
            container.Register<IRequestHandler<OrcamentoItemRefreshQuery, OrcamentoItemViewModel>, OrcamentoQueryHandler>();


            // application - commands
            Container.Register<IRequestHandler<AdicionarOrcamentoCommand, bool>, OrcamentoCommandHandler>();
            Container.Register<IRequestHandler<AtualizarOrcamentoCommand, bool>, OrcamentoCommandHandler >();
            Container.Register<IRequestHandler<ExcluirOrcamentoCommand, bool>, OrcamentoCommandHandler >();
            Container.Register<IRequestHandler<FecharOrcamentoCommand, bool>, OrcamentoCommandHandler >();
            Container.Register<IRequestHandler<ReabrirOrcamentoCommand, bool>, OrcamentoCommandHandler >();
            Container.Register<IRequestHandler<AdicionarOrcamentoItemCommand, bool>, OrcamentoCommandHandler>();
            Container.Register<IRequestHandler<AtualizarOrcamentoItemCommand, bool>, OrcamentoCommandHandler>();
            Container.Register<IRequestHandler<ExcluirOrcamentoItemCommand, bool>, OrcamentoCommandHandler>();


            // application - events
            Container.Register<INotificationHandler<OrcamentoAdicionadoEvent>, OrcamentoEventHandler>();
            Container.Register<INotificationHandler<OrcamentoAtualizadoEvent>, OrcamentoEventHandler>();
            Container.Register<INotificationHandler<OrcamentoExcluidoEvent>, OrcamentoEventHandler>();
            Container.Register<INotificationHandler<OrcamentoFechadoEvent>, OrcamentoEventHandler>();
            Container.Register<INotificationHandler<OrcamentoReabertoEvent>, OrcamentoEventHandler>();
            Container.Register<INotificationHandler<OrcamentoItemAdicionadoEvent>, OrcamentoEventHandler>();
            Container.Register<INotificationHandler<OrcamentoItemAtualizadoEvent>, OrcamentoEventHandler>();
            Container.Register<INotificationHandler<OrcamentoItemExcluidoEvent>, OrcamentoEventHandler>();


            // domain - services
            Container.Register<IOrcamentoService, OrcamentoService>();

            // domain - repositories
            Container.Register<IProdutoRepository, ProdutoRepository>();
            Container.Register<IOrcamentoRepository, OrcamentoRepository>();
            Container.Register<IOrcamentoItemRepository, OrcamentoItemRepository>();
        }
    }
}
