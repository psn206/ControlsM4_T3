using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Controls
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = ((sender as ComboBox).SelectedItem as string);
            textBox.FontFamily = new FontFamily(fontName);
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            double size =Convert.ToDouble((sender as ComboBox).SelectedItem);
            textBox.FontSize = size;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textBox.FontWeight = textBox.FontWeight == FontWeights.Normal ? FontWeights.Bold : FontWeights.Normal;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            textBox.FontStyle = textBox.FontStyle == FontStyles.Normal ? FontStyles.Italic : FontStyles.Normal;
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.TextDecorations.Count == 0)
            {
                textBox.TextDecorations.Add(TextDecorations.Underline);
            }
            else
            {
                textBox.TextDecorations.Clear();
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            textBox.Foreground = Brushes.Black;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            textBox.Foreground = Brushes.Red;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            var rezult = MessageBox.Show("Сохранить файл?",
                      "Сообщение",
                       MessageBoxButton.YesNo,
                       MessageBoxImage.Question
                      );
            if (rezult == MessageBoxResult.Yes)
            {
                MenuItem_Click_1(sender, e);
                Application.Current.Shutdown();
            }
            else
            {
                Application.Current.Shutdown();
            }


        }
    }
}
