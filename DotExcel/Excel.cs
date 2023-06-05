using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotExcel
{
    public class Excel
    {
        public List<Pessoa> LerXls(string caminhoArquivo)
        {
            var response = new List<Pessoa>();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //dispose 
            using (ExcelPackage excel = new ExcelPackage(new FileInfo(caminhoArquivo)))
            {
            //ExcelPackage excel = new ExcelPackage(new FileInfo(caminhoArquivo));
                ExcelWorksheet worksheet = excel.Workbook.Worksheets[0];

                int rowCount = worksheet.Dimension.End.Row;

                for (int row = 2; row <= rowCount; row++)
                {
                    var pessoa = new Pessoa();
                    pessoa.nome = worksheet.Cells[row, 1].Value?.ToString();
                    pessoa.email = worksheet.Cells[row, 2].Value?.ToString();
                    pessoa.id = int.Parse(worksheet.Cells[row, 3].Value?.ToString());
                    response.Add(pessoa);
                }
            }
            //excel.Dispose();

            return response;
        }

    }
}
