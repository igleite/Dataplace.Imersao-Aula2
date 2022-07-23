using Dataplace.Core.win.Controls.Binding;
using Dataplace.Core.win.Views.Contracts;
using Dataplace.Core.win.Views.Controllers;
using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dataplace.Imersao.Presentation.Views.Orcamentos
{
    public partial class OrcamentoAdicionaisView : UserControl, IRegisterView<OrcamentoViewModel>
    {
        private readonly RegisterViewController _c;

        public OrcamentoAdicionaisView(RegisterViewController c)
        {
            InitializeComponent();
            _c = c;
            var _b = new DataBindingViewModel<OrcamentoViewModel>(this)
                .Map(x => x.CdTabela, new DataBindingControl(cdTabela));
            _c.AddBindings(_b);
        }

        public UserControl View => this;

        public RegisterViewController Controller => throw new NotImplementedException();

        public void ClearValue()
        {
            seqTabela.Clear();
        }

        public void Configure()
        {
      
        }

        public void GetValue(OrcamentoViewModel viewModel)
        {
       
        }

        public void Init()
        {
       
        }

        public void SetValue(OrcamentoViewModel viewModel)
        {
            seqTabela.Text = viewModel.SqTabela.ToString();
        }
    }
}
