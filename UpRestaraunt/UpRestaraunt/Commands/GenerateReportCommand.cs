namespace UpRestaraunt.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Windows;

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
        /// Словарь с переводом с английского в русский для отчёта.
        /// </summary>
        private Dictionary<string, string> words;

        /// <summary>
        /// Конструктор команды для генерации отчёта.
        /// </summary>
        public GenerateReportCommand()
        {
            words = new Dictionary<string, string>()
            {
                { "Last_name", "Фамилия" },
                { "First_name", "Имя" },
                { "Middle_name", "Отчество" },
                { "Address", "Адрес" },
                { "Number_phone", "Номер телефона" },
                { "Count_orders", "Кол-во заказов" },
                { "Title", "Название" },
                { "Time_cooking", "Время готовки" },
                { "Price", "Цена" },
                { "Time_visit", "Время посещения" },
                { "ClientsTable", "Таблица клиентов" },
                { "EmployeeTable", "Таблица работник" },
                { "DishesTable", "Таблица блюд" },
                { "VisitsTable", "Таблица посещений" },
            };
        }

        /// <summary>
        /// Выполнить команду для генерации отчёта.
        /// </summary>
        /// <param name="tabTablesVM"> Вью-модель контрола с таблицами. </param>
        protected override void Execute(TabTablesVM tabTablesVM)
        {
            if (tabTablesVM.ClientTableVM.ClientsTable.Rows.Count == 0 && tabTablesVM.EmployeeTableVM.EmployeeTable.Rows.Count == 0 &&
                tabTablesVM.DishesTableVM.DishesTable.Rows.Count == 0 && tabTablesVM.VisitsTableVM.VisitsTable.Rows.Count == 0)
            {
                MessageBox.Show("Ключевые таблицы пусты!", "Генерация отчёта, ошибка.");
                return;
            }

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
        private void FillTablesReport(DataTable dataTable, string tableName)
        {
            tableName = words[tableName];
            var ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
            var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            var font = new Font(baseFont, Font.DEFAULTSIZE, Font.NORMAL);
            var widths = new List<float>();

            foreach (DataColumn column in dataTable.Columns)
            {
                if (column.ColumnName.Contains("Id"))
                    continue;

                widths.Add(dataTable.Rows.Count);
            }

            var table = new PdfPTable(widths.Count);
            table.SetWidths(widths.ToArray());
            table.WidthPercentage = 100;
            table.SpacingAfter = 25;

            var cell = new PdfPCell(new Phrase(tableName, font));
            cell.Colspan = dataTable.Columns.Count;
            cell.HorizontalAlignment = 1;
            cell.Border = 0;
            table.AddCell(cell);

            foreach (DataColumn column in dataTable.Columns)
            {
                if (column.ColumnName.Contains("Id"))
                    continue;

                table.AddCell(new Phrase(words[column.ColumnName], font));
            }

            foreach (DataRow row in dataTable.Rows)
            {
                for (var index = 0; index < dataTable.Columns.Count; index++)
                {
                    if (dataTable.Columns[index].ColumnName.Contains("Id"))
                        continue;

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