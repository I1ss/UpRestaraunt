namespace UpRestaraunt.ViewModels.Tables
{
    using System;
    using System.Data;
    using System.Text.RegularExpressions;
    using UpRestaraunt.Commands;
    using UpRestaraunt.Converters;
    using UpRestaraunt.Database;

    /// <summary>
    /// Вью-модель таблицы со столиками.
    /// </summary>
    public class TablesTableVM : BaseVM
    {
        /// <inheritdoc cref="SelectedRow" />
        private DataRowView _selectedRow { get; set; }

        /// <inheritdoc cref="CurrentUser" />
        private Users _currentUser { get; set; }

        /// <inheritdoc cref="TabTable" />
        private DataTable _tabTable { get; set; }

        /// <inheritdoc cref="IdHall" />
        private int? _idHall { get; set; }

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

                if (TabTable.Rows.Count != 0 && Filter != string.Empty)
                    TabTable.DefaultView.RowFilter = $"{nameof(SelectedTable.Id_hall)} = {Filter}";
                else
                    TabTable.DefaultView.RowFilter = string.Empty;
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
        /// Выбранный столик.
        /// </summary>
        public Tables SelectedTable { get; set; }

        /// <summary>
        /// Представление таблицы.
        /// </summary>
        public DataView DataView => TabTable.DefaultView;

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

                SelectedTable.ConvertToCoreDbFromRow(TabTable, SelectedRow);
                OnPropertyChanged(nameof(SelectedTable));

                IdHall = SelectedTable.Id_hall;
            }
        }

        /// <summary>
        /// Табличное представление информации о столике.
        /// </summary>
        public DataTable TabTable
        {
            get
            {
                return _tabTable;
            }
            set
            {
                _tabTable = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(DataView));
            }
        }

        /// <summary>
        /// Отображаемое значение id зала в таблице.
        /// </summary>
        public int? IdHall
        {
            get
            {
                return _idHall;
            }
            set
            {
                _idHall = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда для изменения записи о столике.
        /// </summary>
        public EditCoreSettingsFromDbCommand<TablesTableVM> EditCoreSettingsFromDbCommand { get; set; }

        /// <summary>
        /// Команда для удаления столика.
        /// </summary>
        public DeleteCoreFromDbCommand<TablesTableVM> DeleteCoreFromDbCommand { get; set; }

        /// <summary>
        /// Команда для добавления столика.
        /// </summary>
        public AddCoreToDbCommand<TablesTableVM> AddCoreToDbCommand { get; set; }

        /// <summary>
        /// Конструктор вью-модели таблицы со столиком.
        /// </summary>
        public TablesTableVM()
        {
            CurrentUser = new Users();
            SelectedTable = new Tables();
            TabTable = new DataTable();

            EditCoreSettingsFromDbCommand = new EditCoreSettingsFromDbCommand<TablesTableVM>();
            DeleteCoreFromDbCommand = new DeleteCoreFromDbCommand<TablesTableVM>();
            AddCoreToDbCommand = new AddCoreToDbCommand<TablesTableVM>();
        }
    }
}
