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
    /// Interaction logic for InstructorCard.xaml
    /// </summary>
    public partial class InstructorCard : UserControl
    {
        private bool _isDark = true;
        private Instructor? _currentInstructor;

        public InstructorCard()
        {
            InitializeComponent();
            MainWindow.ThemeChanged += OnThemeChanged;
        }

        private void OnThemeChanged(bool isDark)
        {
            _isDark = isDark;
            if (_currentInstructor != null)
                SetStatus(_currentInstructor.StatusText);
            UpdateShadow();
        }

        public void LoadInstructor(Instructor instructor)
        {
            _currentInstructor = instructor;

            AvatarText.Text = instructor.Initials;
            FullNameText.Text = instructor.FullName;
            EmailText.Text = instructor.Email;

            HireDateText.Text = instructor.HireDate.ToString("dd MMM yyyy");
            SalaryText.Text = instructor.SalaryFormatted;
            ExperienceText.Text = $"{instructor.YearsOfExperience} yrs";

            SetStatus(instructor.StatusText);
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
                case "inactive":
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
