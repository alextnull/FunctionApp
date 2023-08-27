using System;
using System.Linq;

namespace FunctionApp.Models
{
    /// <summary>
    /// Функция n-й степени.
    /// </summary>
    public class MathFunction
    {
        /// <summary>
        /// Инициализирует функцию n-й степени.
        /// </summary>
        /// <param name="power">Степень.</param>
        public MathFunction(int power)
        {
            if (power < 1)
                throw new ArgumentException("Степень функции не может быть меньше 1");
            Power = power;
            CoefficientRangeC = Enumerable.Range(1, 5).Select(x => x * (int)Math.Pow(10, power - 1)).ToArray();
        }

        /// <summary>
        /// Степень.
        /// </summary>
        public int Power { get; }

        /// <summary>
        /// Возможные значения коэффициента c.
        /// </summary>
        public int[] CoefficientRangeC { get; }

        /// <summary>
        /// Описание функции.
        /// </summary>
        public string Description => Power switch
        {
            1 => "линейная",
            2 => "квадратичная",
            3 => "кубическая",
            _ => $"{Power}-ой степени"
        };

        /// <summary>
        /// Рассчитывает значение n-й функции.
        /// </summary>
        /// <param name="x">Аргумент x.</param>
        /// <param name="y">Аргумент y.</param>
        /// <param name="a">Коэффициент a.</param>
        /// <param name="b">Коэффициент b.</param>
        /// <param name="c">Коэффициент c.</param>
        /// <returns>Значение функции.</returns>
        public int Calculate(int x, int y, int a, int b, int c)
        { 
            if (!CoefficientRangeC.Contains(c))
                throw new ArgumentOutOfRangeException(nameof(c));
            return a * (int)Math.Pow(x, Power) + b * (int)Math.Pow(y, Power - 1) + c;
        } 
    }
}
