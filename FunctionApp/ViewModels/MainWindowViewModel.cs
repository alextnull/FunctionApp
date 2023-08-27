using FunctionApp.MvvmEngine;

namespace FunctionApp.ViewModels
{
    /// <summary>
    /// Вью-модель представления MainWindow.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// Инициализирует вью-модель MainWindowViewModel.
        /// </summary>
        public MainWindowViewModel()
        {
            CurrentViewModel = new FunctionViewModel();
        }

        /// <summary>
        /// Текущая вью-модель.
        /// </summary>
        public ViewModelBase? CurrentViewModel { get; set; }
    }
}
