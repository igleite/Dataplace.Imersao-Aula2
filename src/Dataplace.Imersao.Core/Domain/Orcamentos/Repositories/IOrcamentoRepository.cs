namespace Dataplace.Imersao.Core.Domain.Orcamentos.Repositories
{
    public  interface IOrcamentoRepository
    {
        bool AdicionarOrcamento(Orcamento entity);
        bool AtualizarOrcamento(Orcamento entity);
        bool ExcluirOrcamento(Orcamento entity);
        Orcamento ObterOrcamento(string cdEmpresa, string cdFilail, int numOrcamento);
    }

    public interface IOrcamentoItemRepository
    {
        OrcamentoItem AdicionarItem(OrcamentoItem entity);
        bool AtualizarItem(OrcamentoItem entity);
        bool ExcluirItem(OrcamentoItem entity);
        OrcamentoItem ObterItem(string cdEmpresa, string cdFilail, int numOrcamento, int seq);
    }

    
}
