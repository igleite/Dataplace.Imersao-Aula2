using Dataplace.Core.win.Views.Contracts;
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
    public partial class OrcamentoItemView : UserControl, IRegisterView<OrcamentoItemViewModel>
    {
        public OrcamentoItemView()
        {
            InitializeComponent();
        }

        public UserControl View => this;

        public void ClearValue()
        {
        
        }

        public void Configure()
        {
            
        }

        public void GetValue(OrcamentoItemViewModel viewModel)
        {
       
        }

        public void Init()
        {
          
        }

        public void SetValue(OrcamentoItemViewModel viewModel)
        {
          
        }
    }
}
