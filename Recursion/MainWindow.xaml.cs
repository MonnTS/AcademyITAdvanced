using System;
using System.Windows;

namespace Recursion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _counter;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private int FactorialRecursion(int n)
        {
            if (n <= 1)
            {
                _counter++;
                return 1;
            }
            _counter++;
            return n * FactorialRecursion(n - 1);
        }

        private int FactorialIteration(int n)
        {
            _counter = 1;
            int result = 1;
            
            for (int i = 2; i <= n; i++)
            {
                _counter++;
                result *= i;
            }
            return result;
        }
        
        private int FibonacciRecursion(int n)
        {
            if (n <= 1)
            {
                _counter++;
                return n;
            }
            _counter++;
            return FibonacciRecursion(n - 1) + FibonacciRecursion(n - 2);
        }
        
        private int FibonacciIteration(int n)
        {
            _counter = 3;

            int[] arr = new int[n + 1];
            arr[0] = 0;
            arr[1] = 1;
            arr[2] = 1;

            for (int i = 3; i <= n; i++)
            {
                _counter++;
                arr[i] = arr[i - 1] + arr[i - 2];
            }
            return arr[n];
        }
        
        private int ResolveByRecursion(int n)
        {
            switch (n)
            {
                case 0:
                    _counter++;
                    return 2;
                case 1:
                    _counter++;
                    return 3;
                default:
                    _counter++;
                    return 2 * ResolveByRecursion(n - 1) + 3 * ResolveByRecursion(n - 2) + 1;
            }
        }

        private int ResolveByIteration(int n)
        {
            _counter = 0;
            int result;

            switch (n)
            {
                case 0:
                    _counter++;
                    result = 2;
                    break;
                case 1:
                    _counter++;
                    result = 3;
                    break;
                default:
                {
                    int tempSecond = 2;
                    result = 3;
                    for (int i = 2; i <= n; i++)
                    {
                        _counter += 3;
                        var tempFirst = result;
                        result = 2 * tempFirst + 3*tempSecond + 1;
                        tempSecond = tempFirst;
                    }

                    break;
                }
            }
            return result;
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            RichTextBox.AppendText($"Factorial by recursion: {FactorialRecursion(10)}, iterations: {_counter}\r");
            RichTextBox.AppendText($"Factorial by iteration: {FactorialIteration(10)}, iterations: {_counter}\r");
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            _counter = 0;
            DateTime startTime = DateTime.Now;
            RichTextBox.AppendText($"Fibonacci by recursion {FibonacciRecursion(30)}, iterations: {_counter}\r");
            DateTime stopTime = DateTime.Now;
            TimeSpan duration = stopTime - startTime;
            RichTextBox.AppendText($"Timer: {duration}\r");
            startTime = DateTime.Now;
            RichTextBox.AppendText($"Fibonacci by iteration: {FibonacciIteration(30)}, iterations: {_counter}\r");
            stopTime = DateTime.Now;
            duration = stopTime - startTime;
            RichTextBox.AppendText($"Timer: {duration}\r");
        }

        private void ButtonSecond_OnClick(object sender, RoutedEventArgs e)
        {
            _counter = 0;
            RichTextBox.AppendText($"Sequence by recursion: {ResolveByRecursion(10)}, iterations: {_counter}\r");
            RichTextBox.AppendText($"Sequence by iteration: {ResolveByIteration(10)}, iterations: {_counter}\r");
        }
    }
}