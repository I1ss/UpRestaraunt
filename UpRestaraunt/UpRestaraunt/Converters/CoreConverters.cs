namespace UpRestaraunt.Converters
{
    using System;
    using System.Data;
    using System.Linq;

    /// <summary>
    /// Конвертер, в котором можно вызвать несколько конвертеров.
    /// </summary>
    public static class CoreConverters
    {
        /// <summary>
        /// Метод для получения core-представления текущего выбранного значения в таблице.
        /// </summary>
        /// <typeparam name="T"> Тип параметра, соответсвующий таблице. </typeparam>
        /// <param name="dataTable"> Представление таблицы. </param>
        /// <param name="dataRowView"> Выбранная строка таблицы. </param>
        /// <param name="currentValue"> Текущее значение выбранного элемента. </param>
        public static void ConvertToCoreDbFromRow<T>(this T currentValue, DataTable dataTable, DataRowView dataRowView)
        {
            var type = typeof(T);
            var properties = currentValue.GetType().GetProperties().Where(x => x.GetMethod.IsPublic).Select(x => x.Name).ToList();

            foreach (var property in properties)
            {
                if (!dataTable.Columns.Contains(property) || dataRowView?.Row[property] == DBNull.Value)
                    continue;

                var myFieldInfo = type.GetProperty(property, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                myFieldInfo.SetValue(currentValue, dataRowView?.Row[property]);
            }
        }

        /// <summary>
        /// Метод для получения row-представления текущего выбранного значения в таблице.
        /// </summary>
        /// <typeparam name="T"> Тип параметра, соответсвующий таблице. </typeparam>
        /// <param name="dataTable"> Представление таблицы. </param>
        /// <param name="dataRowView"> Выбранная строка таблицы. </param>
        /// <param name="currentValue"> Текущее значение выбранного элемента. </param>
        public static void ConvertToRowDbFromCore<T>(this DataRowView dataRowView, DataTable dataTable, T currentValue)
        {
            var type = typeof(T);
            var properties = currentValue.GetType().GetProperties().Where(x => x.GetMethod.IsPublic).Select(x => x.Name).ToList();

            foreach (var property in properties)
            {
                if (!dataTable.Columns.Contains(property) || dataRowView?.Row[property] == DBNull.Value)
                    continue;

                var myFieldInfo = type.GetProperty(property, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                dataRowView.Row[property] = myFieldInfo.GetValue(currentValue);
            }
        }
    }
}