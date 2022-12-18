namespace UpRestaraunt.Commands
{
    using System;
    using System.Linq;
    using System.Windows;

    using UpRestaraunt.Database;
    using UpRestaraunt.ViewModels;

    /// <summary>
    /// Команда для регистрации.
    /// </summary>
    public class RegistrationCommand : BaseTypeCommand<AuthenticationVM>
    {
        /// <summary>
        /// Выполнить команду для регистрации.
        /// </summary>
        /// <param name="authenticationVM"> Вью-модель контрола аутентификации: авторизации/регистрации. </param>
        protected override void Execute(AuthenticationVM authenticationVM)
        {
            try
            {
                var context = RestaurantEntities.GetContext();
                var userFromDb = context.Users.Where(user => user.Login == authenticationVM.LoginUser);
                if (userFromDb.Any())
                    throw new Exception("Пользователь с таким никнеймом уже существует!");

                var newUser = new Users();
                newUser.Login = authenticationVM.LoginUser;
                newUser.Password = authenticationVM.PasswordUser;
                context.Users.Add(newUser);

                RestaurantEntities.GetContext().SaveChanges();
                authenticationVM.CurrentUser = newUser;
                authenticationVM.IsAuthentication = false;
                MessageBox.Show("Поздравляем, Вы успешно зарегистрировались!", "Регистрация.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Регистрация, ошибка.");
            }

        }

        /// <inheritdoc />
        protected override bool CanExecute(AuthenticationVM authenticationVM)
        {
            return authenticationVM.IsRegistration == false;
        }
    }
}