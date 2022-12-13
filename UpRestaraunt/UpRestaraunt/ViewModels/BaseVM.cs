namespace UpRestaraunt.ViewModels
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Базовая вью-модель.
    /// </summary>
    public class BaseVM : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие изменения какого-либо свойства.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Обработка события изменения состояния свойства.
        /// </summary>
        /// <param name="propertyName"> Имя свойство, что изменилось. </param>
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
