using BuildCards.Controls.Cards;
using BuildCards.Models;
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

namespace BuildCards;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        LoadSampleStudents();
    }

    private void LoadSampleStudents()
    {
        var students = new List<Student>
        {
            new Student { StudentId = 1, FirstName = "Ahmed",   LastName = "Hassan",  Email = "ahmed@email.com",  PhoneNumber = "+212 612345678", DateOfBirth = new DateOnly(2000, 5, 10), RegisteredAt = DateTime.Now, Status = "Active" },
            new Student { StudentId = 2, FirstName = "Sara",    LastName = "Alaoui",  Email = "sara@email.com",   PhoneNumber = "+212 698765432", DateOfBirth = new DateOnly(1999, 3, 22), RegisteredAt = DateTime.Now, Status = "Suspended" },
            new Student { StudentId = 3, FirstName = "Youssef", LastName = "Benali",  Email = "youssef@email.com",PhoneNumber = null,             DateOfBirth = new DateOnly(2001, 8, 15), RegisteredAt = DateTime.Now, Status = "Graduated" },
        };

        foreach (var student in students)
        {
            var card = new StudentCard();
            card.Width = 300;
            card.Margin = new Thickness(10);
            card.LoadStudent(student);
            CardsPanel.Children.Add(card);
        }
    }
}