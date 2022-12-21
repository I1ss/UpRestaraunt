namespace UpRestaraunt.ViewModels.Tables
{
    using System;
    using System.Data;
    using System.Text.RegularExpressions;
    using UpRestaraunt.Commands;
    using UpRestaraunt.Converters;
    using UpRestaraunt.Database;

    /// <summary>
    /// Вью-модель таблицы с меню.
    /// </summary>
    public class MenuTableVM : BaseVM
    {
        /// <inheritdoc cref="SelectedRow" />
        private DataRowView _selectedRow { get; set; }

        /// <inheritdoc cref="CurrentUser" />
        private Users _currentUser { get; set; }

        /// <inheritdoc cref="MenuTable" />
        private DataTable _menuTable { get; set; }

        /// <inheritdoc cref="IdTypeMenu" />
        private int _idTypeMenu { get; set; }

        /// <inheritdoc cref="IdHall" />
        private int _idHall { get; set; }

        /// <inheritdoc cref="Filter" />
        private string _filter { get; set; }

        /// <summary>
        /// Фильтр.
        /// </summary>
        public string Filter
        {
            get { return _filter; }
            set
            {
                if (Regex.IsMatch(value, "[^0-9]"))
                    return;

                _filter = value;
                OnPropertyChanged();

                if (MenuTable.Rows.Count != 0 && Filter != string.Empty)
                    MenuTable.DefaultView.RowFilter = $"{nameof(SelectedMenu.Id_type_menu)} = {Filter}";
                else
                    MenuTable.DefaultView.RowFilter = string.Empty;
            }
        }

        /// <summary>
        /// Текущий авторизованный пользователь.
        /// </summary>
        public Users CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Выбранное меню.
        /// </summary>
        public Menus SelectedMenu { get; set; }

        /// <summary>
        /// Представление таблицы.
        /// </summary>
        public DataView DataView => MenuTable.DefaultView;

        /// <summary>
        /// Выбранная строка в таблице.
        /// </summary>
        public DataRowView SelectedRow
        {
            get
            {
                return _selectedRow;
            }
            set
            {
                _selectedRow = value;
                OnPropertyChanged();

                SelectedMenu.ConvertToCoreDbFromRow(MenuTable, SelectedRow);
                OnPropertyChanged(nameof(SelectedMenu));

                IdTypeMenu = SelectedMenu.Id_type_menu is int selectedIdTypeMenu ? selectedIdTypeMenu : 0; ;
                IdHall = SelectedMenu.Id_hall is int selectedIdHall ? selectedIdHall : 0; ;
            }
        }

        /// <summary>
        /// Табличное представление информации о меню.
        /// </summary>
        public DataTable MenuTable
        {
            get
            {
                return _menuTable;
            }
            set
            {
                _menuTable = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(DataView));
            }
        }

        /// <summary>
        /// Отображаемое значение id типа меню в таблице.
        /// </summary>
        public int IdTypeMenu
        {
            get
            {
                return _idTypeMenu;
            }
            set
            {
                _idTypeMenu = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Отображаемое значение id зала в таблице.
        /// </summary>
        public int IdHall
        {
            get
            {
                return _idHall;
            }
            set
            {
                _idHall = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда для изменения записи о меню.
        /// </summary>
        public EditCoreSettingsFromDbCommand<MenuTableVM> EditCoreSettingsFromDbCommand { get; set; }

        /// <summary>
        /// Команда для удаления меню.
        /// </summary>
        public DeleteCoreFromDbCommand<MenuTableVM> DeleteCoreFromDbCommand { get; set; }

        /// <summary>
        /// Команда для добавления меню.
        /// </summary>
        public AddCoreToDbCommand<MenuTableVM> AddCoreToDbCommand { get; set; }

        /// <summary>
        /// Конструктор вью-модели таблицы с меню.
        /// </summary>
        public MenuTableVM()
        {
            CurrentUser = new Users();
            SelectedMenu = new Menus();
            MenuTable = new DataTable();

            EditCoreSettingsFromDbCommand = new EditCoreSettingsFromDbCommand<MenuTableVM>();
            DeleteCoreFromDbCommand = new DeleteCoreFromDbCommand<MenuTableVM>();
            AddCoreToDbCommand = new AddCoreToDbCommand<MenuTableVM>();
        }
    }
}
