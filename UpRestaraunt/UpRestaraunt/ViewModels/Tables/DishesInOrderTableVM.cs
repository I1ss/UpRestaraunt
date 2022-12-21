namespace UpRestaraunt.ViewModels.Tables
{
    using System;
    using System.Data;
    using System.Text.RegularExpressions;
    using UpRestaraunt.Commands;
    using UpRestaraunt.Converters;
    using UpRestaraunt.Database;

    /// <summary>
    /// Вью-модель таблицы с блюдами в заказе.
    /// </summary>
    public class DishesInOrderTableVM : BaseVM
    {
        /// <inheritdoc cref="SelectedRow" />
        private DataRowView _selectedRow { get; set; }

        /// <inheritdoc cref="CurrentUser" />
        private Users _currentUser { get; set; }

        /// <inheritdoc cref="DishesTable" />
        private DataTable _dishesTable { get; set; }

        /// <inheritdoc cref="IdOrder" />
        private int _idOrder { get; set; }

        /// <inheritdoc cref="IdDish" />
        private int _idDish { get; set; }

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

                if (DishesInOrderTable.Rows.Count != 0 && Filter != string.Empty)
                    DishesInOrderTable.DefaultView.RowFilter = $"{nameof(SelectedDishInOrder.Id_order)} = {Filter}";
                else
                    DishesInOrderTable.DefaultView.RowFilter = string.Empty;
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
        /// Выбранный пользователь.
        /// </summary>
        public Dishes_in_order SelectedDishInOrder { get; set; }

        /// <summary>
        /// Представление таблицы.
        /// </summary>
        public DataView DataView => DishesInOrderTable.DefaultView;

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

                SelectedDishInOrder.ConvertToCoreDbFromRow(DishesInOrderTable, SelectedRow);
                OnPropertyChanged(nameof(SelectedDishInOrder));

                IdOrder = SelectedDishInOrder.Id_order is int selectedDishOrderId ? selectedDishOrderId : 0;
                IdDish = SelectedDishInOrder.Id_dish is int selectedDishId ? selectedDishId : 0;
            }
        }

        /// <summary>
        /// Табличное представление информации о блюдах в заказе.
        /// </summary>
        public DataTable DishesInOrderTable
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
        /// Отображаемое значение id блюда в таблице.
        /// </summary>
        public int IdDish
        {
            get
            {
                return _idDish;
            }
            set
            {
                _idDish = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Отображаемое значение id заказа в таблице.
        /// </summary>
        public int IdOrder
        {
            get
            {
                return _idOrder;
            }
            set
            {
                _idOrder = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда для изменения записи о блюде в заказе.
        /// </summary>
        public EditCoreSettingsFromDbCommand<DishesInOrderTableVM> EditCoreSettingsFromDbCommand { get; set; }

        /// <summary>
        /// Команда для удаления блюда в заказе.
        /// </summary>
        public DeleteCoreFromDbCommand<DishesInOrderTableVM> DeleteCoreFromDbCommand { get; set; }

        /// <summary>
        /// Команда для добавления блюда в заказе.
        /// </summary>
        public AddCoreToDbCommand<DishesInOrderTableVM> AddCoreToDbCommand { get; set; }

        /// <summary>
        /// Конструктор вью-модели таблицы с блюдами в заказе.
        /// </summary>
        public DishesInOrderTableVM()
        {
            CurrentUser = new Users();
            SelectedDishInOrder = new Dishes_in_order();
            DishesInOrderTable = new DataTable();

            EditCoreSettingsFromDbCommand = new EditCoreSettingsFromDbCommand<DishesInOrderTableVM>();
            DeleteCoreFromDbCommand = new DeleteCoreFromDbCommand<DishesInOrderTableVM>();
            AddCoreToDbCommand = new AddCoreToDbCommand<DishesInOrderTableVM>();
        }
    }
}
