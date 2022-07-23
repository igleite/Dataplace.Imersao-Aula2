using Dataplace.Core.Infra.Data.OdbcConnection;
using Dataplace.Imersao.Core.Domain.Orcamentos;
using Dataplace.Imersao.Core.Domain.Orcamentos.Repositories;
using dpLibrary05;
using Dapper;
using Dataplace.Imersao.Core.Domain.Orcamentos.Enums;
using Dataplace.Imersao.Core.Domain.Orcamentos.ValueObjects;
using System.Linq;

namespace Dataplace.Imersao.Core.Infra.Data.Repositories
{
    public class OrcamentoRepository : IOrcamentoRepository
    {
        #region fields
        private readonly IDataAccess _dataAccess = null;
        #endregion
        #region constructors
        public OrcamentoRepository(): this(BootStrapper.Container.GetInstance<IOdbcDataAccess>())
        {

        }
        public OrcamentoRepository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        #endregion
        public bool AdicionarOrcamento(Orcamento entity)
        {
            var sql = @"
            INSERT INTO 
                Orcamento(DtOrcamento,VlVendar,DtFechamento,StOrcamento,CdCliente,NumDias,DtValidade,SqTabela,CdTabela,CdVendedor,Usuario,CdEmpresa,CdFilial)
            VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?)

            SELECT SCOPE_IDENTITY()
            ";

            var result =  _dataAccess.Connection.ExecuteScalar<int?>(sql,
                new
                {
                    DtOrcamento = entity.DtOrcamento,
                    VlVendar = entity.ValotTotal,
                    DtFechamento = entity.DtFechamento,
                    StOrcamento = entity.Situacao.ToDataValue(),
                    CdCliente = entity.Cliente?.Codigo,
                    NumDias = entity.Validade?.Dias,
                    DtValidade = entity.Validade?.Data,
                    SqTabela = entity.TabelaPreco?.SqTabela,
                    CdTabela = entity.TabelaPreco?.CdTabela,
                    CdVendedor = entity.Vendedor?.Codigo,
                    Usuario = entity.Usuario?.UserName,
                    CdEmpresa = entity.CdEmpresa,
                    CdFilial = entity.CdFilial,
                },
                transaction: _dataAccess.Transaction);

            if(result.HasValue)
            {
                entity.SetNumOrcamento(result.Value);
                return true;
            }
            return false;

        }

        public bool AtualizarOrcamento(Orcamento entity)
        {
            var sql = @"
            UPDATE 
                Orcamento
            SET
                 Orcamento.DtOrcamento = ?
                ,Orcamento.VlVendar = ?
                ,Orcamento.DtFechamento = ?
                ,Orcamento.StOrcamento = ?
                ,Orcamento.CdCliente = ?
                ,Orcamento.NumDias = ?
                ,Orcamento.DtValidade = ?
                ,Orcamento.SqTabela = ?
                ,Orcamento.CdTabela = ?
                ,Orcamento.CdVendedor = ?
                ,Orcamento.Usuario = ?
            WHERE CdEmpresa = ?
                AND CdFilial = ?
                AND NumOrcamento = ?
            ";

           return  _dataAccess.Connection.Execute(sql, 
               new {
                 
                   DtOrcamento = entity.DtOrcamento,
                   VlVendar = entity.ValotTotal,
                   DtFechamento = entity.DtFechamento,
                   StOrcamento = entity.Situacao.ToDataValue(),
                   CdCliente = entity.Cliente?.Codigo,
                   NumDias = entity.Validade?.Dias,
                   DtValidate = entity.Validade?.Data,
                   SeqTabela = entity.TabelaPreco?.SqTabela,
                   CdTabela = entity.TabelaPreco?.CdTabela,
                   CdVendedor = entity.Vendedor?.Codigo,
                   Usuario = entity.Usuario?.UserName,  
                   CdEmpresa = entity.CdEmpresa,
                   CdFilial = entity.CdFilial,
                   NumOrcamento = entity.NumOrcamento
               },
               transaction: _dataAccess.Transaction) > 0 ;


        }

        public bool ExcluirOrcamento(Orcamento entity)
        {
            var sql = @"
            DELETE FROM Orcamento
            WHERE CdEmpresa = ?
                AND CdFilial = ?
                AND NumOrcamento = ?
            ";

            return _dataAccess.Connection.Execute(sql,
                new
                {
                    CdEmpresa = entity.CdEmpresa,
                    CdFilial = entity.CdFilial,
                    NumOrcamento = entity.NumOrcamento
                },
                transaction: _dataAccess.Transaction) > 0;
        }

        public Orcamento ObterOrcamento(string cdEmpresa, string cdFilial, int numOrcamento)
        {
            var sql = @"
            SELECT 
                 Orcamento.CdEmpresa
                ,Orcamento.CdFilial
                ,Orcamento.NumOrcamento        
                ,Orcamento.DtOrcamento 
                ,Orcamento.VlVendar as ValorTotal
                ,Orcamento.DtFechamento
                ,Orcamento.StOrcamento
                ,null as Cliente
                ,Orcamento.CdCliente as Codigo
                ,Orcamento.NumDias
                ,Orcamento.DtValidade
                ,Orcamento.SqTabela
                ,Orcamento.CdTabela
                ,Orcamento.CdVendedor
                ,null as Vendedor
                ,Orcamento.CdVendedor as Codigo
                ,Orcamento.Usuario as UserName
            FROM
                Orcamento
            WHERE CdEmpresa = ?
                AND CdFilial = ?
                AND NumOrcamento = ?
            ";

            var items =  _dataAccess.Connection.Query<Orcamento, OrcamentoCliente, OrcamentoValidade, OrcamentoTabelaPreco, OrcamentoVendedor, OrcamentoUsuario, Orcamento>(sql, 
                (o, cli, val, tp, v, u) => {

                    if (cli != null)
                        o.DefinirCliente(cli);

                    if (val != null)
                        o.DefinirValidade(val);

                    if (tp != null)
                        o.DefinirTabelaPreco(tp);

                    if (v != null)
                        o.DefinirVendedor(v);

                    if (u != null)
                        o.DefinirUsuario(u);

                    return o;
                },
                new
                {
                    CdEmpresa = cdEmpresa,
                    CdFilial = cdFilial,
                    NumOrcamento = numOrcamento
                },
                splitOn: "CdEmpresa, Cliente, NumDias, SqTabela, Vendedor, UserName",
                transaction: _dataAccess.Transaction);


            return items.FirstOrDefault();
        }
    }
}
