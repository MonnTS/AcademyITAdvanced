using System.IO;
using System.Windows;

namespace FilesInDirectory
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

        private void Search(DirectoryInfo directory)
        {
            FileInfo[] files = directory.GetFiles("*.*");
            ListBox.Items.Add("Files in " + directory.FullName);

            foreach (var file in files)
            {
                ListBox.Items.Add($"{file} created {file.CreationTime} and size {file.Length}");
            }
            
            DirectoryInfo[] directories = directory.GetDirectories();
            foreach (DirectoryInfo dir in directories)
            {
                Search(dir);
            }
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog(this).GetValueOrDefault())
            {
                string? selectedPath = dialog.SelectedPath;
                DirectoryInfo directory = new DirectoryInfo(selectedPath);
                Search(directory);
            }
        }
    }
}