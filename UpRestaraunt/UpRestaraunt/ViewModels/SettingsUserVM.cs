namespace UpRestaraunt.ViewModels
{
    using UpRestaraunt.Commands;
    using UpRestaraunt.Database;

    /// <summary>
    /// Вью-модель страницы настроек пользователя.
    /// </summary>
    public class SettingsUserVM : BaseVM
    {
        /// <inheritdoc cref="LoginUser" />
        private string _loginUser { get; set; }

        /// <inheritdoc cref="Password" />
        private string _passwordUser { get; set; }

        /// <inheritdoc cref="CurrentUser" />
        private Users _currentUser { get; set; }

        /// <summary>
        /// Команда для изменения логина/пароля пользователя.
        /// </summary>
        public EditUserSettingsCommand EditUserSettingsCommand { get; }

        /// <summary>
        /// Команда для удаления пользователя (все связанные с ним записи также удалятся).
        /// </summary>
        public DeleteUserCommand DeleteUserCommand { get; }

        /// <summary>
        /// Логин.
        /// </summary>
        public string LoginUser
        {
            get { return _loginUser; }
            set
            {
                _loginUser = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string PasswordUser
        {
            get { return _passwordUser; }
            set
            {
                _passwordUser = value;
                OnPropertyChanged();
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
                LoginUser = _currentUser?.Login;
                PasswordUser = _currentUser?.Password;
            }
        }

        /// <summary>
        /// Создать вью-модель страницы настроек пользователя.
        /// </summary>
        public SettingsUserVM()
        {
            CurrentUser = new Users();
            EditUserSettingsCommand = new EditUserSettingsCommand();
            DeleteUserCommand = new DeleteUserCommand();
        }
    }
}
