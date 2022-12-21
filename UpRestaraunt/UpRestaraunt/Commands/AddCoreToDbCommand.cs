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
                    AddToDb(context, clientTableVM);
                else if (tableVM is DishesTableVM dishesTableVM)
                    AddToDb(context, dishesTableVM);
                else if (tableVM is DishesInOrderTableVM dishesInOrderTableVM)
                    AddToDb(context, dishesInOrderTableVM);
                else if (tableVM is EmployeeTableVM employeeTableVM)
                    AddToDb(context, employeeTableVM);
                else if (tableVM is HallsTableVM hallsTableVM)
                    AddToDb(context, hallsTableVM);
                else if (tableVM is MenuTableVM menuTableVM)
                    AddToDb(context, menuTableVM);
                else if (tableVM is OrdersTableVM ordersTableVM)
                    AddToDb(context, ordersTableVM);
                else if (tableVM is PostsTableVM postsTableVM)
                    AddToDb(context, postsTableVM);
                else if (tableVM is TablesTableVM tablesTableVM)
                    AddToDb(context, tablesTableVM);
                else if (tableVM is TypesMenuTableVM typesMenuTableVM)
                    AddToDb(context, typesMenuTableVM);
                else if (tableVM is VisitsTableVM visitsTableVM)
                    AddToDb(context, visitsTableVM);
                else
                    throw new ArgumentOutOfRangeException(nameof(tableVM), "Недопустимый тип данных.");

                context.SaveChanges();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Добавление, ошибка.");
            }
        }

        /// <summary>
        /// Метод для добавления клиента в таблицу.
        /// </summary>
        /// <param name="context"> Контекст базы данных. </param>
        /// <param name="clientTableVM"> Вью-модель текущей таблицы. </param>
        private static void AddToDb(RestaurantEntities context, ClientTableVM clientTableVM)
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

            clientTableVM.ClientsTable.Rows.Add(client.Id_client, client.Last_name, client.First_name, client.Middle_name,
                client.Address, client.Number_phone, client.Count_orders, client.Id_visit);
        }

        /// <inheritdoc cref="AddToDb" />
        private static void AddToDb(RestaurantEntities context, DishesTableVM dishesTableVM)
        {
            var dish = new Dishes
            {
                Title = dishesTableVM.Title,
                Time_cooking = dishesTableVM.TimeCooking,
                Price = dishesTableVM.Price,
                Id_menu = dishesTableVM.IdMenu,
                Id_user = dishesTableVM.CurrentUser.Id_user,
            };

            context.Dishes.Add(dish);
            context.SaveChanges();

            dishesTableVM.DishesTable.Rows.Add(dish.Id_dish, dish.Title, dish.Time_cooking, dish.Price, dish.Id_menu);
        }

        /// <inheritdoc cref="AddToDb" />
        private static void AddToDb(RestaurantEntities context, DishesInOrderTableVM dishesInOrderTableVM)
        {
            var dishesInOrder = new Dishes_in_order
            {
                Id_dish = dishesInOrderTableVM.IdDish,
                Id_order = dishesInOrderTableVM.IdOrder,
                Id_user = dishesInOrderTableVM.CurrentUser.Id_user,
            };

            context.Dishes_in_order.Add(dishesInOrder);
            context.SaveChanges();

            dishesInOrderTableVM.DishesInOrderTable.Rows.Add(dishesInOrder.Id_dishes_in_order, dishesInOrderTableVM.IdOrder,
                dishesInOrder.Id_dish);
        }

        /// <inheritdoc cref="AddToDb" />
        private static void AddToDb(RestaurantEntities context, EmployeeTableVM employeeTableVM)
        {
            var employee = new Employees
            {
                First_name = employeeTableVM.FirstName,
                Middle_name = employeeTableVM.MiddleName,
                Last_name = employeeTableVM.LastName,
                Address = employeeTableVM.Address,
                Number_phone = employeeTableVM.NumberPhone,
                Id_post = employeeTableVM.IdPost,
                Id_user = employeeTableVM.CurrentUser.Id_user,
            };

            context.Employees.Add(employee);
            context.SaveChanges();

            employeeTableVM.EmployeeTable.Rows.Add(employee.Id_employee, employee.Last_name, employee.First_name, employee.Middle_name,
                employee.Address, employee.Number_phone, employee.Id_post);
        }

        /// <inheritdoc cref="AddToDb" />
        private static void AddToDb(RestaurantEntities context, HallsTableVM hallsTableVM)
        {
            var hall = new Halls
            {
                Count_places = hallsTableVM.CountPlaces,
                Ready_to_work = hallsTableVM.ReadyToWork,
                Id_user = hallsTableVM.CurrentUser.Id_user,
            };

            context.Halls.Add(hall);
            context.SaveChanges();

            hallsTableVM.HallsTable.Rows.Add(hall.Id_hall, hall.Count_places,hall.Ready_to_work);
        }

        /// <inheritdoc cref="AddToDb" />
        private static void AddToDb(RestaurantEntities context, MenuTableVM menuTableVM)
        {
            var menu = new Menus
            {
                Id_type_menu = menuTableVM.IdTypeMenu,
                Id_hall = menuTableVM.IdHall,
                Id_user = menuTableVM.CurrentUser.Id_user,
            };

            context.Menus.Add(menu);
            context.SaveChanges();

            menuTableVM.MenuTable.Rows.Add(menu.Id_menu, menu.Id_type_menu, menu.Id_hall);
        }

        /// <inheritdoc cref="AddToDb" />
        private static void AddToDb(RestaurantEntities context, OrdersTableVM ordersTableVM)
        {
            var order = new Orders
            {
                Price = ordersTableVM.Price,
                Id_visit = ordersTableVM.IdVisit,
                Id_user = ordersTableVM.CurrentUser.Id_user,
            };

            context.Orders.Add(order);
            context.SaveChanges();

            ordersTableVM.OrderTable.Rows.Add(order.Id_order, order.Price, order.Id_visit);
        }

        /// <inheritdoc cref="AddToDb" />
        private static void AddToDb(RestaurantEntities context, PostsTableVM postsTableVM)
        {
            var post = new Posts
            {
                Salary = postsTableVM.Salary,
                Title = postsTableVM.Title,
                Id_user = postsTableVM.CurrentUser.Id_user,
            };

            context.Posts.Add(post);
            context.SaveChanges();

            postsTableVM.PostTable.Rows.Add(post.Id_post, post.Salary, post.Title);
        }

        /// <inheritdoc cref="AddToDb" />
        private static void AddToDb(RestaurantEntities context, TablesTableVM tablesTableVM)
        {
            var table = new Tables
            {
                Id_hall = tablesTableVM.IdHall,
                Id_user = tablesTableVM.CurrentUser.Id_user,
            };

            context.Tables.Add(table);
            context.SaveChanges();

            tablesTableVM.TabTable.Rows.Add(table.Id_table, table.Id_hall);
        }

        /// <inheritdoc cref="AddToDb" />
        private static void AddToDb(RestaurantEntities context, TypesMenuTableVM typesMenuTableVM)
        {
            var typeMenu = new Types_menu
            {
                Count_dishes = typesMenuTableVM.CountDishes,
                Title = typesMenuTableVM.Title,
                Id_user = typesMenuTableVM.CurrentUser.Id_user,
            };

            context.Types_menu.Add(typeMenu);
            context.SaveChanges();

            typesMenuTableVM.TypeMenuTable.Rows.Add(typeMenu.Id_type_menu, typeMenu.Count_dishes, typeMenu.Title);
        }

        /// <inheritdoc cref="AddToDb" />
        private static void AddToDb(RestaurantEntities context, VisitsTableVM visitsTableVM)
        {
            var visit = new Visits
            {
                Time_visit = visitsTableVM.TimeVisit,
                Id_client = visitsTableVM.IdClient,
                Id_employee = visitsTableVM.IdEmployee,
                Id_table = visitsTableVM.IdTable,
                Id_user = visitsTableVM.CurrentUser.Id_user,
            };

            context.Visits.Add(visit);
            context.SaveChanges();

            visitsTableVM.VisitsTable.Rows.Add(visit.Id_visit, visit.Time_visit, visit.Id_client, visit.Id_employee, visit.Id_table);
        }

        /// <inheritdoc />
        protected override bool CanExecute(T tableVM)
        {
            return base.CanExecute(tableVM);
        }
    }
}
