using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Helpers
{
    public static class FileHelper
    {
        public static DataTable GetDataTableFromExcel(string path, bool hasHeader = true)
        {
            using var excel = new ExcelPackage();

            using (var stream = File.OpenRead(path))
            {
                excel.Load(stream);
            }

            var worksheet = excel.Workbook.Worksheets.First();

            var table = new DataTable();

            foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
            {
                table.Columns.Add(hasHeader ? firstRowCell.Text : $"Column {firstRowCell.Start.Column}");
            }

            var startRow = hasHeader ? 2 : 1;

            for (int rowNum = startRow; rowNum <= worksheet.Dimension.End.Row; rowNum++)
            {
                var cells = worksheet.Cells[rowNum, 1, rowNum, worksheet.Dimension.End.Column];

                var row = table.Rows.Add();

                var conteudo = "";

                foreach (var cell in cells)
                {
                    Type tValue = null;
                    if (cell.Value != null)
                    {
                        tValue = cell.Value.GetType();
                    }

                    conteudo = cell.Text;

                    Type tText = cell.Text.GetType();
                    if (tText == typeof(string) && (tValue == typeof(DateTime) || tValue == typeof(DateTime?)))
                    {
                        conteudo = cell.Value.ToString();
                    }

                    row[cell.Start.Column - 1] = conteudo;
                }
            }

            return table;
        }
    }
}
