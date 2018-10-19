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

using DialogResult = System.Windows.Forms.DialogResult;
using Apk;

namespace WpfApp2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string fileContent = string.Empty;
        string filePath = string.Empty;
        string fileKeyPath = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            chooseFile(filePath);
        }

        //szyfrowanie
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            AESProgram.DoAES(fileContent);
            MessageBox.Show("Zrobione!", "Stan", MessageBoxButton.OK);
        }

        //hashowanie
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            HashProgram.DoHash(fileContent);
            MessageBox.Show("Zrobione!", "Stan", MessageBoxButton.OK);
        }

        //odszyfrowanie
        private void button4_Click(object sender, RoutedEventArgs e)
        {

        }

        //wybranie klucza do zaszyfrowania
        private void button6_Click(object sender, RoutedEventArgs e)
        {
            chooseFile(fileKeyPath);
        }

        //wybranie klucza do odszyfrowania
        private void button5_Click(object sender, RoutedEventArgs e)
        {
            chooseFile(fileKeyPath);
        }

        private void chooseFile(string path)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            var result = openFileDialog.ShowDialog();
            var fileStream = openFileDialog.OpenFile();

            if (result == true)
            {
                path = openFileDialog.FileName;

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }

                MessageBox.Show(path, "File path", MessageBoxButton.OK);
            }
        }
    }
}
