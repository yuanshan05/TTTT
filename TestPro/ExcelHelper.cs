using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPro
{
    public static class ExcelHelper
    {
        public static List<ExcelModel> Reader(string fileName, bool hasHeader)
        {
            List<ExcelModel> result = new List<ExcelModel>();
            try
            {
                using (SpreadsheetDocument doc = SpreadsheetDocument.Open(fileName, false))
                {
                    Sheets sheets = doc.WorkbookPart.Workbook.Sheets;
                    Sheet sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();
                    Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;
                    IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();

                    Type type = typeof(ExcelModel);
                    var properties = type.GetProperties();

                    foreach (var row in rows)
                    {
                        ExcelModel entity = new ExcelModel();

                        if (hasHeader)
                        {
                            if (row.RowIndex.Value == 1)
                                continue;
                        }
                        int i = 0;
                        foreach (Cell cell in row.Descendants<Cell>())
                        {
                            properties[i].SetValue(entity, GetCellValue(doc, cell));
                            i++;
                        }
                        result.Add(entity);
                    }
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return result;
        }

        private static string GetCellValue(SpreadsheetDocument doc, Cell cell)
        {
            string value = cell.CellValue.InnerText;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value)).InnerText;
            }
            if (cell.DataType == null && cell.CellReference.Value.ToUpper().StartsWith("F"))
            {
                if (long.TryParse(value, out long longTicks))
                    return DateTime.FromOADate(longTicks).ToString("yyyy-MM-dd");
                else
                    return value;
            }
            if (cell.DataType == null && cell.CellReference.Value.ToUpper().StartsWith("G"))
            {
                if (long.TryParse(value, out long longTicks))
                    return DateTime.FromOADate(longTicks).ToString("yyyy-MM-dd");
                else
                    return value;
            }
            return value;
        }

    }
}
