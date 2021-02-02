using Domain.Teste.Capgemini.Contracts.Response;
using Domain.Teste.Capgemini.Model;
using Domain.Teste.Capgemini.Service.Interface;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Net;

namespace Domain.Teste.Capgemini.Service
{
    public class InitChargeService: IinitChargeService
    {
        public bool VerifyPlan(List<Tabela1> plan)
        {
            foreach(Tabela1 linha in plan)
            {
                if(linha.DataEntrega < DateTime.Now || linha.Quantidade <= 0 || linha.ValorUnitario <= 0)
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<ChargeXls> ChargePlan(IFormFile file)
        {
            ChargeXls response = new ChargeXls();

            Tabela1 tabela1 = new Tabela1();
            List<Tabela1> planilha = new List<Tabela1>();

            if (file == null || file.Length == 0)
            {
                response.aResult = false;
                return response;
            }

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream).ConfigureAwait(false);

                using (var package = new ExcelPackage(memoryStream))
                {
                    try
                    {
                        int i = 0;
                        var totalRows = package.Workbook.Worksheets[i].Dimension?.Rows;
                        var totalCollumns = package.Workbook.Worksheets[i].Dimension?.Columns;
                        for (int j = 2; j <= totalRows.Value-1; j++)
                        {
                            tabela1.DataEntrega = DateTime.Parse(package.Workbook.Worksheets[i].Cells[j, 1].Value.ToString());
                            tabela1.NomeProduto = package.Workbook.Worksheets[i].Cells[j, 2].Value.ToString();
                            tabela1.Quantidade = int.Parse(package.Workbook.Worksheets[i].Cells[j, 3].Value.ToString());
                            tabela1.ValorUnitario = double.Parse(package.Workbook.Worksheets[i].Cells[j, 4].Value.ToString());
                                
                            planilha.Add(tabela1);
                        }
                        
                        response.aResult = VerifyPlan(planilha);
                    }
                    catch(Exception ex)
                    {
                        response.ExcMessage = ex.ToString();
                        response.aResult = false;
                    }

                    
                    return response;
                }
            }
        }
    }
}
