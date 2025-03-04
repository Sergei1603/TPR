using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TPR
{
    internal class LoadService
    {
        private XLWorkbook workbook;
        private string pathToFile = "SaveData.xlsx";

        public void Save(List<Strategy> data)
        {
//            var appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
//            var relativePath = @"SaveData.xlsx";
            var workbook = new XLWorkbook();
            workbook.Worksheets.Add();
            var worksheet = workbook.Worksheet(1);
            int orid_excel_j = 1;
            int orid_excel_i = 1;
            data.ForEach(x =>
            {
                int excel_j = orid_excel_j;
                int excel_i = orid_excel_i;

                for (int i = 0; i < x.Probabilites.Count; i++, excel_i++)
                {
                    excel_j = orid_excel_j;
                    for (int j = 0; j < x.Probabilites.Count; j++, excel_j++)
                    {
                        worksheet.Cell(excel_i, excel_j).Value = x.Probabilites[i][j];
                    }
                }
                worksheet.Cell(excel_i, 1).Value = ".";
                excel_j++;
                int tmp_i = excel_i;
                excel_i = orid_excel_i;
                int tmp_j = excel_j;
                for (int i = 0; i < x.Profit.Count; i++, excel_i++)
                {
                    excel_j = tmp_j;
                    for (int j = 0; j < x.Profit.Count; j++, excel_j++)
                    {
                        worksheet.Cell(excel_i, excel_j).Value = x.Profit[i][j];
                    }
                }
                worksheet.Cell(excel_i, tmp_j).Value = ".";
                excel_i++;
                orid_excel_i = excel_i;
                orid_excel_j = 1;
            });
                            workbook.SaveAs(pathToFile);
        }

        public List<List<double>> Load(int rowIndex = 0, int columnIndex = 0)
        {
            workbook = new XLWorkbook(pathToFile);
            var worksheet = workbook.Worksheet(1);
            var originMatrix = new List<List<double>>();
            var row = rowIndex;
            while (true)
            {
                IXLCell tmp = worksheet.Cell(row + 1, 1);
                if(!tmp.Value.IsNumber)
                {
                    break;
                }
                originMatrix.Add(new List<double>());
                var column = columnIndex;
                while (true)
                {
                    IXLCell cell = worksheet.Cell(row + 1, column + 1);
                    if(!cell.Value.IsNumber)
                    {
                        break;
                    }
                    originMatrix[row - rowIndex].Add(cell.GetDouble());
                    column++;
                }
                row++;
            }

            return originMatrix;
        }

        public LoadService(string pathToFile)
        {
            this.pathToFile = pathToFile;
 //           workbook = new XLWorkbook(pathToFile);
        }
    }
}
