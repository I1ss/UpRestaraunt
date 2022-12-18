namespace UpRestaraunt.Commands
{
    using System;
    using System.Linq;
    using System.Windows;

    using UpRestaraunt.Database;
    using UpRestaraunt.ViewModels;

    /// <summary>
    /// Команда для авторизации.
    /// </summary>
    public class AuthorizationCommand : BaseTypeCommand<AuthenticationVM>
    {
        /// <summary>
        /// Выполнить команду для авторизации.
        /// </summary>
        /// <param name="authenticationVM"> Вью-модель контрола аутентификации: авторизации/регистрации. </param>
        protected override void Execute(AuthenticationVM authenticationVM)
        {
            var context = RestaurantEntities.GetContext();
            var userFromDb = context?.Users?.Where(user => user.Login == authenticationVM.LoginUser && 
                user.Password == authenticationVM.PasswordUser);

            if (userFromDb.Any())
            {
                authenticationVM.CurrentUser = userFromDb.SingleOrDefault();
                authenticationVM.IsAuthentication = false;
                MessageBox.Show("Вы успешно авторизовались!", "Авторизация.");
            }
            else
                MessageBox.Show("Вы ввели неверный логин или пароль.", "Авторизация, ошибка.");
        }

        /// <inheritdoc />
        protected override bool CanExecute(AuthenticationVM authenticationVM)
        {
            return authenticationVM.IsRegistration == true;
        }
    }
}