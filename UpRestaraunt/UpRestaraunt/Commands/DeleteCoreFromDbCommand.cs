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
                    DeleteFromDb(context, clientTableVM);
                else if (tableVM is DishesTableVM dishesTableVM)
                    DeleteFromDb(context, dishesTableVM);
                else if (tableVM is DishesInOrderTableVM dishesInOrderTableVM)
                    DeleteFromDb(context, dishesInOrderTableVM);
                else if (tableVM is EmployeeTableVM employeeTableVM)
                    DeleteFromDb(context, employeeTableVM);
                else if (tableVM is HallsTableVM hallsTableVM)
                    DeleteFromDb(context, hallsTableVM);
                else if (tableVM is MenuTableVM menuTableVM)
                    DeleteFromDb(context, menuTableVM);
                else if (tableVM is OrdersTableVM ordersTableVM)
                    DeleteFromDb(context, ordersTableVM);
                else if (tableVM is PostsTableVM postsTableVM)
                    DeleteFromDb(context, postsTableVM);
                else if (tableVM is TablesTableVM tablesTableVM)
                    DeleteFromDb(context, tablesTableVM);
                else if (tableVM is TypesMenuTableVM typesMenuTableVM)
                    DeleteFromDb(context, typesMenuTableVM);
                else if (tableVM is VisitsTableVM visitsTableVM)
                    DeleteFromDb(context, visitsTableVM);
                else if (tableVM is UsersTableVM usersTableVM)
                    DeleteFromDb(context, usersTableVM);
                else
                    throw new ArgumentOutOfRangeException(nameof(tableVM), "Недопустимый тип данных.");

                context.SaveChanges();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Удаление, ошибка.");
            }
        }

        /// <summary>
        /// Метод для удаления клиента из таблицы.
        /// </summary>
        /// <param name="context"> Контекст базы данных. </param>
        /// <param name="clientTableVM"> Вью-модель таблицы с клиентами. </param>
        private static void DeleteFromDb(RestaurantEntities context, ClientTableVM clientTableVM)
        {
            var currentClient = context.Clients.FirstOrDefault(client => client.Id_client == clientTableVM.SelectedClient.Id_client);
            context.Clients.Remove(currentClient);
            clientTableVM.ClientsTable.Rows.Remove(clientTableVM.SelectedRow.Row);
        }

        /// <inheritdoc cref="DeleteFromDb" />
        private static void DeleteFromDb(RestaurantEntities context, DishesTableVM dishesTableVM)
        {
            var currentDish = context.Dishes.FirstOrDefault(dish => dish.Id_dish == dishesTableVM.SelectedDish.Id_dish);
            context.Dishes.Remove(currentDish);
            dishesTableVM.DishesTable.Rows.Remove(dishesTableVM.SelectedRow.Row);
        }

        /// <inheritdoc cref="DeleteFromDb" />
        private static void DeleteFromDb(RestaurantEntities context, DishesInOrderTableVM dishesInOrderTableVM)
        {
            var currentDish = context.Dishes_in_order
                .FirstOrDefault(dishInOrder => dishInOrder.Id_dishes_in_order == dishesInOrderTableVM.SelectedDishInOrder.Id_dishes_in_order);
            context.Dishes_in_order.Remove(currentDish);
            dishesInOrderTableVM.DishesInOrderTable.Rows.Remove(dishesInOrderTableVM.SelectedRow.Row);
        }

        /// <inheritdoc cref="DeleteFromDb" />
        private static void DeleteFromDb(RestaurantEntities context, EmployeeTableVM employeeTableVM)
        {
            var currentEmployee = context.Employees.FirstOrDefault(employee => employee.Id_employee == employeeTableVM.SelectedEmployee.Id_employee);
            context.Employees.Remove(currentEmployee);
            employeeTableVM.EmployeeTable.Rows.Remove(employeeTableVM.SelectedRow.Row);
        }

        /// <inheritdoc cref="DeleteFromDb" />
        private static void DeleteFromDb(RestaurantEntities context, HallsTableVM hallsTableVM)
        {
            var currentHall = context.Halls.FirstOrDefault(hall => hall.Id_hall == hallsTableVM.SelectedHall.Id_hall);
            context.Halls.Remove(currentHall);
            hallsTableVM.HallsTable.Rows.Remove(hallsTableVM.SelectedRow.Row);
        }

        /// <inheritdoc cref="DeleteFromDb" />
        private static void DeleteFromDb(RestaurantEntities context, MenuTableVM menuTableVM)
        {
            var currentMenu = context.Menus.FirstOrDefault(menu => menu.Id_menu == menuTableVM.SelectedMenu.Id_menu);
            context.Menus.Remove(currentMenu);
            menuTableVM.MenuTable.Rows.Remove(menuTableVM.SelectedRow.Row);
        }

        /// <inheritdoc cref="DeleteFromDb" />
        private static void DeleteFromDb(RestaurantEntities context, OrdersTableVM ordersTableVM)
        {
            var currentOrder = context.Orders.FirstOrDefault(order => order.Id_order == ordersTableVM.SelectedOrder.Id_order);
            context.Orders.Remove(currentOrder);
            ordersTableVM.OrderTable.Rows.Remove(ordersTableVM.SelectedRow.Row);
        }

        /// <inheritdoc cref="DeleteFromDb" />
        private static void DeleteFromDb(RestaurantEntities context, PostsTableVM postsTableVM)
        {
            var currentPost = context.Posts.FirstOrDefault(post => post.Id_post == postsTableVM.SelectedPost.Id_post);
            context.Posts.Remove(currentPost);
            postsTableVM.PostTable.Rows.Remove(postsTableVM.SelectedRow.Row);
        }

        /// <inheritdoc cref="DeleteFromDb" />
        private static void DeleteFromDb(RestaurantEntities context, TablesTableVM tablesTableVM)
        {
            var currentTable = context.Tables.FirstOrDefault(table => table.Id_table == tablesTableVM.SelectedTable.Id_table);
            context.Tables.Remove(currentTable);
            tablesTableVM.TabTable.Rows.Remove(tablesTableVM.SelectedRow.Row);
        }

        /// <inheritdoc cref="DeleteFromDb" />
        private static void DeleteFromDb(RestaurantEntities context, TypesMenuTableVM typesMenuTableVM)
        {
            var currentTypeMenu = context.Types_menu.FirstOrDefault(typeMenu => typeMenu.Id_type_menu == typesMenuTableVM.SelectedTypeMenu.Id_type_menu);
            context.Types_menu.Remove(currentTypeMenu);
            typesMenuTableVM.TypeMenuTable.Rows.Remove(typesMenuTableVM.SelectedRow.Row);
        }

        /// <inheritdoc cref="DeleteFromDb" />
        private static void DeleteFromDb(RestaurantEntities context, VisitsTableVM visitsTableVM)
        {
            var currentVisit = context.Visits.FirstOrDefault(visit => visit.Id_visit == visitsTableVM.SelectedVisit.Id_visit);
            context.Visits.Remove(currentVisit);
            visitsTableVM.VisitsTable.Rows.Remove(visitsTableVM.SelectedRow.Row);
        }

        /// <inheritdoc cref="DeleteFromDb" />
        private static void DeleteFromDb(RestaurantEntities context, UsersTableVM usersTableVM)
        {
            var currentUser = context.Users.FirstOrDefault(visit => visit.Id_user == usersTableVM.SelectedUser.Id_user);
            context.Users.Remove(currentUser);
            usersTableVM.UsersTable.Rows.Remove(usersTableVM.SelectedRow.Row);
        }

        /// <inheritdoc />
        protected override bool CanExecute(T tableVM)
        {
            return base.CanExecute(tableVM);
        }
    }
}
