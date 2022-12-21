namespace UpRestaraunt.ViewModels.Tables
{
    using System;
    using System.Data;
    using UpRestaraunt.Commands;
    using UpRestaraunt.Converters;
    using UpRestaraunt.Database;

    /// <summary>
    /// Вью-модель таблицы с блюдами.
    /// </summary>
    public class DishesTableVM : BaseVM
    {
        /// <inheritdoc cref="SelectedRow" />
        private DataRowView _selectedRow { get; set; }

        /// <inheritdoc cref="CurrentUser" />
        private Users _currentUser { get; set; }

        /// <inheritdoc cref="DishesTable" />
        private DataTable _dishesTable { get; set; }

        /// <inheritdoc cref="Title" />
        private string _title { get; set; }

        /// <inheritdoc cref="TimeCooking" />
        private DateTime _timeCooking { get; set; }

        /// <inheritdoc cref="Price" />
        private int _price { get; set; }

        /// <inheritdoc cref="IdMenu" />
        private int _idMenu { get; set; }

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
                _filter = value;
                OnPropertyChanged();

                if (DishesTable.Rows.Count != 0 && Filter != string.Empty)
                    DishesTable.DefaultView.RowFilter = $"{nameof(SelectedDish.Title)} = '{Filter}'";
                else
                    DishesTable.DefaultView.RowFilter = string.Empty;
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
        /// Выбранное блюдо.
        /// </summary>
        public Dishes SelectedDish { get; set; }

        /// <summary>
        /// Представление таблицы.
        /// </summary>
        public DataView DataView => DishesTable.DefaultView;

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

                SelectedDish.ConvertToCoreDbFromRow(DishesTable, SelectedRow);
                OnPropertyChanged(nameof(SelectedDish));

                Title = SelectedDish.Title;
                TimeCooking = SelectedDish.Time_cooking;
                Price = SelectedDish.Price;
                IdMenu = SelectedDish.Id_menu is int selectedDishIdMenu ? selectedDishIdMenu : 0;
            }
        }

        /// <summary>
        /// Табличное представление информации о блюдах.
        /// </summary>
        public DataTable DishesTable
        {
            get
            {
                return _dishesTable;
            }
            set
            {
                _dishesTable = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(DataView));
            }
        }

        /// <summary>
        /// Отображаемое значение названия в таблице.
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Отображаемое значение времени приготовления в таблице.
        /// </summary>
        public DateTime TimeCooking
        {
            get
            {
                return _timeCooking;
            }
            set
            {
                _timeCooking = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Отображаемое значение цены в таблице.
        /// </summary>
        public int Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Отображаемое значение id меню в таблице.
        /// </summary>
        public int IdMenu
        {
            get
            {
                return _idMenu;
            }
            set
            {
                _idMenu = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда для изменения записи о блюде.
        /// </summary>
        public EditCoreSettingsFromDbCommand<DishesTableVM> EditCoreSettingsFromDbCommand { get; set; }

        /// <summary>
        /// Команда для удаления блюда.
        /// </summary>
        public DeleteCoreFromDbCommand<DishesTableVM> DeleteCoreFromDbCommand { get; set; }

        /// <summary>
        /// Команда для добавления блюда.
        /// </summary>
        public AddCoreToDbCommand<DishesTableVM> AddCoreToDbCommand { get; set; }

        /// <summary>
        /// Конструктор вью-модели таблицы с клиентами.
        /// </summary>
        public DishesTableVM()
        {
            CurrentUser = new Users();
            SelectedDish = new Dishes();
            DishesTable = new DataTable();

            EditCoreSettingsFromDbCommand = new EditCoreSettingsFromDbCommand<DishesTableVM>();
            DeleteCoreFromDbCommand = new DeleteCoreFromDbCommand<DishesTableVM>();
            AddCoreToDbCommand = new AddCoreToDbCommand<DishesTableVM>();
        }
    }
}
