namespace UpRestaraunt.Commands
{
    using UpRestaraunt.ViewModels;

    /// <summary>
    /// Команда перехода на страницу с настройками.
    /// </summary>
    public class SwitchToSettingsPageCommand : BaseTypeCommand<UpRestarauntVM>
    {
        /// <summary>
        /// Выполнить команду перехода на страницу с настройками.
        /// </summary>
        /// <param name="upRestarauntVM"> Вью-модель всего приложения. </param>
        protected override void Execute(UpRestarauntVM upRestarauntVM)
        {
            upRestarauntVM.IsMainPage = false;
            upRestarauntVM.IsSettingsPage = true;
            upRestarauntVM.IsTablesPage = false;
        }

        /// <inheritdoc />
        protected override bool CanExecute(UpRestarauntVM upRestarauntVM)
        {
            return base.CanExecute(upRestarauntVM);
        }
    }
}
