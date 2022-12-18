namespace UpRestaraunt.Commands
{
    using System;
    using System.Linq;
    using System.Windows;

    using UpRestaraunt.Database;
    using UpRestaraunt.ViewModels;

    /// <summary>
    /// Команда для удаления пользователя (все связанные с ним записи также удалятся).
    /// </summary>
    public class DeleteUserCommand : BaseTypeCommand<SettingsUserVM>
    {
        /// <summary>
        /// Выполнить команду для удаления пользователя.
        /// </summary>
        /// <param name="settingsUserVM"> Вью-модель страницы настроек пользователя. </param>
        protected override void Execute(SettingsUserVM settingsUserVM)
        {
            try
            {
                var context = RestaurantEntities.GetContext();
                var currentUser = context.Users.FirstOrDefault(user => user.Login == settingsUserVM.CurrentUser.Login);
                context.Users.Remove(currentUser);
                context.SaveChanges();
                settingsUserVM.CurrentUser = null;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Удаление, ошибка.");
            }
        }

        /// <inheritdoc />
        protected override bool CanExecute(SettingsUserVM settingsUserVM)
        {
            return base.CanExecute(settingsUserVM) && settingsUserVM.CurrentUser != null;
        }
    }
}
