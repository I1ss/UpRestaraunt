namespace UpRestaraunt.Commands
{
    using System.Data;
    using System.Data.SqlClient;

    using UpRestaraunt.Database;
    using UpRestaraunt.Utilities;
    using UpRestaraunt.ViewModels;

    /// <summary>
    /// Команда перехода на страницу с таблицами.
    /// </summary>
    public class SwitchToTablesPageCommand : BaseTypeCommand<UpRestarauntVM>
    {
        /// <summary>
        /// Контекст базы данных.
        /// </summary>
        private RestaurantEntities _context;

        /// <summary>
        /// Подключение к базе данных.
        /// </summary>
        private SqlConnection _sqlConnection;

        /// <summary>
        /// Свойство, по которому отбираются записи из таблицы.
        /// </summary>
        private string _propertyName;

        /// <summary>
        /// Id авторизованного пользователя.
        /// </summary>
        private string _idUser;

        /// <summary>
        /// Нужно ли обновить таблицы?
        /// </summary>
        public bool IsUploadTables;

        /// <summary>
        /// Выполнить команду перехода на страницу с таблицами.
        /// </summary>
        /// <param name="upRestarauntVM"> Вью-модель всего приложения. </param>
        protected override void Execute(UpRestarauntVM upRestarauntVM)
        {
            upRestarauntVM.IsMainPage = false;
            upRestarauntVM.IsSettingsPage = false;
            upRestarauntVM.IsTablesPage = true;

            if (!IsUploadTables)
                return;

            IsUploadTables = false;
            _propertyName = nameof(upRestarauntVM.CurrentUser.Id_user);
            _idUser = upRestarauntVM.CurrentUser.Id_user.ToString();
            _context = RestaurantEntities.GetContext();
            _sqlConnection = new SqlConnection(DataBaseUtilities.CONNECTION_STRING);
            _sqlConnection.Open();

            upRestarauntVM.TabTablesVM.ClientTableVM.ClientsTable = GetUpdatedTable(nameof(_context.Clients));
            upRestarauntVM.TabTablesVM.DishesTableVM.DishesTable = GetUpdatedTable(nameof(_context.Dishes));
            upRestarauntVM.TabTablesVM.DishesInOrderTableVM.DishesInOrderTable = GetUpdatedTable(nameof(_context.Dishes_in_order));
            upRestarauntVM.TabTablesVM.EmployeeTableVM.EmployeeTable = GetUpdatedTable(nameof(_context.Employees));
            upRestarauntVM.TabTablesVM.HallsTableVM.HallsTable = GetUpdatedTable(nameof(_context.Halls));
            upRestarauntVM.TabTablesVM.MenuTableVM.MenuTable = GetUpdatedTable(nameof(_context.Menus));
            upRestarauntVM.TabTablesVM.OrdersTableVM.OrderTable = GetUpdatedTable(nameof(_context.Orders));
            upRestarauntVM.TabTablesVM.PostsTableVM.PostTable = GetUpdatedTable(nameof(_context.Posts));
            upRestarauntVM.TabTablesVM.TablesTableVM.TabTable = GetUpdatedTable(nameof(_context.Tables));
            upRestarauntVM.TabTablesVM.TypesMenuTableVM.TypeMenuTable = GetUpdatedTable(nameof(_context.Types_menu));
            upRestarauntVM.TabTablesVM.VisitsTableVM.VisitsTable = GetUpdatedTable(nameof(_context.Visits));

            _sqlConnection.Close();
        }

        /// <summary>
        /// Получить обновленную таблицу из базы данных.
        /// </summary>
        /// <param name="table"> Обновляемая таблица. </param>
        private DataTable GetUpdatedTable(string table)
        {
            var dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand(DataBaseUtilities.BuildSqlSelectRequest(table, _propertyName, _idUser), _sqlConnection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dataTable);
            dataTable.Columns.Remove(_propertyName);
            return dataTable;
        }

        /// <inheritdoc />
        protected override bool CanExecute(UpRestarauntVM upRestarauntVM)
        {
            return base.CanExecute(upRestarauntVM);
        }
    }
}
