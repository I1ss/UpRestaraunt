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
        /// Выполнить команду перехода на страницу с таблицами.
        /// </summary>
        /// <param name="upRestarauntVM"> Вью-модель всего приложения. </param>
        protected override void Execute(UpRestarauntVM upRestarauntVM)
        {
            upRestarauntVM.IsMainPage = false;
            upRestarauntVM.IsSettingsPage = false;
            upRestarauntVM.IsTablesPage = true;

            if (upRestarauntVM.TabTablesVM.ClientTableVM.ClientsTable.Columns.Count != 0)
                return;

            var context = RestaurantEntities.GetContext();
            var dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(DataBaseUtilities.CONNECTION_STRING);
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(DataBaseUtilities.BuildSqlSelectRequest(
                nameof(context.Clients), nameof(upRestarauntVM.CurrentUser.Id_user), upRestarauntVM.CurrentUser.Id_user.ToString()), connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dataTable);
            dataTable.Columns.Remove(nameof(upRestarauntVM.TabTablesVM.ClientTableVM.SelectedClient.Id_user));
            upRestarauntVM.TabTablesVM.ClientTableVM.ClientsTable = dataTable;
            connection.Close();
        }

        /// <inheritdoc />
        protected override bool CanExecute(UpRestarauntVM upRestarauntVM)
        {
            return base.CanExecute(upRestarauntVM);
        }
    }
}
