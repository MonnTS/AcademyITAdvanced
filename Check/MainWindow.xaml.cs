using System.Text.RegularExpressions;
using System.Windows;

namespace Check;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private bool IsNameValid()
    {
        return Regex.IsMatch(TxtName.Text, @"^[A-Z][a-zA-Z]*$");
    }

    private bool IsDoBValid()
    {
        return Regex.IsMatch(TxtDoB.Text, @"^([0-2][0-9]|(3)[0-1])[.](((0)[0-9])|((1)[0-2]))[.]\d{4}$");
    }

    private bool IsEmailValid()
    {
        return Regex.IsMatch(TxtEmail.Text, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
    }

    private bool IsPhoneNrValid()
    {
        return Regex.IsMatch(TxtPhone.Text, @"^[0-9]{9}$");
    }

    private void btn_Check_Click(object sender, RoutedEventArgs e)
    {
        Name.Content = !IsNameValid() ? "Name : Bad" : "Name : Good";

        Dob.Content = !IsDoBValid() ? "Date of Birth : Bad" : "Date of Birth : Good";

        Email.Content = !IsEmailValid() ? "Email : Bad" : "Email : Good";

        Phone.Content = !IsPhoneNrValid() ? "Phone Number : Bad" : "Phone Number : Good";
    }
}