namespace UpRestaraunt.Commands
{
    using UpRestaraunt.ViewModels;

    /// <summary>
    /// Команда перехода на главную страницу.
    /// </summary>
    public class SwitchToMainPageCommand : BaseTypeCommand<UpRestarauntVM>
    {
        /// <summary>
        /// Выполнить команду перехода на главную страницу.
        /// </summary>
        /// <param name="upRestarauntVM"> Вью-модель всего приложения. </param>
        protected override void Execute(UpRestarauntVM upRestarauntVM)
        {
            upRestarauntVM.IsMainPage = true;
            upRestarauntVM.IsSettingsPage = false;
            upRestarauntVM.IsTablesPage = false;
        }

        /// <inheritdoc />
        protected override bool CanExecute(UpRestarauntVM upRestarauntVM)
        {
            return base.CanExecute(upRestarauntVM);
        }
    }
}
