namespace UpRestaraunt.Commands
{
    using System;
    using System.Windows;
    using UpRestaraunt.Converters;
    using UpRestaraunt.Database;
    using UpRestaraunt.ViewModels.Tables;

    /// <summary>
    /// Команда для изменения записи о клиенте.
    /// </summary>
    public class EditCoreSettingsFromDbCommand<T> : BaseTypeCommand<T>
    {
        /// <summary>
        /// Выполнить команду для изменения состояния клиента.
        /// </summary>
        /// <param name="tableVM"> Вью-модель страницы с таблицами. </param>
        protected override void Execute(T tableVM)
        {
            var context = RestaurantEntities.GetContext();
            try
            {
                if (tableVM is ClientTableVM clientTableVM)
                {
                    var editableClient = context.Clients.Find(clientTableVM.SelectedClient.Id_client);

                    editableClient.First_name = clientTableVM.FirstName;
                    editableClient.Middle_name = clientTableVM.MiddleName;
                    editableClient.Last_name = clientTableVM.LastName;
                    editableClient.Address = clientTableVM.Address;
                    editableClient.Number_phone = clientTableVM.NumberPhone;
                    editableClient.Count_orders = clientTableVM.CountOrders;
                    editableClient.Id_visit = clientTableVM.IdVisit;
                    editableClient.Id_user = clientTableVM.CurrentUser.Id_user;

                    clientTableVM.SelectedRow.ConvertToRowDbFromCore(clientTableVM.ClientsTable, editableClient);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(tableVM));
                }

                context.SaveChanges();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Редактирование, ошибка.");
            }
        }

        /// <inheritdoc />
        protected override bool CanExecute(T tableVM)
        {
            return base.CanExecute(tableVM);
        }
    }
}
