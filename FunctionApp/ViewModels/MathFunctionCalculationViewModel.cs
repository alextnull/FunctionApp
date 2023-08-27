using System;
using System.Runtime.CompilerServices;
using FunctionApp.MvvmEngine;

namespace FunctionApp.ViewModels
{
    /// <summary>
    /// Вью-модель расчетов.
    /// </summary>
    public class MathFunctionCalculationViewModel : ViewModelBase
    {
        private int _x;

        private int _y;

        private int _result;

        /// <summary>
        /// Событие, которое происходит после изменения аргумента.
        /// </summary>
        public event EventHandler? ArgumentChanged;

        /// <summary>
        /// Аргумент x.
        /// </summary>
        public string X
        {
            get => _x.ToString();
            set => SetArgument(ref _x, value);
        }

        /// <summary>
        /// Аргумент y.
        /// </summary>
        public string Y
        {
            get => _y.ToString();
            set => SetArgument(ref _y, value);
        }

        /// <summary>
        /// Значение функции.
        /// </summary>
        public int Result
        {
            get => _result;
            set => SetProperty(ref _result, value);
        }

        /// <summary>
        /// Изменяет значение аргумента и уведомляет UI об изменении в случае успешного изменения.
        /// </summary>
        /// <param name="field">Поле.</param>
        /// <param name="value">Значение.</param>
        /// <param name="propertyName">Наименование свойства.</param>
        protected virtual void SetArgument(ref int field, string value, [CallerMemberName] string propertyName = "")
        {
            if (!int.TryParse(value, out int argument))
                return;
            SetProperty(ref field, argument, propertyName);
            ArgumentChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
