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
using System.Numerics;

using System.Security.Cryptography;

namespace WpfApp2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string fileContent = string.Empty;
        string filePath = string.Empty;

        string fileKeyEncContent = string.Empty;
        string fileKeyDecContent = string.Empty;
        string fileKeyPathEnc = string.Empty;
        string fileKeyPathDec = string.Empty;

        string fileIVPathEnc = string.Empty;
        string fileIVPathDec = string.Empty;
        string fileIVEncContent = string.Empty;
        string fileIVDecContent = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            fileContent = chooseFile(filePath);
        }

        //szyfrowanie
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            AESProgram.DoAESEnc(fileContent, fileKeyEncContent, fileIVEncContent);
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
            AESProgram.DoAESDec(fileContent, fileKeyDecContent, fileIVDecContent);
            MessageBox.Show("Zrobione!", "Stan", MessageBoxButton.OK);
        }

        //wybranie klucza do zaszyfrowania
        private void button6_Click(object sender, RoutedEventArgs e)
        {
            fileKeyEncContent = chooseFile(fileKeyPathEnc);
        }

        //wybranie klucza do odszyfrowania
        private void button5_Click(object sender, RoutedEventArgs e)
        {
            fileKeyDecContent = chooseFile(fileKeyPathDec);
        }
        
        //wybranie IV do szyfrowania
        private void button7_Click(object sender, RoutedEventArgs e)
        {
            fileIVEncContent = chooseFile(fileIVPathEnc);
        }

        //wybranie IV do odszyfrowania
        private void button8_Click(object sender, RoutedEventArgs e)
        {
            fileIVDecContent = chooseFile(fileIVPathEnc);
        }
        private string chooseFile(string path)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\users\\kokos\\source\\repos";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            var result = openFileDialog.ShowDialog();
            var fileStream = openFileDialog.OpenFile();
            string content;

            if (result == true)
            {
                path = openFileDialog.FileName;

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    content = reader.ReadToEnd();
                }

                MessageBox.Show(path, "File path", MessageBoxButton.OK);
                return content;
            }
            else
                return null;
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            numbers.add();
            MessageBox.Show("Zrobione!", "Stan", MessageBoxButton.OK);


        }

        private void Button_Multiply(object sender, RoutedEventArgs e)
        {
            numbers.multiply();
            MessageBox.Show("Zrobione!", "Stan", MessageBoxButton.OK);

        }

        private void Button_Mod(object sender, RoutedEventArgs e)
        {
            numbers.mod();
            MessageBox.Show("Zrobione!", "Stan", MessageBoxButton.OK);

        }
        private void Button_Minus(object sender, RoutedEventArgs e)
        {
            numbers.minus();
            MessageBox.Show("Zrobione!", "Stan", MessageBoxButton.OK);

        }
    }
}
