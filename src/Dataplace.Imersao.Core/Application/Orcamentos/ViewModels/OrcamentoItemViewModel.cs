using Dataplace.Core.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataplace.Imersao.Core.Application.Orcamentos.ViewModels
{
    public class OrcamentoItemViewModel : BindableBase
    {

  
        private string cdProduto;
        private string dsProduto;
        private string tpRegistro;
        private decimal quantidade;

        public string CdEmpresa { get; set; }
        public string CdFilial { get; set; }
        public int NumOrcamento { get; set; }
        public int Seq { get; set; }
        public string TpRegistro { get => tpRegistro; set => SetProperty(ref tpRegistro, value); }
        public string CdProduto { get => cdProduto; set => SetProperty(ref cdProduto, value); }
        public string DsProduto { get => dsProduto; set => SetProperty(ref dsProduto, value); }
        public decimal Quantidade { get => quantidade; set => SetProperty(ref quantidade, value); }
        public decimal PrecoTabela { get; set; }
        public decimal PercAltPreco { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }

    }
}
