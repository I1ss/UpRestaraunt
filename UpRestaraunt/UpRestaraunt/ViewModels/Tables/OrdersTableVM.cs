namespace UpRestaraunt.ViewModels.Tables
{
    using System;
    using System.Data;
    using System.Text.RegularExpressions;
    using UpRestaraunt.Commands;
    using UpRestaraunt.Converters;
    using UpRestaraunt.Database;

    /// <summary>
    /// Вью-модель таблицы с заказами.
    /// </summary>
    public class OrdersTableVM : BaseVM
    {
        /// <inheritdoc cref="SelectedRow" />
        private DataRowView _selectedRow { get; set; }

        /// <inheritdoc cref="CurrentUser" />
        private Users _currentUser { get; set; }

        /// <inheritdoc cref="OrderTable" />
        private DataTable _orderTable { get; set; }

        /// <inheritdoc cref="Price" />
        private int _price { get; set; }

        /// <inheritdoc cref="IdVisit" />
        private int _idVisit { get; set; }

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

                if (OrderTable.Rows.Count != 0 && Filter != string.Empty)
                    OrderTable.DefaultView.RowFilter = $"{nameof(SelectedOrder.Id_visit)} = {Filter}";
                else
                    OrderTable.DefaultView.RowFilter = string.Empty;
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
        /// Выбранный заказ.
        /// </summary>
        public Orders SelectedOrder { get; set; }

        /// <summary>
        /// Представление таблицы.
        /// </summary>
        public DataView DataView => OrderTable.DefaultView;

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

                SelectedOrder.ConvertToCoreDbFromRow(OrderTable, SelectedRow);
                OnPropertyChanged(nameof(SelectedOrder));

                Price = SelectedOrder.Price;
                IdVisit = SelectedOrder.Id_visit is int selectedIdVisit ? selectedIdVisit : 0;
            }
        }

        /// <summary>
        /// Табличное представление информации о меню.
        /// </summary>
        public DataTable OrderTable
        {
            get
            {
                return _orderTable;
            }
            set
            {
                _orderTable = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(DataView));
            }
        }

        /// <summary>
        /// Отображаемое значение суммы заказа в таблице.
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
        /// Отображаемое значение id посещения в таблице.
        /// </summary>
        public int IdVisit
        {
            get
            {
                return _idVisit;
            }
            set
            {
                _idVisit = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда для изменения записи о заказе.
        /// </summary>
        public EditCoreSettingsFromDbCommand<OrdersTableVM> EditCoreSettingsFromDbCommand { get; set; }

        /// <summary>
        /// Команда для удаления заказа.
        /// </summary>
        public DeleteCoreFromDbCommand<OrdersTableVM> DeleteCoreFromDbCommand { get; set; }

        /// <summary>
        /// Команда для добавления заказа.
        /// </summary>
        public AddCoreToDbCommand<OrdersTableVM> AddCoreToDbCommand { get; set; }

        /// <summary>
        /// Конструктор вью-модели таблицы с заказом.
        /// </summary>
        public OrdersTableVM()
        {
            CurrentUser = new Users();
            SelectedOrder = new Orders();
            OrderTable = new DataTable();

            EditCoreSettingsFromDbCommand = new EditCoreSettingsFromDbCommand<OrdersTableVM>();
            DeleteCoreFromDbCommand = new DeleteCoreFromDbCommand<OrdersTableVM>();
            AddCoreToDbCommand = new AddCoreToDbCommand<OrdersTableVM>();
        }
    }
}
