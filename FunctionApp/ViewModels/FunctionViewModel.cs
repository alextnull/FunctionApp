using System.Collections.Generic;
using System.Linq;
using FunctionApp.MvvmEngine;

namespace FunctionApp.ViewModels
{
    /// <summary>
    /// Вью-модель представления FunctionView.
    /// </summary>
    public class FunctionViewModel : ViewModelBase
    {
        private MathFunctionViewModel _selectedFunction;

        private List<MathFunctionViewModel> _functionTypes;

        /// <summary>
        /// Инициализирует вью-модель FunctionViewModel.
        /// </summary>
        public FunctionViewModel()
        {
            _functionTypes = Enumerable.Range(1, 5).Select(x => new MathFunctionViewModel(x)).ToList();
            _selectedFunction = _functionTypes[0];
        }

        /// <summary>
        /// Выбранная функция.
        /// </summary>
        public MathFunctionViewModel SelectedFunction
        {
            get => _selectedFunction;
            set => SetProperty(ref _selectedFunction, value);
        }

        /// <summary>
        /// Список доступных функций.
        /// </summary>
        public List<MathFunctionViewModel> FunctionTypes => _functionTypes;
    }
}
