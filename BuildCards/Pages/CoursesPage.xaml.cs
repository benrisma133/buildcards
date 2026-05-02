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
    /// Interaction logic for CoursesPage.xaml
    /// </summary>
    public partial class CoursesPage : UserControl
    {
        public CoursesPage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSampleCourses();
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

        private async void LoadSampleCourses()
        {
            var courses = new List<Course>
            {
                new Course { CourseId = 1, Title = "C# Fundamentals",        Code = "CS101", Price = 1500, Level = "Beginner",     DurationHours = 40, CreatedAt = DateTime.Now, Status = "Active",   Icon = "💻" },
                new Course { CourseId = 2, Title = "WPF Development",        Code = "CS202", Price = 2000, Level = "Intermediate", DurationHours = 60, CreatedAt = DateTime.Now, Status = "Active",   Icon = "🖥️" },
                new Course { CourseId = 3, Title = "SQL Server Basics",      Code = "DB101", Price = 1200, Level = "Beginner",     DurationHours = 30, CreatedAt = DateTime.Now, Status = "Draft",    Icon = "🗄️" },
                new Course { CourseId = 4, Title = "ASP.NET Core",           Code = "WB301", Price = 2500, Level = "Advanced",     DurationHours = 80, CreatedAt = DateTime.Now, Status = "Active",   Icon = "🌐" },
                new Course { CourseId = 5, Title = "Design Patterns",        Code = "CS303", Price = 1800, Level = "Advanced",     DurationHours = 45, CreatedAt = DateTime.Now, Status = "Archived", Icon = "📐" },
                new Course { CourseId = 6, Title = "Git & GitHub",           Code = "DV101", Price = 800,  Level = "Beginner",     DurationHours = 20, CreatedAt = DateTime.Now, Status = "Active",   Icon = "🔀" },
                new Course { CourseId = 7, Title = "Clean Architecture",     Code = "CS404", Price = 3000, Level = "Advanced",     DurationHours = 90, CreatedAt = DateTime.Now, Status = "Draft",    Icon = "🏗️" },
                new Course { CourseId = 8, Title = "Entity Framework Core",  Code = "DB202", Price = 1600, Level = "Intermediate", DurationHours = 50, CreatedAt = DateTime.Now, Status = "Closed",   Icon = "🔗" },
                new Course { CourseId = 9, Title = "XAML & WPF UI Design",  Code = "UI201", Price = 1400, Level = "Intermediate", DurationHours = 35, CreatedAt = DateTime.Now, Status = "Active",   Icon = "🎨" },
            };

            foreach (var course in courses)
            {
                var card = new CourseCard();
                card.Margin = new Thickness(10);
                card.VerticalAlignment = VerticalAlignment.Top;
                card.LoadCourse(course);

                // Start card hidden and above
                card.Opacity = 0;
                card.RenderTransform = new TranslateTransform(0, -30);

                CardsPanel.Children.Add(card);

                // Animate in
                AnimateCardIn(card);

                await Task.Delay(150);
            }
        }

        private void AnimateCardIn(CourseCard card)
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
