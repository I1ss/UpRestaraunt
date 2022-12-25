namespace UpRestaraunt.ViewModels.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Data;

    using UpRestaraunt.Commands;
    using UpRestaraunt.Converters;
    using UpRestaraunt.Database;

    /// <summary>
    /// Вью-модель таблицы с посещениями.
    /// </summary>
    public class VisitsTableVM : BaseVM
    {
        /// <inheritdoc cref="SelectedRow" />
        private DataRowView _selectedRow { get; set; }

        /// <inheritdoc cref="CurrentUser" />
        private Users _currentUser { get; set; }

        /// <inheritdoc cref="VisitsTable" />
        private DataTable _visitsTable { get; set; }

        /// <inheritdoc cref="TimeVisit" />
        private DateTime _timeVisit { get; set; }

        /// <inheritdoc cref="IdClient" />
        private int? _idClient { get; set; }

        /// <inheritdoc cref="IdEmployee" />
        private int? _idEmployee { get; set; }

        /// <inheritdoc cref="IdTable" />
        private int? _idTable { get; set; }

        /// <inheritdoc cref="Filter" />
        private string _filter { get; set; }

        /// <summary>
        /// Фильтр.
        /// </summary>
        public string Filter
        {
            get { return _filter; }
            set
            {
                if (Regex.IsMatch(value, "[^0-9]"))
                    return;

                _filter = value;
                OnPropertyChanged();

                if (VisitsTable.Rows.Count != 0 && Filter != string.Empty)
                    VisitsTable.DefaultView.RowFilter = $"{nameof(SelectedVisit.Id_client)} = {Filter}";
                else
                    VisitsTable.DefaultView.RowFilter = string.Empty;
            }
        }

        /// <summary>
        /// Текущий авторизованный пользователь.
        /// </summary>
        public Users CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Выбранное посещение.
        /// </summary>
        public Visits SelectedVisit { get; set; }

        /// <summary>
        /// Представление таблицы.
        /// </summary>
        public DataView DataView => VisitsTable.DefaultView;

        /// <summary>
        /// Выбранная строка в таблице.
        /// </summary>
        public DataRowView SelectedRow
        {
            get
            {
                return _selectedRow;
            }
            set
            {
                _selectedRow = value;
                OnPropertyChanged();

                SelectedVisit.ConvertToCoreDbFromRow(VisitsTable, SelectedRow);
                OnPropertyChanged(nameof(SelectedVisit));

                TimeVisit = SelectedVisit.Time_visit;
                IdClient = SelectedVisit.Id_client;
                IdEmployee = SelectedVisit.Id_employee;
                IdTable = SelectedVisit.Id_table;
            }
        }

        /// <summary>
        /// Табличное представление информации о визитах.
        /// </summary>
        public DataTable VisitsTable
        {
            get
            {
                return _visitsTable;
            }
            set
            {
                _visitsTable = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(DataView));
            }
        }

        /// <summary>
        /// Отображаемое значение времени посещения в таблице.
        /// </summary>
        public DateTime TimeVisit
        {
            get
            {
                return _timeVisit;
            }
            set
            {
                _timeVisit = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Отображаемое значение id клиента в таблице.
        /// </summary>
        public int? IdClient
        {
            get
            {
                return _idClient;
            }
            set
            {
                _idClient = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Отображаемое значение id работника в таблице.
        /// </summary>
        public int? IdEmployee
        {
            get
            {
                return _idEmployee;
            }
            set
            {
                _idEmployee = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Отображаемое значение id столика в таблице.
        /// </summary>
        public int? IdTable
        {
            get
            {
                return _idTable;
            }
            set
            {
                _idTable = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда для изменения записи о визите.
        /// </summary>
        public EditCoreSettingsFromDbCommand<VisitsTableVM> EditCoreSettingsFromDbCommand { get; set; }

        /// <summary>
        /// Команда для удаления визита.
        /// </summary>
        public DeleteCoreFromDbCommand<VisitsTableVM> DeleteCoreFromDbCommand { get; set; }

        /// <summary>
        /// Команда для добавления визита.
        /// </summary>
        public AddCoreToDbCommand<VisitsTableVM> AddCoreToDbCommand { get; set; }

        /// <summary>
        /// Конструктор вью-модели таблицы с визитами.
        /// </summary>
        public VisitsTableVM()
        {
            CurrentUser = new Users();
            SelectedVisit = new Visits();
            VisitsTable = new DataTable();
            EditCoreSettingsFromDbCommand = new EditCoreSettingsFromDbCommand<VisitsTableVM>();
            DeleteCoreFromDbCommand = new DeleteCoreFromDbCommand<VisitsTableVM>();
            AddCoreToDbCommand = new AddCoreToDbCommand<VisitsTableVM>();

            TimeVisit = DateTime.Now;
            Filter = string.Empty;
        }
    }
}
