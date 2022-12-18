namespace UpRestaraunt.ViewModels.Tables
{
    using System.Data;
    using UpRestaraunt.Commands;
    using UpRestaraunt.Converters;
    using UpRestaraunt.Database;

    /// <summary>
    /// Вью-модель таблицы с клиентами.
    /// </summary>
    public class ClientTableVM : BaseVM
    {
        /// <inheritdoc cref="SelectedRow" />
        private DataRowView _selectedRow { get; set; }

        /// <inheritdoc cref="CurrentUser" />
        private Users _currentUser { get; set; }

        /// <inheritdoc cref="ClientsTable" />
        private DataTable _clientsTable { get; set; }

        /// <inheritdoc cref="LastName" />
        private string _lastName { get; set; }

        /// <inheritdoc cref="FirstName" />
        private string _firstName { get; set; }

        /// <inheritdoc cref="MiddleName" />
        private string _middleName { get; set; }

        /// <inheritdoc cref="Address" />
        private string _address { get; set; }

        /// <inheritdoc cref="NumberPhone" />
        private string _numberPhone { get; set; }

        /// <inheritdoc cref="CountOrders" />
        private string _countOrders { get; set; }

        /// <inheritdoc cref="IdVisit" />
        private int _idVisit { get; set; }

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
        public Clients SelectedClient { get; set; }

        /// <summary>
        /// Представление таблицы.
        /// </summary>
        public DataView DataView => ClientsTable.DefaultView;

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

                SelectedClient.ConvertToCoreDbFromRow(ClientsTable, SelectedRow);
                OnPropertyChanged(nameof(SelectedClient));

                LastName = SelectedClient.Last_name;
                FirstName = SelectedClient.First_name;
                MiddleName = SelectedClient.Middle_name;
                Address = SelectedClient.Address;
                NumberPhone = SelectedClient.Number_phone;
                CountOrders = SelectedClient.Count_orders;
                IdVisit = SelectedClient.Id_visit is int selectedClientIdVisit ? selectedClientIdVisit : 0;
            }
        }

        /// <summary>
        /// Табличное представление информации о клиентах.
        /// </summary>
        public DataTable ClientsTable
        {
            get 
            { 
                return _clientsTable;
            }
            set
            {
                _clientsTable = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(DataView));
            }
        }

        /// <summary>
        /// Отображаемое значение фамилии в таблице.
        /// </summary>
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Отображаемое значение имени в таблице.
        /// </summary>
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Отображаемое значение отчества в таблице.
        /// </summary>
        public string MiddleName
        {
            get
            {
                return _middleName;
            }
            set
            {
                _middleName = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Отображаемое значение адреса в таблице.
        /// </summary>
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Отображаемое значение номера телефона в таблице.
        /// </summary>
        public string NumberPhone
        {
            get
            {
                return _numberPhone;
            }
            set
            {
                _numberPhone = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Отображаемое значение количества заказов в таблице.
        /// </summary>
        public string CountOrders
        {
            get
            {
                return _countOrders;
            }
            set
            {
                _countOrders = value;
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
        /// Команда для изменения записи о клиенте.
        /// </summary>
        public EditCoreSettingsFromDbCommand<ClientTableVM> EditCoreSettingsFromDbCommand { get; set; }

        /// <summary>
        /// Команда для удаления клиента.
        /// </summary>
        public DeleteCoreFromDbCommand<ClientTableVM> DeleteCoreFromDbCommand { get; set; }

        /// <summary>
        /// Команда для добавления клиента.
        /// </summary>
        public AddCoreToDbCommand<ClientTableVM> AddCoreToDbCommand { get; set; }

        /// <summary>
        /// Конструктор вью-модели таблицы с клиентами.
        /// </summary>
        public ClientTableVM()
        {
            CurrentUser = new Users();
            SelectedClient = new Clients();
            ClientsTable = new DataTable();

            EditCoreSettingsFromDbCommand = new EditCoreSettingsFromDbCommand<ClientTableVM>();
            DeleteCoreFromDbCommand = new DeleteCoreFromDbCommand<ClientTableVM>();
            AddCoreToDbCommand = new AddCoreToDbCommand<ClientTableVM>();
        }
    }
}
