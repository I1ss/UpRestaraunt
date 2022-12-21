namespace UpRestaraunt.ViewModels.Tables
{
    using System.Data;
    using UpRestaraunt.Commands;
    using UpRestaraunt.Converters;
    using UpRestaraunt.Database;

    /// <summary>
    /// Вью-модель таблицы с клиентами.
    /// </summary>
    public class EmployeeTableVM : BaseVM
    {
        /// <inheritdoc cref="SelectedRow" />
        private DataRowView _selectedRow { get; set; }

        /// <inheritdoc cref="CurrentUser" />
        private Users _currentUser { get; set; }

        /// <inheritdoc cref="EmployeeTable" />
        private DataTable _employeeTable { get; set; }

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

        /// <inheritdoc cref="IdPost" />
        private int _idPost { get; set; }

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

                if (EmployeeTable.Rows.Count != 0 && Filter != string.Empty)
                    EmployeeTable.DefaultView.RowFilter = $"{nameof(SelectedEmployee.Last_name)} = '{Filter}'";
                else
                    EmployeeTable.DefaultView.RowFilter = string.Empty;
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
        /// Выбранный работник.
        /// </summary>
        public Employees SelectedEmployee { get; set; }

        /// <summary>
        /// Представление таблицы.
        /// </summary>
        public DataView DataView => EmployeeTable.DefaultView;

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

                SelectedEmployee.ConvertToCoreDbFromRow(EmployeeTable, SelectedRow);
                OnPropertyChanged(nameof(SelectedEmployee));

                LastName = SelectedEmployee.Last_name;
                FirstName = SelectedEmployee.First_name;
                MiddleName = SelectedEmployee.Middle_name;
                Address = SelectedEmployee.Address;
                NumberPhone = SelectedEmployee.Number_phone;
                IdPost = SelectedEmployee.Id_post is int selectedEmployeeIdPost ? selectedEmployeeIdPost : 0;
            }
        }

        /// <summary>
        /// Табличное представление информации о работниках.
        /// </summary>
        public DataTable EmployeeTable
        {
            get
            {
                return _employeeTable;
            }
            set
            {
                _employeeTable = value;

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
        /// Отображаемое значение id должности в таблице.
        /// </summary>
        public int IdPost
        {
            get
            {
                return _idPost;
            }
            set
            {
                _idPost = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда для изменения записи о клиенте.
        /// </summary>
        public EditCoreSettingsFromDbCommand<EmployeeTableVM> EditCoreSettingsFromDbCommand { get; set; }

        /// <summary>
        /// Команда для удаления клиента.
        /// </summary>
        public DeleteCoreFromDbCommand<EmployeeTableVM> DeleteCoreFromDbCommand { get; set; }

        /// <summary>
        /// Команда для добавления клиента.
        /// </summary>
        public AddCoreToDbCommand<EmployeeTableVM> AddCoreToDbCommand { get; set; }

        /// <summary>
        /// Конструктор вью-модели таблицы с клиентами.
        /// </summary>
        public EmployeeTableVM()
        {
            CurrentUser = new Users();
            SelectedEmployee = new Employees();
            EmployeeTable = new DataTable();

            EditCoreSettingsFromDbCommand = new EditCoreSettingsFromDbCommand<EmployeeTableVM>();
            DeleteCoreFromDbCommand = new DeleteCoreFromDbCommand<EmployeeTableVM>();
            AddCoreToDbCommand = new AddCoreToDbCommand<EmployeeTableVM>();
        }
    }
}
