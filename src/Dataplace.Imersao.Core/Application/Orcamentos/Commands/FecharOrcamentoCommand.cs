using Dataplace.Core.Domain.Commands;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Commands
{
    public class FecharOrcamentoCommand : Command
    {
        public int NumOcamento { get; set; }
    }
}
