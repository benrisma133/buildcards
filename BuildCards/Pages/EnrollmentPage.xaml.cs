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
    /// Interaction logic for EnrollmentPage.xaml
    /// </summary>
    public partial class EnrollmentPage : UserControl
    {
        public EnrollmentPage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSampleEnrollments();
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

        private async void LoadSampleEnrollments()
        {
            var enrollments = new List<Enrollment>
            {
                new Enrollment { EnrollmentId = 1, StudentFullName = "Ahmed Hassan",   CourseTitle = "C# Fundamentals",       EnrollmentDate = new DateTime(2025, 1, 10), ProgressPercent = 100, FinalGrade = 95.5m,  Status = "Completed"  },
                new Enrollment { EnrollmentId = 2, StudentFullName = "Sara Alaoui",    CourseTitle = "WPF Development",        EnrollmentDate = new DateTime(2025, 3, 5),  ProgressPercent = 65,  FinalGrade = null,    Status = "Active"     },
                new Enrollment { EnrollmentId = 3, StudentFullName = "Youssef Benali", CourseTitle = "SQL Server Basics",      EnrollmentDate = new DateTime(2025, 2, 20), ProgressPercent = 0,   FinalGrade = null,    Status = "Cancelled"  },
                new Enrollment { EnrollmentId = 4, StudentFullName = "Fatima Zahra",   CourseTitle = "ASP.NET Core",           EnrollmentDate = new DateTime(2025, 4, 1),  ProgressPercent = 35,  FinalGrade = null,    Status = "Active"     },
                new Enrollment { EnrollmentId = 5, StudentFullName = "Karim Mansouri", CourseTitle = "Design Patterns",        EnrollmentDate = new DateTime(2024, 11, 15),ProgressPercent = 80,  FinalGrade = null,    Status = "Suspended"  },
                new Enrollment { EnrollmentId = 6, StudentFullName = "Nadia Alaoui",   CourseTitle = "Git & GitHub",           EnrollmentDate = new DateTime(2025, 1, 22), ProgressPercent = 100, FinalGrade = 88.0m,  Status = "Completed"  },
                new Enrollment { EnrollmentId = 7, StudentFullName = "Omar Idrissi",   CourseTitle = "Clean Architecture",     EnrollmentDate = new DateTime(2025, 5, 3),  ProgressPercent = 20,  FinalGrade = null,    Status = "Active"     },
                new Enrollment { EnrollmentId = 8, StudentFullName = "Ahmed Hassan",   CourseTitle = "Entity Framework Core",  EnrollmentDate = new DateTime(2025, 4, 18), ProgressPercent = 50,  FinalGrade = null,    Status = "Active"     },
            };

            foreach (var enrollment in enrollments)
            {
                var card = new EnrollmentCard();
                card.Margin = new Thickness(10);
                card.VerticalAlignment = VerticalAlignment.Top;
                card.LoadEnrollment(enrollment);

                // Start card hidden and above
                card.Opacity = 0;
                card.RenderTransform = new TranslateTransform(0, -30);

                CardsPanel.Children.Add(card);

                // Animate in
                AnimateCardIn(card);

                await Task.Delay(150);
            }
        }

        private void AnimateCardIn(EnrollmentCard card)
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
