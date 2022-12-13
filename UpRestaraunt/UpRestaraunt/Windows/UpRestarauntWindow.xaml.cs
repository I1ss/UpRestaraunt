namespace UpRestaraunt.Windows
{
    using System.Windows;

    using UpRestaraunt.ViewModels;

    /// <summary>
    /// Логика взаимодействия для UpRestarauntWindow.xaml
    /// </summary>
    public partial class UpRestarauntWindow : Window
    {
        /// <summary>
        /// Инициализация базового окошка приложения.
        /// </summary>
        public UpRestarauntWindow()
        {
            InitializeComponent();
            DataContext = new UpRestarauntVM();
        }
    }
}
