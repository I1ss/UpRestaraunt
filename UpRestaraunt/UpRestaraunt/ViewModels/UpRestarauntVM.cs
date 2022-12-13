namespace UpRestaraunt.ViewModels
{
    /// <summary>
    /// Вью-модель всего приложения.
    /// </summary>
    public class UpRestarauntVM : BaseVM
    {
        /// <summary>
        /// Вью-модель контрола аутентификации: авторизации/регистрации.
        /// </summary>
        public AuthenticationVM AuthenticationVM { get; set; }

        /// <summary>
        /// Конструктор вью-модели всего приложения.
        /// </summary>
        public UpRestarauntVM()
        {
            AuthenticationVM = new AuthenticationVM();
        }
    }
}
