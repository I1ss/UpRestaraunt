namespace UpRestaraunt.Commands
{
    using System;
    using System.Linq;
    using System.Windows;

    using UpRestaraunt.Database;
    using UpRestaraunt.ViewModels.Tables;

    /// <summary>
    /// Команда для удаления записи из таблицы.
    /// </summary>
    public class DeleteCoreFromDbCommand<T> : BaseTypeCommand<T>
    {
        /// <summary>
        /// Выполнить команду для удаления записи из таблицы.
        /// </summary>
        /// <param name="tableVM"> Вью-модель страницы с таблицей. </param>
        protected override void Execute(T tableVM)
        {
            var context = RestaurantEntities.GetContext();
            try
            {
                if (tableVM is ClientTableVM clientTableVM)
                {
                    var currentClient = context.Clients.FirstOrDefault(client => client.Id_client == clientTableVM.SelectedClient.Id_client);
                    context.Clients.Remove(currentClient);
                    clientTableVM.ClientsTable.Rows.Remove(clientTableVM.SelectedRow.Row);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(tableVM));
                }

                context.SaveChanges();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Удаление, ошибка.");
            }
        }

        /// <inheritdoc />
        protected override bool CanExecute(T tableVM)
        {
            return base.CanExecute(tableVM);
        }
    }
}
