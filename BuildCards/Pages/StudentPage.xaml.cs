using BuildCards.Controls.Cards;
using BuildCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BuildCards.Pages
{
    /// <summary>
    /// Interaction logic for StudentPage.xaml
    /// </summary>
    public partial class StudentPage : UserControl
    {
        public StudentPage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSampleStudents();
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width < 600)
                CardsPanel.Columns = 1;
            else if (e.NewSize.Width < 900)
                CardsPanel.Columns = 2;
            else if (e.NewSize.Width < 1200)
                CardsPanel.Columns = 3;
            else
                CardsPanel.Columns = 4;
        }

        private async void LoadSampleStudents()
        {
            var students = new List<Student>
            {
                new Student { StudentId = 1, FirstName = "Ahmed",   LastName = "Hassan",  Email = "ahmed@email.com",  PhoneNumber = "+212 612345678", DateOfBirth = new DateOnly(2000, 5, 10), RegisteredAt = DateTime.Now, Status = "Active" },
                new Student { StudentId = 2, FirstName = "Sara",    LastName = "Alaoui",  Email = "sara@email.com",   PhoneNumber = "+212 698765432", DateOfBirth = new DateOnly(1999, 3, 22), RegisteredAt = DateTime.Now, Status = "Suspended" },
                new Student { StudentId = 3, FirstName = "Youssef", LastName = "Benali",  Email = "youssef@email.com",PhoneNumber = null,             DateOfBirth = new DateOnly(2001, 8, 15), RegisteredAt = DateTime.Now, Status = "Graduated" },
                new Student { StudentId = 1, FirstName = "Ahmed",   LastName = "Hassan",  Email = "ahmed@email.com",  PhoneNumber = "+212 612345678", DateOfBirth = new DateOnly(2000, 5, 10), RegisteredAt = DateTime.Now, Status = "Active" },
                new Student { StudentId = 2, FirstName = "Sara",    LastName = "Alaoui",  Email = "sara@email.com",   PhoneNumber = "+212 698765432", DateOfBirth = new DateOnly(1999, 3, 22), RegisteredAt = DateTime.Now, Status = "Suspended" },
                new Student { StudentId = 3, FirstName = "Youssef", LastName = "Benali",  Email = "youssef@email.com",PhoneNumber = null,             DateOfBirth = new DateOnly(2001, 8, 15), RegisteredAt = DateTime.Now, Status = "Graduated" },
                new Student { StudentId = 1, FirstName = "Ahmed",   LastName = "Hassan",  Email = "ahmed@email.com",  PhoneNumber = "+212 612345678", DateOfBirth = new DateOnly(2000, 5, 10), RegisteredAt = DateTime.Now, Status = "Active" },
                new Student { StudentId = 2, FirstName = "Sara",    LastName = "Alaoui",  Email = "sara@email.com",   PhoneNumber = "+212 698765432", DateOfBirth = new DateOnly(1999, 3, 22), RegisteredAt = DateTime.Now, Status = "Suspended" },
                new Student { StudentId = 3, FirstName = "Youssef", LastName = "Benali",  Email = "youssef@email.com",PhoneNumber = null,             DateOfBirth = new DateOnly(2001, 8, 15), RegisteredAt = DateTime.Now, Status = "Graduated" },
                new Student { StudentId = 1, FirstName = "Ahmed",   LastName = "Hassan",  Email = "ahmed@email.com",  PhoneNumber = "+212 612345678", DateOfBirth = new DateOnly(2000, 5, 10), RegisteredAt = DateTime.Now, Status = "Active" },
                new Student { StudentId = 2, FirstName = "Sara",    LastName = "Alaoui",  Email = "sara@email.com",   PhoneNumber = "+212 698765432", DateOfBirth = new DateOnly(1999, 3, 22), RegisteredAt = DateTime.Now, Status = "Suspended" },
                new Student { StudentId = 3, FirstName = "Youssef", LastName = "Benali",  Email = "youssef@email.com",PhoneNumber = null,             DateOfBirth = new DateOnly(2001, 8, 15), RegisteredAt = DateTime.Now, Status = "Graduated" },
                new Student { StudentId = 1, FirstName = "Ahmed",   LastName = "Hassan",  Email = "ahmed@email.com",  PhoneNumber = "+212 612345678", DateOfBirth = new DateOnly(2000, 5, 10), RegisteredAt = DateTime.Now, Status = "Active" },
                new Student { StudentId = 2, FirstName = "Sara",    LastName = "Alaoui",  Email = "sara@email.com",   PhoneNumber = "+212 698765432", DateOfBirth = new DateOnly(1999, 3, 22), RegisteredAt = DateTime.Now, Status = "Suspended" },
                new Student { StudentId = 3, FirstName = "Youssef", LastName = "Benali",  Email = "youssef@email.com",PhoneNumber = null,             DateOfBirth = new DateOnly(2001, 8, 15), RegisteredAt = DateTime.Now, Status = "Graduated" },
                new Student { StudentId = 1, FirstName = "Ahmed",   LastName = "Hassan",  Email = "ahmed@email.com",  PhoneNumber = "+212 612345678", DateOfBirth = new DateOnly(2000, 5, 10), RegisteredAt = DateTime.Now, Status = "Active" },
                new Student { StudentId = 2, FirstName = "Sara",    LastName = "Alaoui",  Email = "sara@email.com",   PhoneNumber = "+212 698765432", DateOfBirth = new DateOnly(1999, 3, 22), RegisteredAt = DateTime.Now, Status = "Suspended" },
                new Student { StudentId = 3, FirstName = "Youssef", LastName = "Benali",  Email = "youssef@email.com",PhoneNumber = null,             DateOfBirth = new DateOnly(2001, 8, 15), RegisteredAt = DateTime.Now, Status = "Graduated" },
                new Student { StudentId = 1, FirstName = "Ahmed",   LastName = "Hassan",  Email = "ahmed@email.com",  PhoneNumber = "+212 612345678", DateOfBirth = new DateOnly(2000, 5, 10), RegisteredAt = DateTime.Now, Status = "Active" },
                new Student { StudentId = 2, FirstName = "Sara",    LastName = "Alaoui",  Email = "sara@email.com",   PhoneNumber = "+212 698765432", DateOfBirth = new DateOnly(1999, 3, 22), RegisteredAt = DateTime.Now, Status = "Suspended" },
                new Student { StudentId = 3, FirstName = "Youssef", LastName = "Benali",  Email = "youssef@email.com",PhoneNumber = null,             DateOfBirth = new DateOnly(2001, 8, 15), RegisteredAt = DateTime.Now, Status = "Graduated" },
            };

            foreach (var student in students)
            {
                var card = new StudentCard();
                card.Margin = new Thickness(10);
                card.VerticalAlignment = VerticalAlignment.Top;
                card.LoadStudent(student);

                // Start card hidden and above
                card.Opacity = 0;
                card.RenderTransform = new TranslateTransform(0, -30);

                CardsPanel.Children.Add(card);

                // Animate in
                AnimateCardIn(card);

                await Task.Delay(150);
            }
        }

        private void AnimateCardIn(StudentCard card)
        {
            var duration = new Duration(TimeSpan.FromSeconds(0.4));

            var fadeIn = new DoubleAnimation(0, 1, duration);

            var slideIn = new DoubleAnimation(-30, 0, duration)
            {
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };

            card.BeginAnimation(UIElement.OpacityProperty, fadeIn);
            ((TranslateTransform)card.RenderTransform).BeginAnimation(TranslateTransform.YProperty, slideIn);
        }


    }
}
