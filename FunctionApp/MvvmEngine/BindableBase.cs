using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FunctionApp.MvvmEngine
{
    /// <summary>
    /// База для создания для привязок.
    /// </summary>
    public abstract class BindableBase : INotifyPropertyChanged
    {
        /// <inheritdoc />
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Уведомляет об изменении свойства.
        /// </summary>
        /// <param name="propertyName">Наименование свойства.</param>
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Изменяет значение свойства и уведомляет UI об изменении.
        /// </summary>
        /// <typeparam name="T">Тип свойства.</typeparam>
        /// <param name="field">Поле.</param>
        /// <param name="value">Значение.</param>
        /// <param name="propertyName">Наименование свойства.</param>
        protected virtual void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return;
            field = value;
            RaisePropertyChanged(propertyName);
        }
    }
}
