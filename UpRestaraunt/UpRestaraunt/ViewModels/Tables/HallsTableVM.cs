namespace UpRestaraunt.ViewModels.Tables
{
    using System;
    using System.Data;
    using System.Text.RegularExpressions;
    using UpRestaraunt.Commands;
    using UpRestaraunt.Converters;
    using UpRestaraunt.Database;

    /// <summary>
    /// Вью-модель таблицы с залами.
    /// </summary>
    public class HallsTableVM : BaseVM
    {
        /// <inheritdoc cref="SelectedRow" />
        private DataRowView _selectedRow { get; set; }

        /// <inheritdoc cref="CurrentUser" />
        private Users _currentUser { get; set; }

        /// <inheritdoc cref="HallsTable" />
        private DataTable _hallsTable { get; set; }

        /// <inheritdoc cref="CountPlaces" />
        private int _countPlaces { get; set; }

        /// <inheritdoc cref="ReadyToWork" />
        private bool _readyToWork { get; set; }

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

                if (HallsTable.Rows.Count != 0 && Filter != string.Empty)
                    HallsTable.DefaultView.RowFilter = $"{nameof(SelectedHall.Count_places)} = {Filter}";
                else
                    HallsTable.DefaultView.RowFilter = string.Empty;
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
        /// Выбранный зал.
        /// </summary>
        public Halls SelectedHall { get; set; }

        /// <summary>
        /// Представление таблицы.
        /// </summary>
        public DataView DataView => HallsTable.DefaultView;

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

                SelectedHall.ConvertToCoreDbFromRow(HallsTable, SelectedRow);
                OnPropertyChanged(nameof(SelectedHall));

                CountPlaces = SelectedHall.Count_places;
                ReadyToWork = SelectedHall.Ready_to_work;
            }
        }

        /// <summary>
        /// Табличное представление информации о залах.
        /// </summary>
        public DataTable HallsTable
        {
            get
            {
                return _hallsTable;
            }
            set
            {
                _hallsTable = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(DataView));
            }
        }

        /// <summary>
        /// Отображаемое значение количества мест в таблице.
        /// </summary>
        public int CountPlaces
        {
            get
            {
                return _countPlaces;
            }
            set
            {
                _countPlaces = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Отображаемое значение готовности зала к работе в таблице.
        /// </summary>
        public bool ReadyToWork
        {
            get
            {
                return _readyToWork;
            }
            set
            {
                _readyToWork = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда для изменения записи о зале.
        /// </summary>
        public EditCoreSettingsFromDbCommand<HallsTableVM> EditCoreSettingsFromDbCommand { get; set; }

        /// <summary>
        /// Команда для удаления зала.
        /// </summary>
        public DeleteCoreFromDbCommand<HallsTableVM> DeleteCoreFromDbCommand { get; set; }

        /// <summary>
        /// Команда для добавления зала.
        /// </summary>
        public AddCoreToDbCommand<HallsTableVM> AddCoreToDbCommand { get; set; }

        /// <summary>
        /// Конструктор вью-модели таблицы с залами.
        /// </summary>
        public HallsTableVM()
        {
            CurrentUser = new Users();
            SelectedHall = new Halls();
            HallsTable = new DataTable();

            EditCoreSettingsFromDbCommand = new EditCoreSettingsFromDbCommand<HallsTableVM>();
            DeleteCoreFromDbCommand = new DeleteCoreFromDbCommand<HallsTableVM>();
            AddCoreToDbCommand = new AddCoreToDbCommand<HallsTableVM>();
        }
    }
}
