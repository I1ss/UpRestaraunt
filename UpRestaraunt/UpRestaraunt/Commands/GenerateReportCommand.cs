namespace UpRestaraunt.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;

    using iTextSharp.text;
    using iTextSharp.text.pdf;

    using UpRestaraunt.ViewModels;

    /// <summary>
    /// Команда для генерации отчёта.
    /// </summary>
    public class GenerateReportCommand : BaseTypeCommand<TabTablesVM>
    {
        /// <summary>
        /// Название отчёта.
        /// </summary>
        private static string ReportName => "Report";

        /// <summary>
        /// Путь к отчёту.
        /// </summary>
        private static string ReportPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), $"{ReportName}.pdf");

        /// <summary>
        /// Документ чертежа.
        /// </summary>
        private Document Document;

        /// <summary>
        /// Выполнить команду для генерации отчёта.
        /// </summary>
        /// <param name="tabTablesVM"> Вью-модель контрола с таблицами. </param>
        protected override void Execute(TabTablesVM tabTablesVM)
        {
            Document = new Document();
            PdfWriter.GetInstance(Document, new FileStream(ReportPath, FileMode.Create));

            Document.Open();

            FillTablesReport(tabTablesVM.ClientTableVM.ClientsTable, nameof(tabTablesVM.ClientTableVM.ClientsTable));
            FillTablesReport(tabTablesVM.EmployeeTableVM.EmployeeTable, nameof(tabTablesVM.EmployeeTableVM.EmployeeTable));
            FillTablesReport(tabTablesVM.DishesTableVM.DishesTable, nameof(tabTablesVM.DishesTableVM.DishesTable));
            FillTablesReport(tabTablesVM.VisitsTableVM.VisitsTable, nameof(tabTablesVM.VisitsTableVM.VisitsTable));

            Document.Close();
        }

        /// <summary>
        /// Заполнить таблицы в отчёт.
        /// </summary>
        private void FillTablesReport(DataTable dataTable, string TableName)
        {
            var font = FontFactory.GetFont(FontFactory.HELVETICA, 8);
            var table = new PdfPTable(dataTable.Columns.Count);
            var widths = new List<float>();

            foreach (var column in dataTable.Columns)
            {
                widths.Add(dataTable.Rows.Count);
            }

            table.SetWidths(widths.ToArray());
            table.WidthPercentage = 100;
            table.SpacingAfter = 25;

            var cell = new PdfPCell(new Phrase(TableName));
            cell.Colspan = dataTable.Columns.Count;
            cell.HorizontalAlignment = 1;
            cell.Border = 0;
            table.AddCell(cell);

            foreach (DataColumn column in dataTable.Columns)
            {
                table.AddCell(new Phrase(column.ColumnName, font));
            }

            foreach (DataRow row in dataTable.Rows)
            {
                for (var index = 0; index < dataTable.Columns.Count; index++)
                {
                    table.AddCell(new Phrase(row[index].ToString(), font));
                }
            }

            Document.Add(table);
        }

        /// <inheritdoc />
        protected override bool CanExecute(TabTablesVM tabTablesVM)
        {
            return base.CanExecute(tabTablesVM);
        }
    }
}