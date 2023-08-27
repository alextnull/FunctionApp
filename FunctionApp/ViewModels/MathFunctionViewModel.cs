using FunctionApp.Models;
using FunctionApp.MvvmEngine;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using System.Runtime.CompilerServices;

namespace FunctionApp.ViewModels
{
    /// <summary>
    /// Вью-модель функции n-й степени.
    /// </summary>
    public class MathFunctionViewModel : ViewModelBase
    {
        private readonly MathFunction _mathFunction;

        private readonly ICommand _addFunctionCalculationCommand;

        private ObservableCollection<MathFunctionCalculationViewModel> _mathFunctionCalculations;

        private int _coefficientA;

        private int _coefficientB;

        private int _coefficientC;

        /// <summary>
        /// Инициализирует вью-модель функции n-й степени.
        /// </summary>
        /// <param name="power">Степень.</param>
        public MathFunctionViewModel(int power)
        {
            _mathFunction = new MathFunction(power);
            _mathFunctionCalculations = new ObservableCollection<MathFunctionCalculationViewModel>();
            _addFunctionCalculationCommand = new RelayCommand(AddFunctionCalculation);
            CoefficientC = CoefficientRangeC[0];
        }

        /// <summary>
        /// Список расчетов.
        /// </summary>
        public ObservableCollection<MathFunctionCalculationViewModel> MathFunctionCalculations
        {
            get => _mathFunctionCalculations;
            set => SetProperty(ref _mathFunctionCalculations, value);
        }

        /// <summary>
        /// Коэффициент a.
        /// </summary>
        public string CoefficientA
        {
            get => _coefficientA.ToString();
            set => SetCoefficient(ref _coefficientA, value);
        }

        /// <summary>
        /// Коэффициент b.
        /// </summary>
        public string CoefficientB
        {
            get => _coefficientB.ToString();
            set => SetCoefficient(ref _coefficientB, value);
        }

        /// <summary>
        /// Коэффициент c.
        /// </summary>
        public int CoefficientC
        {
            get => _coefficientC;
            set => SetCoefficient(ref _coefficientC, value);
        }

        /// <summary>
        /// Возможные значения коэффициента c.
        /// </summary>
        public int[] CoefficientRangeC => _mathFunction.CoefficientRangeC;

        /// <summary>
        /// Описание функции.
        /// </summary>
        public string Description => _mathFunction.Description;

        /// <summary>
        /// Команда для добавления нового расчета.
        /// </summary>
        public ICommand AddFunctionCalculationCommand => _addFunctionCalculationCommand;

        /// <summary>
        /// Изменяет значение коэффициента и уведомляет UI об изменении в случае успешного изменения.
        /// </summary>
        /// <param name="field">Поле.</param>
        /// <param name="value">Значение.</param>
        /// <param name="propertyName">Наименование свойства.</param>
        protected virtual void SetCoefficient(ref int field, string value, [CallerMemberName] string propertyName = "")
        {
            if (!int.TryParse(value, out int coefficient))
                return;
            SetCoefficient(ref field, coefficient, propertyName);
        }

        /// <summary>
        /// Изменяет значение коэффициента и уведомляет UI об изменении.
        /// </summary>
        /// <param name="field">Поле.</param>
        /// <param name="value">Значение.</param>
        /// <param name="propertyName">Наименование свойства.</param>
        protected virtual void SetCoefficient(ref int field, int value, [CallerMemberName] string propertyName = "")
        {
            SetProperty(ref field, value, propertyName);
            UpdateFunctionCalculations();
        }

        /// <summary>
        /// Добавляет новый расчет.
        /// </summary>
        /// <param name="parameter"></param>
        private void AddFunctionCalculation(object? parameter)
        {
            var functionCalculation = new MathFunctionCalculationViewModel();
            functionCalculation.ArgumentChanged += MathFunctionCalculation_ArgumentChanged;
            MathFunctionCalculations.Add(functionCalculation);
        }

        /// <summary>
        /// Обновляет значение функции при изменении аргумента.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Аргументы события.</param>
        private void MathFunctionCalculation_ArgumentChanged(object? sender, EventArgs e)
        {
            var calculation = (MathFunctionCalculationViewModel)sender!;
            calculation.Result = _mathFunction.Calculate(int.Parse(calculation.X), int.Parse(calculation.Y), _coefficientA, _coefficientB, _coefficientC);
        }

        /// <summary>
        /// Обновляет значение функции у всех расчетов.
        /// </summary>
        private void UpdateFunctionCalculations()
        {
            foreach (var calculation in MathFunctionCalculations)
                calculation.Result = _mathFunction.Calculate(int.Parse(calculation.X), int.Parse(calculation.Y), _coefficientA, _coefficientB, _coefficientC);
        }
    }
}
