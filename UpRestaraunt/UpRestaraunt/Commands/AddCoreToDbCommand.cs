namespace UpRestaraunt.Commands
{
    using System;
    using System.Windows;

    using UpRestaraunt.Database;
    using UpRestaraunt.ViewModels.Tables;

    /// <summary>
    /// Команда для добавления записи в таблицу.
    /// </summary>
    public class AddCoreToDbCommand<T> : BaseTypeCommand<T>
    {
        /// <summary>
        /// Выполнить команду для добавления записи в таблицу.
        /// </summary>
        /// <param name="tableVM"> Вью-модель страницы с таблицей. </param>
        protected override void Execute(T tableVM)
        {
            var context = RestaurantEntities.GetContext();
            try
            {
                if (tableVM is ClientTableVM clientTableVM)
                {
                    var client = new Clients
                    {
                        First_name = clientTableVM.FirstName,
                        Middle_name = clientTableVM.MiddleName,
                        Last_name = clientTableVM.LastName,
                        Address = clientTableVM.Address,
                        Number_phone = clientTableVM.NumberPhone,
                        Count_orders = clientTableVM.CountOrders,
                        Id_visit = clientTableVM.IdVisit,
                        Id_user = clientTableVM.CurrentUser.Id_user,
                    };

                    context.Clients.Add(client);
                    context.SaveChanges();
                    var test = client.Id_client;

                    clientTableVM.ClientsTable.Rows.Add(client.Id_client, client.Last_name, client.First_name, client.Middle_name,
                        client.Address, client.Number_phone, client.Count_orders, client.Id_visit);
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
