namespace UpRestaraunt.Commands
{
    using System;
    using UpRestaraunt.ViewModels;

    /// <summary>
    /// Команда для перехода к регистрации или обратно к авторизации.
    /// </summary>
    public class TryToRegistrationCommand : BaseTypeCommand<AuthenticationVM>
    {
        /// <summary>
        /// Для идентификации перехода к авторизации.
        /// </summary>
        private const string AUTHORIZATION = "Авторизация";

        /// <summary>
        /// Для идентификации перехода к регистрации.
        /// </summary>
        private const string REGISTRATION = "Регистрация";

        /// <summary>
        /// Выполнить команду для перехода к регистрации или обратно к авторизации.
        /// </summary>
        /// <param name="authenticationVM"> Вью-модель контрола аутентификации: авторизации/регистрации. </param>
        protected override void Execute(AuthenticationVM authenticationVM)
        {
            switch (authenticationVM.SwitchAuthentication)
            {
                case AUTHORIZATION:
                    authenticationVM.SwitchAuthentication = REGISTRATION;
                    break;
                case REGISTRATION:
                    authenticationVM.SwitchAuthentication = AUTHORIZATION;
                    break;
                default:
                    throw new ArgumentException(nameof(authenticationVM.SwitchAuthentication));
            }

            authenticationVM.IsRegistration = !authenticationVM.IsRegistration;
        }

        /// <inheritdoc />
        protected override bool CanExecute(AuthenticationVM authenticationVM)
        {
            return base.CanExecute(authenticationVM);
        }
    }
}
