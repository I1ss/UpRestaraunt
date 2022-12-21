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
    public class TypesMenuTableVM : BaseVM
    {
        /// <inheritdoc cref="SelectedRow" />
        private DataRowView _selectedRow { get; set; }

        /// <inheritdoc cref="CurrentUser" />
        private Users _currentUser { get; set; }

        /// <inheritdoc cref="TypeMenuTable" />
        private DataTable _typeMenuTable { get; set; }

        /// <inheritdoc cref="CountDishes" />
        private int _countDishes { get; set; }

        /// <inheritdoc cref="Title" />
        private string _title { get; set; }

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
                _filter = value;
                OnPropertyChanged();

                if (TypeMenuTable.Rows.Count != 0 && Filter != string.Empty)
                    TypeMenuTable.DefaultView.RowFilter = $"{nameof(SelectedTypeMenu.Title)} = '{Filter}'";
                else
                    TypeMenuTable.DefaultView.RowFilter = string.Empty;
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
        /// Выбранный тип меню.
        /// </summary>
        public Types_menu SelectedTypeMenu { get; set; }

        /// <summary>
        /// Представление таблицы.
        /// </summary>
        public DataView DataView => TypeMenuTable.DefaultView;

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

                SelectedTypeMenu.ConvertToCoreDbFromRow(TypeMenuTable, SelectedRow);
                OnPropertyChanged(nameof(SelectedTypeMenu));

                CountDishes = SelectedTypeMenu.Count_dishes;
                Title = SelectedTypeMenu.Title;
            }
        }

        /// <summary>
        /// Табличное представление информации о типе меню.
        /// </summary>
        public DataTable TypeMenuTable
        {
            get
            {
                return _typeMenuTable;
            }
            set
            {
                _typeMenuTable = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(DataView));
            }
        }

        /// <summary>
        /// Отображаемое значение количества блюд в таблице.
        /// </summary>
        public int CountDishes
        {
            get
            {
                return _countDishes;
            }
            set
            {
                _countDishes = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Отображаемое значение названия в таблице.
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда для изменения записи о меню.
        /// </summary>
        public EditCoreSettingsFromDbCommand<TypesMenuTableVM> EditCoreSettingsFromDbCommand { get; set; }

        /// <summary>
        /// Команда для удаления меню.
        /// </summary>
        public DeleteCoreFromDbCommand<TypesMenuTableVM> DeleteCoreFromDbCommand { get; set; }

        /// <summary>
        /// Команда для добавления меню.
        /// </summary>
        public AddCoreToDbCommand<TypesMenuTableVM> AddCoreToDbCommand { get; set; }

        /// <summary>
        /// Конструктор вью-модели таблицы с меню.
        /// </summary>
        public TypesMenuTableVM()
        {
            CurrentUser = new Users();
            SelectedTypeMenu = new Types_menu();
            TypeMenuTable = new DataTable();

            EditCoreSettingsFromDbCommand = new EditCoreSettingsFromDbCommand<TypesMenuTableVM>();
            DeleteCoreFromDbCommand = new DeleteCoreFromDbCommand<TypesMenuTableVM>();
            AddCoreToDbCommand = new AddCoreToDbCommand<TypesMenuTableVM>();
        }
    }
}
