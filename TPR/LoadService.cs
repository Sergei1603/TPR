using ClosedXML.Excel;
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
        private static string pathToFile = "SaveData.xlsx";

        public static void Save(List<List<double>> data)
        {
            var appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var relativePath = @"SaveData.xlsx";
            var workbook = new XLWorkbook();
            workbook.Worksheets.Add("Data");
            var worksheet = workbook.Worksheet("Data");
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < data[i].Count; j++)
                {
                    worksheet.Cell(i + 1, j + 1).Value = data[i][j];
                }
            }
            workbook.SaveAs(pathToFile);
            
        }

        public static List<List<double>> Load()
        {

            var workbook = new XLWorkbook(pathToFile);
            var worksheet = workbook.Worksheet("Data");
            var originMatrix = new List<List<double>>();
            var row = 0;
            while (true)
            {
                IXLCell tmp = worksheet.Cell(row + 1, 1);
                if(!tmp.Value.IsNumber)
                {
                    break;
                }
                originMatrix.Add(new List<double>());
                var column = 0;
                while (true)
                {
                    IXLCell cell = worksheet.Cell(row + 1, column + 1);
                    if(!cell.Value.IsNumber)
                    {
                        break;
                    }
                    originMatrix[row].Add(cell.GetDouble());
                    column++;
                }
                row++;

            }
            return originMatrix;
            
        }
    }
}
