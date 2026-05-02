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
    /// Interaction logic for InstructorPage.xaml
    /// </summary>
    public partial class InstructorPage : UserControl
    {
        public InstructorPage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSampleInstructors();
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

        private async void LoadSampleInstructors()
        {
            var instructors = new List<Instructor>
            {
                new Instructor { InstructorId = 1, FirstName = "Mohammed", LastName = "Ali",     Email = "mohammed@email.com", HireDate = new DateOnly(2018, 3, 15), Salary = 8500,  ManagerId = null, IsActive = true  },
                new Instructor { InstructorId = 2, FirstName = "Sara",     LastName = "Hassan",  Email = "sara@email.com",     HireDate = new DateOnly(2019, 7, 22), Salary = 7200,  ManagerId = 1,    IsActive = true  },
                new Instructor { InstructorId = 3, FirstName = "Youssef",  LastName = "Benali",  Email = "youssef@email.com",  HireDate = new DateOnly(2020, 1, 10), Salary = 6800,  ManagerId = 1,    IsActive = false },
                new Instructor { InstructorId = 4, FirstName = "Fatima",   LastName = "Zahra",   Email = "fatima@email.com",   HireDate = new DateOnly(2021, 5, 3),  Salary = 6500,  ManagerId = 2,    IsActive = true  },
                new Instructor { InstructorId = 5, FirstName = "Karim",    LastName = "Mansouri", Email = "karim@email.com",   HireDate = new DateOnly(2022, 9, 18), Salary = 6000,  ManagerId = 2,    IsActive = true  },
                new Instructor { InstructorId = 6, FirstName = "Nadia",    LastName = "Alaoui",  Email = "nadia@email.com",    HireDate = new DateOnly(2023, 2, 27), Salary = 5500,  ManagerId = 3,    IsActive = false },
                new Instructor { InstructorId = 7, FirstName = "Omar",     LastName = "Idrissi", Email = "omar@email.com",     HireDate = new DateOnly(2024, 6, 1),  Salary = 5000,  ManagerId = 3,    IsActive = true  },
            };

            foreach (var instructor in instructors)
            {
                var card = new InstructorCard();
                card.Margin = new Thickness(10);
                card.VerticalAlignment = VerticalAlignment.Top;
                card.LoadInstructor(instructor);

                // Start card hidden and above
                card.Opacity = 0;
                card.RenderTransform = new TranslateTransform(0, -30);

                CardsPanel.Children.Add(card);

                // Animate in
                AnimateCardIn(card);

                await Task.Delay(150);
            }
        }

        private void AnimateCardIn(InstructorCard card)
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
