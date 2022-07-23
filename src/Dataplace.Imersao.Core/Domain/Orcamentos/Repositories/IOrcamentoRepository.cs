namespace Dataplace.Imersao.Core.Domain.Orcamentos.Repositories
{
    public interface IOrcamentoRepository
    {

        bool AdicionarOrcamento(Orcamento entity);
        bool AtualizarOrcamento(Orcamento entity);
        bool ExcluirOrcamento(Orcamento entity);
        Orcamento ObterOrcamento(string cdEmpresa, string cdFilail, int numOrcamento);

    }

    
}
