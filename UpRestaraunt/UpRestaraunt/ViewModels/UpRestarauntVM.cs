namespace UpRestaraunt.ViewModels
{
    using System.ComponentModel;

    using UpRestaraunt.Commands;
    using UpRestaraunt.Database;

    /// <summary>
    /// Вью-модель всего приложения.
    /// </summary>
    public class UpRestarauntVM : BaseVM
    {
        /// <inheritdoc cref="IsMainPage" />
        private bool _isMainPage { get; set; }

        /// <inheritdoc cref="IsSettingsPage" />
        private bool _isSettingsPage { get; set; }

        /// <inheritdoc cref="IsTablesPage" />
        private bool _isTablesPage { get; set; }

        /// <inheritdoc cref="IsAuthentication" />
        private bool _isAuthentication { get; set; }

        /// <inheritdoc cref="CurrentUser" />
        private Users _currentUser { get; set; }

        /// <summary>
        /// Вью-модель контрола аутентификации: авторизации/регистрации.
        /// </summary>
        public AuthenticationVM AuthenticationVM { get; set; }

        /// <summary>
        /// Вью-модель главной страницы приложения.
        /// </summary>
        public MainPageVM MainPageVM { get; set; }

        /// <summary>
        /// Вью-модель настроек пользователя.
        /// </summary>
        public SettingsUserVM SettingsUserVM { get; set; }

        /// <summary>
        /// Вью-модель вкладки с таблицами.
        /// </summary>
        public TabTablesVM TabTablesVM { get; set; }

        /// <summary>
        /// Отображать главную страницу?
        /// </summary>
        public bool IsMainPage
        {
            get
            {
                return _isMainPage;
            }
            set
            {
                _isMainPage = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Отображать страницу с настройками?
        /// </summary>
        public bool IsSettingsPage
        {
            get
            {
                return _isSettingsPage;
            }
            set
            {
                _isSettingsPage = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Отображать страницу с таблицами?
        /// </summary>
        public bool IsTablesPage
        {
            get
            {
                return _isTablesPage;
            }
            set
            {
                _isTablesPage = value;
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
        /// Команда перехода на главную страницу.
        /// </summary>
        public SwitchToMainPageCommand SwitchToMainPageCommand { get; set; }

        /// <summary>
        /// Команда перехода на страницу с настройками.
        /// </summary>
        public SwitchToSettingsPageCommand SwitchToSettingsPageCommand { get; set; }

        /// <summary>
        /// Команда перехода на страницу с таблицами.
        /// </summary>
        public SwitchToTablesPageCommand SwitchToTablesPageCommand { get; set; }

        /// <summary>
        /// Конструктор вью-модели всего приложения.
        /// </summary>
        public UpRestarauntVM()
        {
            AuthenticationVM = new AuthenticationVM();
            MainPageVM = new MainPageVM();
            SettingsUserVM = new SettingsUserVM();
            TabTablesVM = new TabTablesVM();

            CurrentUser = new Users();
            IsAuthentication = true;

            SwitchToMainPageCommand = new SwitchToMainPageCommand();
            SwitchToSettingsPageCommand = new SwitchToSettingsPageCommand();
            SwitchToTablesPageCommand = new SwitchToTablesPageCommand();

            AuthenticationVM.PropertyChanged += AuthenticationVmPropertyChanged;
            SettingsUserVM.PropertyChanged += SettingsUserVmPropertyChanged;
        }

        /// <summary>
        /// Событие изменения состояния вью-модели аутентификации.
        /// </summary>
        /// <param name="settingsUserVM"> Вью-модель настроек пользователя. </param>
        /// <param name="propertyChanged"> Изменившееся свойство. </param>
        private void SettingsUserVmPropertyChanged(object settingsUserVM, PropertyChangedEventArgs propertyChanged)
        {
            var currentUser = (settingsUserVM as SettingsUserVM).CurrentUser;
            if (currentUser == null)
            {
                AuthenticationVM.IsAuthentication = true;
                IsAuthentication = true;
                IsMainPage = false;
                IsSettingsPage = false;
                IsTablesPage = false;
            }
        }

        /// <summary>
        /// Событие изменения состояния вью-модели аутентификации.
        /// </summary>
        /// <param name="authenticationVM"> Вью-модель аутентификации. </param>
        /// <param name="propertyChanged"> Изменившееся свойство. </param>
        private void AuthenticationVmPropertyChanged(object authenticationVM, PropertyChangedEventArgs propertyChanged)
        {
            IsMainPage = !(authenticationVM as AuthenticationVM).IsAuthentication;
            IsAuthentication = (authenticationVM as AuthenticationVM).IsAuthentication;

            if (!IsAuthentication)
            {
                var currentUser = (authenticationVM as AuthenticationVM).CurrentUser;
                CurrentUser = currentUser;
                SettingsUserVM.CurrentUser = currentUser;
                TabTablesVM.CurrentUser = currentUser;
                SwitchToTablesPageCommand.IsUploadTables = true;
            }
        }
    }
}
