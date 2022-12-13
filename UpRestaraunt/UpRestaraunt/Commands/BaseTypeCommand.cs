namespace UpRestaraunt.Commands
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Базовый класс команды.
    /// </summary>
    /// <typeparam name="T"> Тип принимаемой вью-модели. </typeparam>
    public abstract class BaseTypeCommand<T> : ICommand
    {
        /// <summary>
        /// Событие выполнения.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        /// Выполнение команды.
        /// </summary>
        /// <param name="parameter"> Параметр команды. </param>
        protected abstract void Execute(T parameter);

        /// <summary>
        /// Выполнение команды.
        /// </summary>
        /// <param name="parameter"> Параметр команды. </param>
        public virtual void Execute(object parameter)
        {
            if (parameter is T typedParameter)
                Execute(typedParameter);
        }

        /// <summary>
        /// Проверка возможности ли вызвать команду.
        /// </summary>
        /// <param name="parameter"> Параметр для команды. </param>
        /// <returns> Возможно ли? </returns>
        protected virtual bool CanExecute(T parameter)
        {
            return true;
        }

        /// <summary>
        /// Проверка возможности ли вызвать команду.
        /// </summary>
        /// <param name="parameter"> Параметр для команды. </param>
        /// <returns> Возможно ли? </returns>
        public virtual bool CanExecute(object parameter)
        {
            if (parameter is T typedParameter)
                return CanExecute(typedParameter);

            return true;
        }
    }
}