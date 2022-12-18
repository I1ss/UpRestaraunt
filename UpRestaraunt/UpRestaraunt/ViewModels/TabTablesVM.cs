namespace UpRestaraunt.ViewModels
{
    using UpRestaraunt.Database;
    using UpRestaraunt.ViewModels.Tables;

    /// <summary>
    /// Вью-модель страницы с таблицами.
    /// </summary>
    public class TabTablesVM : BaseVM
    {
        /// <inheritdoc cref="CurrentUser" />
        private Users _currentUser { get; set; }

        /// <summary>
        /// Текущий авторизованный пользователь.
        /// </summary>
        public Users CurrentUser
        {
            get 
            { 
                return _currentUser; 
            }
            set
            {
                _currentUser = value;
                OnPropertyChanged();

                ClientTableVM.CurrentUser = value;
            }
        }

        /// <summary>
        /// Вью-модель таблицы с клиентами.
        /// </summary>
        public ClientTableVM ClientTableVM { get; set; }

        /// <summary>
        /// Создать вью-модель страницы с таблицами.
        /// </summary>
        public TabTablesVM()
        {
            ClientTableVM = new ClientTableVM();
            CurrentUser = new Users();
        }
    }
}
