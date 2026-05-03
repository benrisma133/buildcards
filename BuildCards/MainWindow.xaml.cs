using BuildCards.Controls.Cards;
using BuildCards.Models;
using BuildCards.Pages;
using System.Diagnostics;
using System.Text;
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

namespace BuildCards;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Button _activeButton;
    private bool _isSidebarOpen = true;
    private bool _userClosedSidebar = false;
    private CancellationTokenSource _sidebarCts;

    private readonly Geometry _hamburgerIcon = Geometry.Parse("M4 6H20 M4 12H20 M4 18H20");
    private readonly Geometry _closeIcon = Geometry.Parse("M11.7071 4.29289C12.0976 4.68342 12.0976 5.31658 11.7071 5.70711L6.41421 11H20C20.5523 11 21 11.4477 21 12C21 12.5523 20.5523 13 20 13H6.41421L11.7071 18.2929C12.0976 18.6834 12.0976 19.3166 11.7071 19.7071C11.3166 20.0976 10.6834 20.0976 10.2929 19.7071L3.29289 12.7071C3.10536 12.5196 3 12.2652 3 12C3 11.7348 3.10536 11.4804 3.29289 11.2929L10.2929 4.29289C10.6834 3.90237 11.3166 3.90237 11.7071 4.29289Z");

    public static event Action<bool>? ThemeChanged;
    public MainWindow()
    {
        InitializeComponent();

        // Load saved theme
        _isDark = Properties.Settings.Default.IsDarkTheme;
        if (!_isDark)
        {
            var newDict = new ResourceDictionary
            {
                Source = new Uri("/Helpers/ColorsLight.xaml", UriKind.Relative)
            };
            foreach (var key in newDict.Keys)
                App.Current.Resources[key] = newDict[key];
        }

        LoadSampleStudents();
    }

    // ── Active menu ───────────────────────────────────────────────────────────
    private void SetActiveMenu(Button btn)
    {
        if (_activeButton != null)
            _activeButton.ClearValue(TagProperty);
        _activeButton = btn;
        _activeButton.Tag = "Active";
    }

    // ── Hamburger toggle ──────────────────────────────────────────────────────
    private async void HamburgerBtn_Click(object sender, RoutedEventArgs e)
    {
        await ToggleSidebar();
        _userClosedSidebar = !_isSidebarOpen;
    }

    private async Task ToggleSidebar(bool forceCollapse = false)
    {
        _sidebarCts?.Cancel();
        _sidebarCts = new CancellationTokenSource();
        var token = _sidebarCts.Token;

        bool targetState = forceCollapse ? false : !_isSidebarOpen;
        const int timing = 220;
        double fromWidth = SideBar.ActualWidth;
        double toWidth = targetState ? 260 : 64;

        _isSidebarOpen = targetState;

        // Update hamburger icon only — never move it
        HamburgerPath.Data = targetState ? _closeIcon : _hamburgerIcon;

        // Hide TEXT only when collapsing — icons stay visible always
        if (!targetState)
            SetSidebarTextsVisibility(false);

        var ease = new CubicEase { EasingMode = EasingMode.EaseInOut };
        var duration = TimeSpan.FromMilliseconds(timing);

        SideBar.BeginAnimation(WidthProperty, new DoubleAnimation
        {
            From = fromWidth,
            To = toWidth,
            Duration = duration,
            EasingFunction = ease
        });

        MainContent.BeginAnimation(MarginProperty, new ThicknessAnimation
        {
            From = MainContent.Margin,
            To = new Thickness(toWidth, 0, 0, 0),
            Duration = duration,
            EasingFunction = ease
        });

        if (targetState)
        {
            try
            {
                await Task.Delay((int)(timing * 0.6), token);
                SetSidebarTextsVisibility(true);
            }
            catch (TaskCanceledException) { }
        }
    }

    private void SetSidebarTextsVisibility(bool visible)
    {
        var vis = visible ? Visibility.Visible : Visibility.Collapsed;

        LogoTextStack.Visibility = vis;
        LogoBox.Visibility = vis;
        ProfileTextStack.Visibility = vis;

        foreach (var btn in new[] { BtnDashboard, BtnStudents, BtnCourses,
                                BtnInstructors, BtnEnrollments, BtnSettings })
        {
            if (btn.Content is Grid g)
            {
                // Show/hide text only
                foreach (UIElement child in g.Children)
                {
                    if (child is TextBlock tb)
                        tb.Visibility = vis;
                }

                // Center icon when collapsed, left-align when expanded
                if (g.ColumnDefinitions.Count > 0)
                {
                    g.ColumnDefinitions[0].Width = visible
                        ? GridLength.Auto
                        : new GridLength(1, GridUnitType.Star);

                    if (g.ColumnDefinitions.Count > 1)
                        g.ColumnDefinitions[1].Width = visible
                            ? new GridLength(1, GridUnitType.Star)
                            : new GridLength(0);
                }
            }

            // Center button content when collapsed
            if (_isSidebarOpen)
            {
                btn.HorizontalAlignment = HorizontalAlignment.Stretch;
            }
            else
            {
                btn.HorizontalAlignment = HorizontalAlignment.Center;
            }
        }
    }

    private System.Collections.Generic.IEnumerable<TextBlock> FindTextBlocks(DependencyObject parent)
    {
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
        {
            var child = VisualTreeHelper.GetChild(parent, i);
            if (child is TextBlock tb) yield return tb;
            foreach (var nested in FindTextBlocks(child))
                yield return nested;
        }
    }


    private void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
    {
        //if (e.NewSize.Width < 600)
        //    CardsPanel.Columns = 1;
        //else if (e.NewSize.Width < 900)
        //    CardsPanel.Columns = 2;
        //else if (e.NewSize.Width < 1200)
        //    CardsPanel.Columns = 3;
        //else
        //    CardsPanel.Columns = 4;
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

            //CardsPanel.Children.Add(card);

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

    private bool _isDark;

    private void BtnSettings_Click(object sender, RoutedEventArgs e)
    {
        SetActiveMenu(BtnSettings);
        PageTitle.Text = "Settings";

        var settingsPage = new SettingsPage();

        // 4. Subscribe to the event
        settingsPage.ThemeToggled += OnThemeToggled;

        // 5. Sync toggle with current theme state
        settingsPage.SetThemeState(_isDark);

        PageContent.Content = settingsPage;
    }

    // 6. This runs when SettingsPage fires ThemeToggled
    private void OnThemeToggled(bool isDark)
    {
        _isDark = isDark;
        Properties.Settings.Default.IsDarkTheme = _isDark;
        Properties.Settings.Default.Save();

        var source = _isDark
            ? new Uri("/Helpers/Colors.xaml", UriKind.Relative)
            : new Uri("/Helpers/ColorsLight.xaml", UriKind.Relative);

        var newDict = new ResourceDictionary { Source = source };

        foreach (var key in newDict.Keys)
            App.Current.Resources[key] = newDict[key];

        ThemeChanged?.Invoke(_isDark);
    }


    private void BtnDashboard_Click(object sender, RoutedEventArgs e)
    {

    }

    private void BtnStudents_Click(object sender, RoutedEventArgs e)
    {
        SetActiveMenu(BtnStudents);
        PageTitle.Text = "Students";
        PageContent.Content = new StudentPage();
    }

    private void BtnCourses_Click(object sender, RoutedEventArgs e)
    {
        SetActiveMenu(BtnCourses);
        PageTitle.Text = "Courses";
        PageContent.Content = new CoursesPage();
    }

    private void BtnInstructors_Click(object sender, RoutedEventArgs e)
    {
        SetActiveMenu(BtnInstructors);
        PageTitle.Text = "Instructors";
        PageContent.Content = new InstructorPage();
    }

    private void BtnEnrollments_Click(object sender, RoutedEventArgs e)
    {
        SetActiveMenu(BtnEnrollments);
        PageTitle.Text = "Enrollments";
        PageContent.Content = new EnrollmentPage();
    }

}