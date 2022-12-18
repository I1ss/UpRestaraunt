namespace UpRestaraunt.Commands
{
    using System;
    using System.Linq;
    using System.Windows;

    using UpRestaraunt.Database;
    using UpRestaraunt.ViewModels;

    /// <summary>
    /// Команда для изменения логина/пароля пользователя.
    /// </summary>
    public class EditUserSettingsCommand : BaseTypeCommand<SettingsUserVM>
    {
        /// <summary>
        /// Выполнить команду для изменения логина/пароля пользователя.
        /// </summary>
        /// <param name="settingsUserVM"> Вью-модель страницы настроек пользователя. </param>
        protected override void Execute(SettingsUserVM settingsUserVM)
        {
            try
            {
                var context = RestaurantEntities.GetContext();
                var currentUser = context.Users.FirstOrDefault(user => user.Login == settingsUserVM.CurrentUser.Login);
                currentUser.Login = settingsUserVM.LoginUser;
                currentUser.Password = settingsUserVM.PasswordUser;
                context.SaveChanges();
                settingsUserVM.CurrentUser = currentUser;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Редактирование, ошибка.");
            }
        }

        /// <inheritdoc />
        protected override bool CanExecute(SettingsUserVM settingsUserVM)
        {
            return base.CanExecute(settingsUserVM) && settingsUserVM.CurrentUser != null;
        }
    }
}
