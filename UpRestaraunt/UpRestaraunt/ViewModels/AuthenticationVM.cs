namespace UpRestaraunt.ViewModels
{
    using System.Windows.Input;

    using UpRestaraunt.Commands;

    /// <summary>
    /// Вью-модель контрола аутентификации: авторизации/регистрации.
    /// </summary>
    public class AuthenticationVM : BaseVM
    {
        /// <inheritdoc cref="SwitchAuthentication" />
        private string _switchAuthentication { get; set; }

        /// <inheritdoc cref="LoginUser" />
        private string _loginUser { get; set; }

        /// <inheritdoc cref="Password" />
        private string _passwordUser { get; set; }

        /// <inheritdoc cref="IsRegistrationUser" />
        private bool _isRegistration { get; set; }

        /// <inheritdoc cref="IsAuthentication" />
        private bool _isAuthentication { get; set; }

        /// <summary>
        /// Состояние аутентификации, к которому можно перейти: регистрация/авторизация.
        /// </summary>
        public string SwitchAuthentication
        {
            get { return _switchAuthentication; }
            set
            {
                _switchAuthentication = value;
                OnPropertyChanged();
            }
        }

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
        /// Отображать кнопку регистрации?
        /// </summary>
        public bool IsRegistration
        {
            get
            {
                return _isRegistration;
            }
            set
            {
                _isRegistration = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Идёт процесс аутентификации? Влияет на отображение контрола аутентификации.
        /// </summary>
        public bool IsAuthentication
        {
            get
            {
                return _isAuthentication;
            }
            set
            {
                _isAuthentication = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда, когда пользователь собирается перейти к регистрации.
        /// </summary>
        public ICommand TryRegistrationCommand { get; set; }

        /// <summary>
        /// Команда, когда пользователь собирается зарегистрироваться.
        /// </summary>
        public ICommand RegistrationCommand { get; set; }

        /// <summary>
        /// Команда, когда пользователь собирается авторизироваться.
        /// </summary>
        public ICommand AuthorizationCommand { get; set; }

        /// <summary>
        /// Конструктор вью-модели контрола аутентификации: авторизации/регистрации..
        /// </summary>
        public AuthenticationVM()
        {
            SwitchAuthentication = "Регистрация";
            LoginUser = "Имя пользователя";
            PasswordUser = "Пароль";
            IsAuthentication = true;
            IsRegistration = true;
            TryRegistrationCommand = new TryToRegistrationCommand();
            RegistrationCommand = new RegistrationCommand();
            AuthorizationCommand = new AuthorizationCommand();
        }
    }
}
