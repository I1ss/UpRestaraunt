namespace UpRestaraunt.Commands
{
    using UpRestaraunt.ViewModels;

    /// <summary>
    /// Команда перехода на страницу с таблицами.
    /// </summary>
    public class SwitchToTablesPageCommand : BaseTypeCommand<UpRestarauntVM>
    {
        /// <summary>
        /// Выполнить команду перехода на страницу с таблицами.
        /// </summary>
        /// <param name="upRestarauntVM"> Вью-модель всего приложения. </param>
        protected override void Execute(UpRestarauntVM upRestarauntVM)
        {
            upRestarauntVM.IsMainPage = false;
            upRestarauntVM.IsSettingsPage = false;
            upRestarauntVM.IsTablesPage = true;
        }

        /// <inheritdoc />
        protected override bool CanExecute(UpRestarauntVM upRestarauntVM)
        {
            return base.CanExecute(upRestarauntVM);
        }
    }
}
