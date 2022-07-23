using Dataplace.Core.Domain.Localization.Messages.Extensions;
using System.Collections.Generic;
using System.Drawing;

namespace Dataplace.Imersao.Presentation.Common
{
    public class PedidoSearch : dpLibrary05.Infrastructure.Helpers.clsSymSearch
    {

        #region methods
        public static dpLibrary05.SymphonyInterface.ISymInterfaceSearch find_orcamento(SearchArgs args = default(SearchArgs))
        {
            dpLibrary05.SymphonyInterface.ISymInterfaceSearch se = DefaultInstance();

            se.Title = 58144.ToMessage();
            se.Instructions = string.Empty;
            se.SecurityID = 5073;
            se.Id = nameof(find_orcamento);

            se.Source = @"SELECT orcamento.numorcamento, 
	                orcamento.cdcliente, 
	                Empresa.razao,              
                    orcamento.cdvendedor, 
	                Vendedor.Nome, 
	                orcamento.dtorcamento, 
	                orcamento.vlvendar 
                FROM orcamento                                                                 
                    INNER JOIN Cliente ON Orcamento.cdcliente = Cliente.cdcliente                  
                    INNER JOIN Empresa ON Empresa.empresaid = Cliente.empresaid                    
                    LEFT JOIN Vendedor ON Vendedor.CdVendedor = orcamento.cdvendedor   ";

            se.MethodSort = "numorcamento";

            {
                var withBlock = se.Fields;
                // Número
                withBlock.Add(new dpLibrary05.SymphonyInterface.clsSymInterfaceSearchField() { SearchIndex = 0, Name = 3182.ToMessage(), Width = 100, VisibleEdit = true, IsReturnValue = true, ColumnName = "numorcamento" });
                // Código
                withBlock.Add(new dpLibrary05.SymphonyInterface.clsSymInterfaceSearchField() { SearchIndex = 1, Name = 143.ToMessage(), Width = 80, VisibleEdit = false, ColumnName = "cdcliente" });
                // Nome/Razão Social
                withBlock.Add(new dpLibrary05.SymphonyInterface.clsSymInterfaceSearchField() { SearchIndex = 2, Name = 2819.ToMessage(), Width = 200, VisibleEdit = false, ColumnName = "razao" });
                // Cd. Vendedor
                withBlock.Add(new dpLibrary05.SymphonyInterface.clsSymInterfaceSearchField() { SearchIndex = 3, Name = 44545.ToMessage(), Width = 80, VisibleEdit = false, ColumnName = "cdvendedor" });
                // Nome do Vendedor
                withBlock.Add(new dpLibrary05.SymphonyInterface.clsSymInterfaceSearchField() { SearchIndex = 4, Name = 12425.ToMessage(), Width = 200, VisibleEdit = false, ColumnName = "Nome" });
                // Data do Orçamento
                withBlock.Add(new dpLibrary05.SymphonyInterface.clsSymInterfaceSearchField() { SearchIndex = 5, Name = 29914.ToMessage(), Width = 80, VisibleEdit = false, ColumnName = "dtorcamento" });
                // Valor
                withBlock.Add(new dpLibrary05.SymphonyInterface.clsSymInterfaceSearchField() { SearchIndex = 6, Name = 3048.ToMessage(), Width = 100, VisibleEdit = false, ColumnName = "vlvendar" });
            }

            SetParameters(ref se, args);
            return se;
        }
        public static dpLibrary05.SymphonyInterface.ISymInterfaceSearch find_orcamento_cliente(SearchArgs args = default(SearchArgs))
        {
            dpLibrary05.SymphonyInterface.ISymInterfaceSearch se = DefaultInstance();
            se.Title = 4542.ToMessage();

            se.SecurityID = 705;
            se.Id = nameof(find_orcamento_cliente);

            se.Source = @"SELECT cliente.cdcliente,
                                empresa.razao,
                                empresa.fantasia,
                                empresa.inscrifed,
                                empresa.inscriest,
                                cliente.stativocf,
                                empresa.endereco,
                                empresa.bairro,
                                empresa.cidade,
                                empresa.uf                                
                         FROM empresa 
                         INNER JOIN cliente ON cliente.empresaid = empresa.empresaid";

            se.MethodSort = @" razao ASC";

            //Código
            se.Fields.Add(new dpLibrary05.SymphonyInterface.clsSymInterfaceSearchField() { SearchIndex = 0, Name = 143.ToMessage(), Width = 80, IsReturnValue = true, ColumnName = "cdcliente", VisibleEdit = true });

            //Razão
            se.Fields.Add(new dpLibrary05.SymphonyInterface.clsSymInterfaceSearchField() { SearchIndex = 1, Name = 3025.ToMessage(), Width = 300, ColumnName = "razao", VisibleEdit = true });

            //Fantasia
            se.Fields.Add(new dpLibrary05.SymphonyInterface.clsSymInterfaceSearchField() { SearchIndex = 2, Name = 2796.ToMessage(), Width = 200, ColumnName = "fantasia", VisibleEdit = false });

            //Inscrição Federal
            se.Fields.Add(new dpLibrary05.SymphonyInterface.clsSymInterfaceSearchField() { SearchIndex = 3, Name = 3123.ToMessage(), Width = 130, ColumnName = "inscrifed", VisibleEdit = false });

            //Inscrição Estadual
            se.Fields.Add(new dpLibrary05.SymphonyInterface.clsSymInterfaceSearchField() { SearchIndex = 4, Name = 3166.ToMessage(), Width = 130, ColumnName = "inscriest", VisibleEdit = false });

            //Ativo
            se.Fields.Add(new dpLibrary05.SymphonyInterface.clsSymInterfaceSearchField() { SearchIndex = 5, Name = 4920.ToMessage(), Width = 60, FilterText = 2816.ToMessage(), Values = GetAtivoInativoList(), HighlightValues = GetAtivoInativoHighLight(), ColumnName = "stativocf", VisibleEdit = false });

            //Endereço
            se.Fields.Add(new dpLibrary05.SymphonyInterface.clsSymInterfaceSearchField() { SearchIndex = 6, Name = 2810.ToMessage(), Width = 400, ColumnName = "endereco", VisibleEdit = false });

            //Bairro
            se.Fields.Add(new dpLibrary05.SymphonyInterface.clsSymInterfaceSearchField() { SearchIndex = 7, Name = 2811.ToMessage(), Width = 150, ColumnName = "bairro", VisibleEdit = false });

            //Cidade
            se.Fields.Add(new dpLibrary05.SymphonyInterface.clsSymInterfaceSearchField() { SearchIndex = 8, Name = 2813.ToMessage(), Width = 250, ColumnName = "cidade", VisibleEdit = false });

            //UF
            se.Fields.Add(new dpLibrary05.SymphonyInterface.clsSymInterfaceSearchField() { SearchIndex = 9, Name = 2798.ToMessage(), Width = 30, ColumnName = "uf", VisibleEdit = false });


            SetParameters(ref se, args);
            return se;
        }
        #endregion


        #region internals
        private static List<dpLibrary05.Infrastructure.Helpers.clsSymValueItem> GetAtivoInativoList()
        {
            var list = new List<dpLibrary05.Infrastructure.Helpers.clsSymValueItem>();

            list.Add(new dpLibrary05.Infrastructure.Helpers.clsSymValueItem(1, 2816.ToMessage())); //Ativo            
            list.Add(new dpLibrary05.Infrastructure.Helpers.clsSymValueItem(0, 3050.ToMessage())); //Inativo

            return list;
        }

        private static List<dpLibrary05.SymphonyMetaData.clsSMDInterfaceHighlightValue> GetAtivoInativoHighLight()
        {
            var highlightList = new List<dpLibrary05.SymphonyMetaData.clsSMDInterfaceHighlightValue>()
                { new dpLibrary05.SymphonyMetaData.clsSMDInterfaceHighlightValue() { Color = dpLibrary05.mGenerico.ConvertColorToHex(Color.Red), HighlightType = dpLibrary05.SymphonyMetaData.HighlightTypeEnum.Row, Value = 0}};

            return highlightList;
        }
        #endregion

    }


}
