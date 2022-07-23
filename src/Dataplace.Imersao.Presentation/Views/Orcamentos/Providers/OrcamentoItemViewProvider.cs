using Dataplace.Core.Comunications;
using Dataplace.Core.Domain.Localization.Messages.Extensions;
using Dataplace.Core.Infra.CrossCutting.EventAggregator.Contracts;
using Dataplace.Core.win.Controls.Behaviors.Contracts;
using Dataplace.Core.win.Controls.Components.ProductSearch.Behaviors;
using Dataplace.Core.win.Views.Controllers;
using Dataplace.Core.win.Views.Providers;
using Dataplace.Core.win.Views.Providers.Configurations;
using Dataplace.Core.win.Views.Providers.Contracts;
using Dataplace.Imersao.Core.Application.Orcamentos.Commands;
using Dataplace.Imersao.Core.Application.Orcamentos.Queries;
using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;
using Dataplace.Imersao.Core.Domain.Orcamentos.Enums;
using Dataplace.Imersao.Presentation.Views.Orcamentos;
using Dataplace.Imersao.Presentation.Views.Orcamentos.Behaviors;
using Dataplace.Imersao.Presentation.Views.Orcamentos.Messages;
using System;

namespace Dataplace.Imersao.Presentation.Views.Providers
{
    public class OrcamentoItemViewProvider :  RegisterViewProvider<OrcamentoItemViewModel, OrcamentoItemQuery>, 
        IDisposable, 
        IRegisterViewProvider<OrcamentoItemViewModel, OrcamentoItemQuery>,
        ISubscriber<OrcamentoAdicionadoMessage>
    {

        #region fields
        private OrcamentoViewModel _orcamento;
        private readonly IEventAggregator _eventAggregator;
        #endregion

        #region contructors
        public OrcamentoItemViewProvider(IServiceProvider serviceProvider, IMediatorHandler mediatorHandler, IEventAggregator eventAggregator) : base(serviceProvider, mediatorHandler)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.SubscribeMe(this);
            this.AfterAdd += (object sender, Dataplace.Core.win.Controls.Delegates.AfterAddEventArgs<OrcamentoItemViewModel> e) =>
            {
                e.Property = nameof(OrcamentoItemViewModel.CdProduto);
            };

            this.OnInit += (object sender, EventArgs e) =>
            {
                this.RegisterViewController.View.Disposed += (object _sender, EventArgs _e) =>
                {
                    this.Dispose();
                };

                this.OnParameterChange<OrcamentoViewModel>(x => {
                    _orcamento = x;
                    if (_orcamento == null)
                        Clear();
                    else
                        Load();
                });
            };
        }
        #endregion

