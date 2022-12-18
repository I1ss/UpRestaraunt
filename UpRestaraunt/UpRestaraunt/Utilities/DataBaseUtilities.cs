namespace UpRestaraunt.Utilities
{
    using System;
    using System.Data;
    using System.Linq;

    /// <summary>
    /// Вспомогательные утилиты для взаимодействия с базой данных.
    /// </summary>
    public static class DataBaseUtilities
    {
        /// <summary>
        /// Строка подключения к базе данных.
        /// </summary>
        public const string CONNECTION_STRING = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Restaurant;Integrated Security=True";

        /// <summary>
        /// Метод возвращает простейший запрос, который по заданному имени таблицы и айди пользователя возвращает 
        /// запрос на получение значений из таблицы для конкретного пользователя.
        /// </summary>
        /// <param name="tableName"> Имя таблицы. </param>
        /// <param name="column"> Имя столбца. </param>
        /// <param name="idUser"> Идентификатор пользователя. </param>
        /// <returns> Запрос на получение значений из таблицы для конкретного пользователя. </returns>
        public static string BuildSqlSelectRequest(string tableName, string column, string idUser)
        {
            return $"SELECT * FROM {tableName} WHERE {column} = {idUser}";
        }
    }
}
