using BuildCards.Models;
using System.Windows.Controls;
using System.Windows.Media;

namespace BuildCards.Controls.Cards
{
    /// <summary>
    /// Interaction logic for StudentCard.xaml
    /// </summary>
    public partial class StudentCard : UserControl
    {
        public StudentCard()
        {
            InitializeComponent();
        }

        public void LoadStudent(Student student)
        {
            AvatarText.Text = student.FirstName.Substring(0, 1).ToUpper();

            FullNameText.Text = $"{student.FirstName} {student.LastName}";
            EmailText.Text = student.Email;

            PhoneText.Text = string.IsNullOrEmpty(student.PhoneNumber)
                ? "N/A" : student.PhoneNumber;

            var today = DateOnly.FromDateTime(DateTime.Today);
            int age = today.Year - student.DateOfBirth.Year;
            if (student.DateOfBirth > today.AddYears(-age)) age--;
            AgeText.Text = $"{age} years";

            SetStatus(student.Status);

        }

        private void SetStatus(string status)
        {
            StatusText.Text = status;

            switch (status?.ToLower())
            {
                case "active":
                    StatusBadge.Background = new SolidColorBrush(
                        (Color)ColorConverter.ConvertFromString("#064E3B"));
                    StatusText.Foreground = new SolidColorBrush(
                        (Color)ColorConverter.ConvertFromString("#10B981"));
                    break;
                case "suspended":
                    StatusBadge.Background = new SolidColorBrush(
                        (Color)ColorConverter.ConvertFromString("#78350F"));
                    StatusText.Foreground = new SolidColorBrush(
                        (Color)ColorConverter.ConvertFromString("#F59E0B"));
                    break;
                case "graduated":
                    StatusBadge.Background = new SolidColorBrush(
                        (Color)ColorConverter.ConvertFromString("#1E3A5F"));
                    StatusText.Foreground = new SolidColorBrush(
                        (Color)ColorConverter.ConvertFromString("#3B82F6"));
                    break;
                default:
                    StatusBadge.Background = new SolidColorBrush(
                        (Color)ColorConverter.ConvertFromString("#1F2937"));
                    StatusText.Foreground = new SolidColorBrush(
                        (Color)ColorConverter.ConvertFromString("#94A3B8"));
                    break;
            }
        }
    }
}
