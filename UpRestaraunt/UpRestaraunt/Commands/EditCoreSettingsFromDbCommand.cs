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
                    EditTable(context, clientTableVM);
                else if (tableVM is DishesTableVM dishesTableVM)
                    EditTable(context, dishesTableVM);
                else if (tableVM is DishesInOrderTableVM dishesInOrderTableVM)
                    EditTable(context, dishesInOrderTableVM);
                else if (tableVM is EmployeeTableVM employeeTableVM)
                    EditTable(context, employeeTableVM);
                else if (tableVM is HallsTableVM hallsTableVM)
                    EditTable(context, hallsTableVM);
                else if (tableVM is MenuTableVM menuTableVM)
                    EditTable(context, menuTableVM);
                else if (tableVM is OrdersTableVM ordersTableVM)
                    EditTable(context, ordersTableVM);
                else if (tableVM is PostsTableVM postsTableVM)
                    EditTable(context, postsTableVM);
                else if (tableVM is TablesTableVM tablesTableVM)
                    EditTable(context, tablesTableVM);
                else if (tableVM is TypesMenuTableVM typesMenuTableVM)
                    EditTable(context, typesMenuTableVM);
                else if (tableVM is VisitsTableVM visitsTableVM)
                    EditTable(context, visitsTableVM);
                else
                    throw new ArgumentOutOfRangeException(nameof(tableVM), "Недопустимый тип данных.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Редактирование, ошибка.");
            }
        }

        /// <summary>
        /// Метод для сохранения изменений в таблице клиентов.
        /// </summary>
        /// <param name="context"> Контекст базы данных. </param>
        /// <param name="clientTableVM"> Вью-модель таблицы с клиентами. </param>
        private static void EditTable(RestaurantEntities context, ClientTableVM clientTableVM)
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

            context.SaveChanges();
            clientTableVM.SelectedRow.ConvertToRowDbFromCore(clientTableVM.ClientsTable, editableClient);
        }

        /// <inheritdoc cref="EditTable" />
        private static void EditTable(RestaurantEntities context, DishesTableVM dishesTableVM)
        {
            var editableDish = context.Dishes.Find(dishesTableVM.SelectedDish.Id_dish);

            editableDish.Title = dishesTableVM.Title;
            editableDish.Time_cooking = dishesTableVM.TimeCooking;
            editableDish.Price = dishesTableVM.Price;
            editableDish.Id_menu = dishesTableVM.IdMenu;
            editableDish.Id_user = dishesTableVM.CurrentUser.Id_user;

            context.SaveChanges();
            dishesTableVM.SelectedRow.ConvertToRowDbFromCore(dishesTableVM.DishesTable, editableDish);
        }

        /// <inheritdoc cref="EditTable" />
        private static void EditTable(RestaurantEntities context, DishesInOrderTableVM dishesInOrderTableVM)
        {
            var editableDishInOrder = context.Dishes_in_order.Find(dishesInOrderTableVM.SelectedDishInOrder.Id_dishes_in_order);

            editableDishInOrder.Id_order = dishesInOrderTableVM.IdOrder;
            editableDishInOrder.Id_dish = dishesInOrderTableVM.IdDish;
            editableDishInOrder.Id_user = dishesInOrderTableVM.CurrentUser.Id_user;

            context.SaveChanges();
            dishesInOrderTableVM.SelectedRow.ConvertToRowDbFromCore(dishesInOrderTableVM.DishesInOrderTable, editableDishInOrder);
        }

        /// <inheritdoc cref="EditTable" />
        private static void EditTable(RestaurantEntities context, EmployeeTableVM employeeTableVM)
        {
            var editableEmployee = context.Employees.Find(employeeTableVM.SelectedEmployee.Id_employee);

            editableEmployee.First_name = employeeTableVM.FirstName;
            editableEmployee.Middle_name = employeeTableVM.MiddleName;
            editableEmployee.Last_name = employeeTableVM.LastName;
            editableEmployee.Address = employeeTableVM.Address;
            editableEmployee.Number_phone = employeeTableVM.NumberPhone;
            editableEmployee.Id_post = employeeTableVM.IdPost;
            editableEmployee.Id_user = employeeTableVM.CurrentUser.Id_user;

            context.SaveChanges();
            employeeTableVM.SelectedRow.ConvertToRowDbFromCore(employeeTableVM.EmployeeTable, editableEmployee);
        }

        /// <inheritdoc cref="EditTable" />
        private static void EditTable(RestaurantEntities context, HallsTableVM hallsTableVM)
        {
            var editableHall = context.Halls.Find(hallsTableVM.SelectedHall.Id_hall);

            editableHall.Count_places = hallsTableVM.CountPlaces;
            editableHall.Ready_to_work = hallsTableVM.ReadyToWork;
            editableHall.Id_user = hallsTableVM.CurrentUser.Id_user;

            context.SaveChanges();
            hallsTableVM.SelectedRow.ConvertToRowDbFromCore(hallsTableVM.HallsTable, editableHall);
        }

        /// <inheritdoc cref="EditTable" />
        private static void EditTable(RestaurantEntities context, MenuTableVM menuTableVM)
        {
            var editableMenu = context.Menus.Find(menuTableVM.SelectedMenu.Id_menu);

            editableMenu.Id_type_menu = menuTableVM.IdTypeMenu;
            editableMenu.Id_hall = menuTableVM.IdHall;
            editableMenu.Id_user = menuTableVM.CurrentUser.Id_user;

            context.SaveChanges();
            menuTableVM.SelectedRow.ConvertToRowDbFromCore(menuTableVM.MenuTable, editableMenu);
        }

        /// <inheritdoc cref="EditTable" />
        private static void EditTable(RestaurantEntities context, OrdersTableVM ordersTableVM)
        {
            var editableOrder = context.Orders.Find(ordersTableVM.SelectedOrder.Id_order);

            editableOrder.Price = ordersTableVM.Price;
            editableOrder.Id_visit = ordersTableVM.IdVisit;
            editableOrder.Id_user = ordersTableVM.CurrentUser.Id_user;

            context.SaveChanges();
            ordersTableVM.SelectedRow.ConvertToRowDbFromCore(ordersTableVM.OrderTable, editableOrder);
        }

        /// <inheritdoc cref="EditTable" />
        private static void EditTable(RestaurantEntities context, PostsTableVM postsTableVM)
        {
            var editablePost = context.Posts.Find(postsTableVM.SelectedPost.Id_post);

            editablePost.Salary = postsTableVM.Salary;
            editablePost.Title = postsTableVM.Title;
            editablePost.Id_user = postsTableVM.CurrentUser.Id_user;

            context.SaveChanges();
            postsTableVM.SelectedRow.ConvertToRowDbFromCore(postsTableVM.PostTable, editablePost);
        }

        /// <inheritdoc cref="EditTable" />
        private static void EditTable(RestaurantEntities context, TablesTableVM tablesTableVM)
        {
            var editableTable = context.Tables.Find(tablesTableVM.SelectedTable.Id_table);

            editableTable.Id_hall = tablesTableVM.IdHall;
            editableTable.Id_user = tablesTableVM.CurrentUser.Id_user;

            context.SaveChanges();
            tablesTableVM.SelectedRow.ConvertToRowDbFromCore(tablesTableVM.TabTable, editableTable);
        }

        /// <inheritdoc cref="EditTable" />
        private static void EditTable(RestaurantEntities context, TypesMenuTableVM typesMenuTableVM)
        {
            var editableTypeMenu = context.Types_menu.Find(typesMenuTableVM.SelectedTypeMenu.Id_type_menu);

            editableTypeMenu.Count_dishes = typesMenuTableVM.CountDishes;
            editableTypeMenu.Title = typesMenuTableVM.Title;
            editableTypeMenu.Id_user = typesMenuTableVM.CurrentUser.Id_user;

            context.SaveChanges();
            typesMenuTableVM.SelectedRow.ConvertToRowDbFromCore(typesMenuTableVM.TypeMenuTable, editableTypeMenu);
        }

        /// <inheritdoc cref="EditTable" />
        private static void EditTable(RestaurantEntities context, VisitsTableVM visitsTableVM)
        {
            var editableVisit = context.Visits.Find(visitsTableVM.SelectedVisit.Id_visit);

            editableVisit.Time_visit = visitsTableVM.TimeVisit;
            editableVisit.Id_client = visitsTableVM.IdClient;
            editableVisit.Id_employee = visitsTableVM.IdEmployee;
            editableVisit.Id_table = visitsTableVM.IdTable;
            editableVisit.Id_user = visitsTableVM.CurrentUser.Id_user;

            context.SaveChanges();
            visitsTableVM.SelectedRow.ConvertToRowDbFromCore(visitsTableVM.VisitsTable, editableVisit);
        }

        /// <inheritdoc />
        protected override bool CanExecute(T tableVM)
        {
            return base.CanExecute(tableVM);
        }
    }
}
