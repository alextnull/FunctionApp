using System;
using System.Windows.Input;

namespace FunctionApp.MvvmEngine
{
    /// <summary>
    /// Команда.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _execute;
        private readonly Func<object?, bool>? _canExecute;

        /// <inheritdoc />
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        /// Инициализирует команду.
        /// </summary>
        /// <param name="execute">Обработчик команды.</param>
        /// <param name="canExecute">Обработчик для проверки доступности команды.</param>
        public RelayCommand(Action<object?> execute, Func<object?, bool> canExecute)
        {
            ArgumentNullException.ThrowIfNull(execute, nameof(execute));
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Инициализирует команду, которая всегда доступна.
        /// </summary>
        /// <param name="execute">Обработчик команды.</param>
        public RelayCommand(Action<object?> execute)
        {
            ArgumentNullException.ThrowIfNull(execute, nameof(execute));
            _execute = execute;
        }

        /// <summary>
        /// Обработчик для проверки доступности команды.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        /// <returns><see langword="true"/> если команда доступна; иначе, <see langword="false"/>.</returns>
        public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;

        /// <summary>
        /// Обработчик команды.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        public void Execute(object? parameter) => _execute.Invoke(parameter);
    }
}
