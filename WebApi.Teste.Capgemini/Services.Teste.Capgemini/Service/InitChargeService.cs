using Domain.Teste.Capgemini.Contracts.Response;
using Domain.Teste.Capgemini.Model;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Net;
using Services.Teste.Capgemini.Service.Interface;
using Repository.Teste.Capgemini.Repository.Interface;

namespace Services.Teste.Capgemini.Service
{
    public class InitChargeService : IinitChargeService
    {
        private readonly IinitChargeRepository _initChargeRepository;
        public InitChargeService(IinitChargeRepository initChargeRepository)
        {
            _initChargeRepository = initChargeRepository;
        }
        public bool VerifyPlan(List<ModelTabela1> plan)
        {
            foreach (ModelTabela1 linha in plan)
            {
                if (linha.DataEntrega < DateTime.Now || linha.Quantidade <= 0 || linha.ValorUnitario <= 0)
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<ChargeXls> ChargePlan(IFormFile file)
        {
            ChargeXls response = new ChargeXls();

            List<ModelTabela1> planilha = new List<ModelTabela1>();

            List<Erro> planErro = new List<Erro>();
            

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
                        for (int j = 2; j <= totalRows.Value - 1; j++)
                        {
                            ModelTabela1 tabela1 = new ModelTabela1();
                            Erro er = new Erro();

                            try
                            {
                                tabela1.DataEntrega = DateTime.Parse(package.Workbook.Worksheets[i].Cells[j, 1].Value.ToString());
                            }
                            catch (Exception ex)
                            {
                                planErro.Add(ResgisterError(j, "Data Entrega", "Dados incorretos na coluna : " + ex.ToString()));
                            }
                            try
                            {
                                tabela1.NomeProduto = package.Workbook.Worksheets[i].Cells[j, 2].Value.ToString();
                            }
                            catch (Exception ex)
                            {
                                planErro.Add(ResgisterError(j, "Nome Produto", "Dados incorretos na coluna : " + ex.ToString()));
                            }
                            try
                            {
                                tabela1.Quantidade = int.Parse(package.Workbook.Worksheets[i].Cells[j, 3].Value.ToString());
                            }
                            catch (Exception ex)
                            {
                                planErro.Add(ResgisterError(j, "Quantidade", "Dados incorretos na coluna : " + ex.ToString()));
                            }
                            try
                            {
                                tabela1.ValorUnitario = double.Parse(package.Workbook.Worksheets[i].Cells[j, 4].Value.ToString());
                            }
                             catch (Exception ex)
                            {
                                planErro.Add(ResgisterError(j, "Valor Unitario", "Dados incorretos na coluna : " + ex.ToString()));
                            }

                            planilha.Add(tabela1);
                        }

                        response.aResult = VerifyPlan(planilha);
                        if (response.aResult)
                        {
                            _initChargeRepository.DataBaseRegisterChargePlan(planilha);
                        }
                    }
                    catch (Exception ex)
                    {
                        Erro er = new Erro()
                        {
                            linha = 0,
                            coluna = "Exception",
                            ex = ex.ToString()
                        };
                        response.erros.Add(er);
                        response.aResult = false;
                        return response;
                    }

                    response.erros = planErro;
                    return response;
                }
            }
        }

        public Erro ResgisterError(int linha, string coluna, string ex)
        {
            Erro er = new Erro();
            er.linha = linha;
            er.coluna = coluna;
            er.ex = ex;

            return er;
        }
    }
}
