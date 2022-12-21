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
                DishesTableVM.CurrentUser = value;
                DishesInOrderTableVM.CurrentUser = value;
                EmployeeTableVM.CurrentUser = value;
                HallsTableVM.CurrentUser = value;
                MenuTableVM.CurrentUser = value;
                OrdersTableVM.CurrentUser = value;
                PostsTableVM.CurrentUser = value;
                TablesTableVM.CurrentUser = value;
                TypesMenuTableVM.CurrentUser = value;
                VisitsTableVM.CurrentUser = value;
            }
        }

        /// <summary>
        /// Вью-модель таблицы с клиентами.
        /// </summary>
        public ClientTableVM ClientTableVM { get; set; }

        /// <summary>
        /// Вью-модель таблицы с блюдами.
        /// </summary>
        public DishesTableVM DishesTableVM { get; set; }

        /// <summary>
        /// Вью-модель таблицы с блюдами в заказе.
        /// </summary>
        public DishesInOrderTableVM DishesInOrderTableVM { get; set; }

        /// <summary>
        /// Вью-модель таблицы с работниками.
        /// </summary>
        public EmployeeTableVM EmployeeTableVM { get; set; }

        /// <summary>
        /// Вью-модель таблицы с залами.
        /// </summary>
        public HallsTableVM HallsTableVM { get; set; }

        /// <summary>
        /// Вью-модель таблицы с меню.
        /// </summary>
        public MenuTableVM MenuTableVM { get; set; } 

        /// <summary>
        /// Вью-модель таблицы с заказом.
        /// </summary>
        public OrdersTableVM OrdersTableVM { get; set; }

        /// <summary>
        /// Вью-модель таблицы с должностями.
        /// </summary>
        public PostsTableVM PostsTableVM { get; set; }

        /// <summary>
        /// Вью-модель таблицы со столиками.
        /// </summary>
        public TablesTableVM TablesTableVM { get; set; } 

        /// <summary>
        /// Вью-модель таблицы с типами меню.
        /// </summary>
        public TypesMenuTableVM TypesMenuTableVM { get; set; }

        /// <summary>
        /// Вью-модель таблицы с посещениями.
        /// </summary>
        public VisitsTableVM VisitsTableVM { get; set; }

        /// <summary>
        /// Создать вью-модель страницы с таблицами.
        /// </summary>
        public TabTablesVM()
        {
            ClientTableVM = new ClientTableVM();
            DishesTableVM = new DishesTableVM();
            DishesInOrderTableVM = new DishesInOrderTableVM();
            EmployeeTableVM = new EmployeeTableVM();
            HallsTableVM = new HallsTableVM();
            MenuTableVM = new MenuTableVM();
            OrdersTableVM = new OrdersTableVM();
            PostsTableVM = new PostsTableVM();
            TablesTableVM = new TablesTableVM();
            TypesMenuTableVM = new TypesMenuTableVM();
            VisitsTableVM = new VisitsTableVM();

            CurrentUser = new Users();
        }
    }
}
