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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BuildCards.Controls.Cards
{
    /// <summary>
    /// Interaction logic for CourseCard.xaml
    /// </summary>
    public partial class CourseCard : UserControl
    {
        private Course? _currentCourse;
        private bool _isDark = true;
        public CourseCard()
        {
            InitializeComponent();
            MainWindow.ThemeChanged += OnThemeChanged;
        }

        public void LoadCourse(Course course)
        {
            IconText.Text = course.Icon;
            TitleText.Text = course.Title;
            CodeText.Text = course.Code;
            PriceText.Text = $"${course.Price:F2}";
            DurationText.Text = $"{course.DurationHours}h";
            LevelText.Text = course.Level;

            SetStatus(course.Status);
        }

        private void OnThemeChanged(bool isDark)
        {
            _isDark = isDark;
            if (_currentCourse != null)
                SetStatus(_currentCourse.Status);
            UpdateShadow();
        }

        private void UpdateShadow()
        {
            if (_isDark)
            {
                CardShadow.Color = Color.FromRgb(59, 130, 246); // accent blue glow
                CardShadow.BlurRadius = 20;
                CardShadow.Opacity = 0.15;
            }
            else
            {
                CardShadow.Color = Color.FromRgb(0, 0, 0); // black shadow
                CardShadow.BlurRadius = 15;
                CardShadow.Opacity = 0.15;
            }
        }

        private void SetStatus(string status)
        {
            StatusText.Text = status;

            switch (status?.ToLower())
            {
                case "active":
                    StatusBadge.Background = (Brush)App.Current.Resources["SuccessLightBrush"];
                    StatusText.Foreground = (Brush)App.Current.Resources["SuccessBrush"];
                    break;
                case "draft":
                    StatusBadge.Background = (Brush)App.Current.Resources["CardHoverBackgroundBrush"];
                    StatusText.Foreground = (Brush)App.Current.Resources["TextSecondaryBrush"];
                    break;
                case "archived":
                    StatusBadge.Background = (Brush)App.Current.Resources["WarningLightBrush"];
                    StatusText.Foreground = (Brush)App.Current.Resources["WarningBrush"];
                    break;
                case "closed":
                    StatusBadge.Background = (Brush)App.Current.Resources["ErrorLightBrush"];
                    StatusText.Foreground = (Brush)App.Current.Resources["ErrorBrush"];
                    break;
                default:
                    StatusBadge.Background = (Brush)App.Current.Resources["CardHoverBackgroundBrush"];
                    StatusText.Foreground = (Brush)App.Current.Resources["TextSecondaryBrush"];
                    break;
            }
        }
    }
}
