using BuildCards.Models;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace BuildCards.Controls.Cards
{
    public partial class StudentCard : UserControl
    {
        private Student? _currentStudent;
        private bool _isDark = true;

        public StudentCard()
        {
            InitializeComponent();
            MainWindow.ThemeChanged += OnThemeChanged;
        }

        private void OnThemeChanged(bool isDark)
        {
            _isDark = isDark;
            if (_currentStudent != null)
                SetStatus(_currentStudent.Status);
            UpdateShadow();
        }

        public void LoadStudent(Student student)
        {
            _currentStudent = student;

            AvatarText.Text = student.FirstName.Substring(0, 1).ToUpper();
            FullNameText.Text = $"{student.FirstName} {student.LastName}";
            EmailText.Text = student.Email;

            PhoneText.Text = string.IsNullOrEmpty(student.PhoneNumber)
                ? "N/A" : student.PhoneNumber;

            AgeText.Text = $"{GetAge(student.DateOfBirth)} years";

            SetStatus(student.Status);
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
                case "suspended":
                    StatusBadge.Background = (Brush)App.Current.Resources["WarningLightBrush"];
                    StatusText.Foreground = (Brush)App.Current.Resources["WarningBrush"];
                    break;
                case "graduated":
                    StatusBadge.Background = (Brush)App.Current.Resources["InfoLightBrush"];
                    StatusText.Foreground = (Brush)App.Current.Resources["InfoBrush"];
                    break;
                default:
                    StatusBadge.Background = (Brush)App.Current.Resources["CardHoverBackgroundBrush"];
                    StatusText.Foreground = (Brush)App.Current.Resources["TextSecondaryBrush"];
                    break;
            }
        }

        private int GetAge(DateOnly birthDate)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            int age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age)) age--;

            return age;
        }
    }
}