        #region methods
        public override void Configure(RegisterViewConfigurationBuilder<OrcamentoItemViewModel, OrcamentoItemQuery> builder)
        {
            // base
            builder.HasCaption(18845.ToMessage());
            builder.HasSecurityId(467);

            // views
            builder.UseList(listBuilder =>
            {
          
                listBuilder.WithQuery<OrcamentoItemQuery>(() => {
                    return new OrcamentoItemQuery() { NumOrcamento = _orcamento.NumOrcamento };
                });

                listBuilder.Ignore(x => x.CdEmpresa);
                listBuilder.Ignore(x => x.CdFilial);
                listBuilder.Ignore(x => x.NumOrcamento);
        
                listBuilder.Ignore(x => x.Status);

                listBuilder.Property(x => x.Seq)
                    .HasCaption("#");

                listBuilder.Property(x => x.TpRegistro)
                    .HasCaption("Tipo")
                    .HasValueItems(x =>
                    {
                        x.Add(TpRegistroEnum.ProdutoFinal.ToDataValue(), 4552.ToMessage());
                        x.Add(TpRegistroEnum.SubProduto.ToDataValue(), 4539.ToMessage());
                        x.Add(TpRegistroEnum.MateriaPrima.ToDataValue() , 11207.ToMessage());
                        x.Add(TpRegistroEnum.Componente.ToDataValue(), 4538.ToMessage());
                        x.Add(TpRegistroEnum.Servico.ToDataValue(), 3047.ToMessage());
                        x.Add(TpRegistroEnum.BemDeConsumo.ToDataValue() , 21779.ToMessage());
                    });

                listBuilder.Property(x => x.CdProduto)
                    .HasCaption("Código")
                    .AllowEdit();

                listBuilder.Property(x => x.DsProduto)
                    .HasCaption("Descrição")
                    .AllowEdit();


                listBuilder.Property(x => x.Quantidade)
                    .HasCaption(16902.ToMessage())
                    .HasFormat("#,##0.00")
                    .AllowEdit(opt =>
                    {
                        opt.CanEdit(x => true);
                    });

                listBuilder.Property(x => x.PrecoTabela)
                    .HasCaption("Preco tabela")
                    .HasFormat("n");

                listBuilder.Property(x => x.PrecoVenda)
                    .HasCaption("Preco venda")
                    .HasFormat("n");

                listBuilder.Property(x => x.Total)
                    .HasCaption("Valor total")
                    .HasFormat("n");

                //listBuilder.Property(x => x.CdProduto)
                //    .HasCaption("Código");


                listBuilder
                   .WithBehavior(x =>
                   {
                       x.Add(GetProdutoSearchBehavior());
                       x.Add(GetFastInputGridBehavior());
                   });


                listBuilder.AllowUpdate();

            });
            //builder.UseLayoutView<OrcamentoItemView>();



            // output
            builder.WithQueryItem<OrcamentoItemRefreshQuery>(q =>
            {
                q.NumOrcamento = q.CurrentItem.NumOrcamento;
                q.Seq = q.CurrentItem.Seq;
            });
    

            // inputs
            builder.OnInsertItem((x, c) => {
                
                x.CdEmpresa = _orcamento.CdEmpresa;
                x.CdFilial = _orcamento.CdFilial;
                x.NumOrcamento = _orcamento.NumOrcamento;

            });
            builder.WithRegisterCommand<AdicionarOrcamentoItemCommand>();
            builder.WithUpdateCommand<AtualizarOrcamentoItemCommand>();
            builder.WithDeleteCommand<ExcluirOrcamentoItemCommand>();

        }
        private IBehavior GetProdutoSearchBehavior()
        {
            var r = new ProductSearchGridBehavior(
                                () => new ProductSearchGridBehavior.ProductSearchGridConfiguration(
                                            this.Grid,
                                            this.Grid.Splits[0].DisplayColumns[nameof(OrcamentoItemViewModel.TpRegistro)],
                                            this.Grid.Splits[0].DisplayColumns[nameof(OrcamentoItemViewModel.CdProduto)],
                                            this.Grid.Splits[0].DisplayColumns[nameof(OrcamentoItemViewModel.DsProduto)],
                                            this.Grid.Splits[0].DisplayColumns[nameof(OrcamentoItemViewModel.Quantidade)])
                                {
                                    SetaAzulMethod = (value) =>
                                    {
                                        dpLibrary05.Infrastructure.Helpers.SetaAzulCall.SetaAzulConfigurationRepository.ProdutoServico(value.Item2, value.Item1).Execute();
                                    }
                                }
                            );

            r.SearchResult += (object sender, Dataplace.Core.win.Controls.Components.ProductSearch.Delegates.SearchResultEventArgs e) =>
            {
                //_eventAggregator.PublishEvent(e.Result);

                var _item = GetItem();
                if (_item == null)
                    return;

                _item.TpRegistro = e.Result.TpRegistro;
                _item.CdProduto = e.Result.CdProduto;
                _item.DsProduto = e.Result.DsProduto;

            };

            return r;
        }
        private IBehavior GetFastInputGridBehavior()
        {
            var r = new FastInputGridBehavior(
                               () => new FastInputGridBehavior.Configuration( this.RegisterViewController , this.Grid, this.Grid.Splits[0].DisplayColumns[nameof(OrcamentoItemViewModel.Quantidade)])
                           );

            return r;
        }

        #endregion

        #region messages
        public void OnEventHandler(OrcamentoAdicionadoMessage e)
        {
            this.Add();
        }
        #endregion

        #region dispose
        public bool IsDisposed { get; set; }
        public void Dispose()
        {
            IsDisposed = true;
        }
        #endregion

    }
}
