# 🎨 BuildCards — WPF UI Practice Project

A modern **WPF desktop application** built with **C# and XAML** as a hands-on practice project to master WPF UI design, animations, theming, and component architecture.

---

## 🚀 Features

- 🌙 **Dark / Light theme switching** with persistence across sessions
- 🎴 **Custom card components** for Students, Courses, Instructors and Enrollments
- 📊 **Animated progress bar** on Enrollment cards
- 🗂️ **Collapsible sidebar** with smooth animation
- ✨ **Staggered card entrance animations** on page load
- 🖱️ **Hover effects** — cards lift up on mouse hover
- 🔄 **FlipCard** experiment with 3D-style flip animation
- 📱 **Responsive grid layout** — adapts columns based on window width
- 🎨 **Resource dictionary theming** — all colors centralized in `Colors.xaml`

---

## 🏗️ Project Structure
BuildCards/
├── Controls/Cards/
│   ├── StudentCard       — Avatar, name, email, phone, age, status
│   ├── CourseCard        — Icon, title, code, price, duration, level, status
│   ├── InstructorCard    — Avatar, name, email, hire date, salary, experience
│   ├── EnrollmentCard    — Student, course, progress bar, grade, date, status
│   └── FlipCard          — Experimental flip animation card
├── Models/
│   ├── Student.cs
│   ├── Course.cs
│   ├── Instructor.cs
│   └── Enrollment.cs
├── Pages/
│   ├── StudentPage
│   ├── CoursesPage
│   ├── InstructorPage
│   ├── EnrollmentPage
│   └── SettingsPage      — Theme toggle
└── Helpers/
├── Colors.xaml        — Dark theme colors
├── ColorsLight.xaml   — Light theme colors
└── Styles.xaml        — Buttons, scrollbar, card styles

---

## 🖥️ Tech Stack

| Technology | Version |
|---|---|
| .NET | 8.0 |
| WPF | .NET 8 |
| C# | 12 |
| XAML | WPF |

---

## 📸 Screenshots

### 🌙 Dark Mode

#### 👨‍🎓 Students
![Students Dark](https://github.com/benrisma133/BuildCards/blob/main/screenshots/Dark/students.png?raw=true)

#### 📚 Courses
![Courses Dark](https://github.com/benrisma133/BuildCards/blob/main/screenshots/Dark/courses.png?raw=true)

#### 👨‍🏫 Instructors
![Instructors Dark](https://github.com/benrisma133/BuildCards/blob/main/screenshots/Dark/instructors.png?raw=true)

#### 📋 Enrollments
![Enrollments Dark](https://github.com/benrisma133/BuildCards/blob/main/screenshots/Dark/enrollments.png?raw=true)

---

### ☀️ Light Mode

#### 👨‍🎓 Students
![Students Light](https://github.com/benrisma133/BuildCards/blob/main/screenshots/Light/students.png?raw=true)

#### 📚 Courses
![Courses Light](https://github.com/benrisma133/BuildCards/blob/main/screenshots/Light/courses.png?raw=true)

#### 👨‍🏫 Instructors
![Instructors Light](https://github.com/benrisma133/BuildCards/blob/main/screenshots/Light/instructors.png?raw=true)

#### 📋 Enrollments
![Enrollments Light](https://github.com/benrisma133/BuildCards/blob/main/screenshots/Light/enrollments.png?raw=true)

---

## 🎯 What I Practiced

- XAML layout — `Grid`, `StackPanel`, `UniformGrid`, `ScrollViewer`
- Custom `ControlTemplate` for buttons and checkboxes
- `DynamicResource` for runtime theme switching
- `DoubleAnimation`, `ThicknessAnimation`, `ScaleTransform`
- `EventTrigger` with `Storyboard` for hover effects
- WPF events pattern for component communication
- Git branching strategy — feature branches with nested child branches

---

## 🔧 Getting Started

```bash
git clone https://github.com/benrisma133/BuildCards.git
cd BuildCards
```

Open `BuildCards.slnx` in **Visual Studio 2022+** and run.

---

## 👨‍💻 Author

**Ismail Benrahhal** — Backend developer transitioning to full-stack .NET with WPF