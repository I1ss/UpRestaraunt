namespace UpRestaraunt.ViewModels.Tables
{
    using System;
    using System.Data;
    using System.Text.RegularExpressions;
    using UpRestaraunt.Commands;
    using UpRestaraunt.Converters;
    using UpRestaraunt.Database;

    /// <summary>
    /// Вью-модель таблицы с должностями.
    /// </summary>
    public class PostsTableVM : BaseVM
    {
        /// <inheritdoc cref="SelectedRow" />
        private DataRowView _selectedRow { get; set; }

        /// <inheritdoc cref="CurrentUser" />
        private Users _currentUser { get; set; }

        /// <inheritdoc cref="PostTable" />
        private DataTable _postTable { get; set; }

        /// <inheritdoc cref="Salary" />
        private int _salary { get; set; }

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

                if (PostTable.Rows.Count != 0 && Filter != string.Empty)
                    PostTable.DefaultView.RowFilter = $"{nameof(SelectedPost.Title)} = '{Filter}'";
                else
                    PostTable.DefaultView.RowFilter = string.Empty;
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
        /// Выбранная должность.
        /// </summary>
        public Posts SelectedPost { get; set; }

        /// <summary>
        /// Представление таблицы.
        /// </summary>
        public DataView DataView => PostTable.DefaultView;

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

                SelectedPost.ConvertToCoreDbFromRow(PostTable, SelectedRow);
                OnPropertyChanged(nameof(SelectedPost));

                Salary = SelectedPost.Salary;
                Title = SelectedPost.Title;
            }
        }

        /// <summary>
        /// Табличное представление информации о должности.
        /// </summary>
        public DataTable PostTable
        {
            get
            {
                return _postTable;
            }
            set
            {
                _postTable = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(DataView));
            }
        }

        /// <summary>
        /// Отображаемое значение зарплаты в таблице.
        /// </summary>
        public int Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                _salary = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Отображаемое значение названмя должности посещения в таблице.
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
        /// Команда для изменения записи о должности.
        /// </summary>
        public EditCoreSettingsFromDbCommand<PostsTableVM> EditCoreSettingsFromDbCommand { get; set; }

        /// <summary>
        /// Команда для удаления должности.
        /// </summary>
        public DeleteCoreFromDbCommand<PostsTableVM> DeleteCoreFromDbCommand { get; set; }

        /// <summary>
        /// Команда для добавления должности.
        /// </summary>
        public AddCoreToDbCommand<PostsTableVM> AddCoreToDbCommand { get; set; }

        /// <summary>
        /// Конструктор вью-модели таблицы с должностью.
        /// </summary>
        public PostsTableVM()
        {
            CurrentUser = new Users();
            SelectedPost = new Posts();
            PostTable = new DataTable();

            EditCoreSettingsFromDbCommand = new EditCoreSettingsFromDbCommand<PostsTableVM>();
            DeleteCoreFromDbCommand = new DeleteCoreFromDbCommand<PostsTableVM>();
            AddCoreToDbCommand = new AddCoreToDbCommand<PostsTableVM>();
        }
    }
}
