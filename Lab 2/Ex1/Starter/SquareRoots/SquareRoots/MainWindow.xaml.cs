using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SquareRoots
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            // Получение числа из TextBox
            double numberDouble;
            if (!double.TryParse(inputTextBox.Text, out numberDouble))
            {
                MessageBox.Show("Введите число");
                return;
            }

            // Проверка на ввод положительного числа
            if (numberDouble <= 0)
            {
                MessageBox.Show("Введите положительное число");
                return;
            }

            // Метод .NET Framework - Math.Sqrt
            double squareRoot = Math.Sqrt(numberDouble);

            // Format the result and display it
            frameworkLabel.Content = string.Format("{0} (Метод .NET Framework)", squareRoot);

            // Метод Ньютона для вычисления квадратных корней

            // Получение ввода пользователем десятичного числа
            decimal numberDecimal;
            if (!decimal.TryParse(inputTextBox.Text, out numberDecimal))
            {
                MessageBox.Show("Пожалуйста, введите десятичную дробь");
                return;
            }

            // Укажем 10 в степени -28 в качестве минимальной разницы между оценками. 
            // Это минимальный диапазон, поддерживаемый десятичным типом. 
            // Если разница между двумя оценками меньше этого значения, стоп.
            decimal delta = Convert.ToDecimal(Math.Pow(10, -28));

            // Сделайте начальное предположение об ответе, чтобы начать
            decimal guess = numberDecimal / 2;

            // Оценка результата для первой итерации
            decimal result = ((numberDecimal / guess) + guess) / 2;

            // Пока разница между значениями для каждой текущей итерации не меньше дельты,
            //выполним еще одну итерацию для уточнения ответа.
            while (Math.Abs(result - guess) > delta)
            {

            // Использование результата предыдущей итерации
            // в качестве отправной точки
                guess = result;

            // Повторение
                result = ((numberDecimal / guess) + guess) / 2;
            }
            // Отображение результата
            newtonLabel.Content = string.Format("{0} (Метод Ньютона)", result);
        }
    }
}