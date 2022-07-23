using Dataplace.Core.Domain.Events;
using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Events
{
    public class OrcamentoItemAdicionadoEvent : Event
    {
   
        public OrcamentoItemAdicionadoEvent(OrcamentoItemViewModel item)
        {
            Item = item;
        }

        public OrcamentoItemViewModel Item { get; }
    }
}
