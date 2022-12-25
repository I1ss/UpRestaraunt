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
    /// Вью-модель таблицы с пользователями.
    /// </summary>
    public class UsersTableVM : BaseVM
    {
        /// <inheritdoc cref="SelectedRow" />
        private DataRowView _selectedRow { get; set; }

        /// <inheritdoc cref="CurrentUser" />
        private Users _currentUser { get; set; }

        /// <inheritdoc cref="UsersTable" />
        private DataTable _usersTable { get; set; }

        /// <inheritdoc cref="IdUser" />
        private int? _idUser { get; set; }

        /// <inheritdoc cref="Login" />
        private string _login { get; set; }

        /// <inheritdoc cref="Password" />
        private string _password { get; set; }

        /// <inheritdoc cref="IsAdmin" />
        private bool _isAdmin { get; set; }

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

                if (UsersTable.Rows.Count != 0 && Filter != string.Empty)
                    UsersTable.DefaultView.RowFilter = $"{nameof(SelectedUser.Id_user)} = {Filter}";
                else
                    UsersTable.DefaultView.RowFilter = string.Empty;
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
        public Users SelectedUser { get; set; }

        /// <summary>
        /// Представление таблицы.
        /// </summary>
        public DataView DataView => UsersTable.DefaultView;

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

                SelectedUser.ConvertToCoreDbFromRow(UsersTable, SelectedRow);
                OnPropertyChanged(nameof(SelectedUser));

                IdUser = SelectedUser.Id_user;
                Login = SelectedUser.Login;
                Password = SelectedUser.Password;
                IsAdmin = SelectedUser.Is_admin;
            }
        }

        /// <summary>
        /// Табличное представление информации о пользователях.
        /// </summary>
        public DataTable UsersTable
        {
            get
            {
                return _usersTable;
            }
            set
            {
                _usersTable = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(DataView));
            }
        }

        /// <summary>
        /// Отображаемое значение id пользователя.
        /// </summary>
        public int? IdUser
        {
            get
            {
                return _idUser;
            }
            set
            {
                _idUser = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Отображаемое логина пользователя в таблице.
        /// </summary>
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Отображаемое значение пароля пользователя в таблице.
        /// </summary>
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Отображаемое значение "админ ли это" в таблице.
        /// </summary>
        public bool IsAdmin
        {
            get
            {
                return _isAdmin;
            }
            set
            {
                _isAdmin = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда для изменения записи о пользователе.
        /// </summary>
        public EditCoreSettingsFromDbCommand<UsersTableVM> EditCoreSettingsFromDbCommand { get; set; }

        /// <summary>
        /// Команда для удаления пользователя.
        /// </summary>
        public DeleteCoreFromDbCommand<UsersTableVM> DeleteCoreFromDbCommand { get; set; }

        /// <summary>
        /// Команда для добавления пользователя.
        /// </summary>
        public AddCoreToDbCommand<UsersTableVM> AddCoreToDbCommand { get; set; }

        /// <summary>
        /// Конструктор вью-модели таблицы с пользователями.
        /// </summary>
        public UsersTableVM()
        {
            CurrentUser = new Users();
            SelectedUser = new Users();
            UsersTable = new DataTable();
            EditCoreSettingsFromDbCommand = new EditCoreSettingsFromDbCommand<UsersTableVM>();
            DeleteCoreFromDbCommand = new DeleteCoreFromDbCommand<UsersTableVM>();
            AddCoreToDbCommand = new AddCoreToDbCommand<UsersTableVM>();

            Filter = string.Empty;
        }
    }
}
