using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace BuildCards.Controls.Cards
{
    public partial class FlipCard : UserControl
    {
        private bool isFlipped = false;

        public FlipCard()
        {
            InitializeComponent();
        }

        private void CardContainer_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Flip();
        }

        private void Flip()
        {
            // المرحلة 1: تسد (ScaleX = 0)
            DoubleAnimation closeAnim = new DoubleAnimation
            {
                To = 0,
                Duration = TimeSpan.FromMilliseconds(400),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };

            closeAnim.Completed += (s, e) =>
            {
                // تبديل الواجهة
                if (!isFlipped)
                {
                    FrontCard.Visibility = Visibility.Collapsed;
                    BackCard.Visibility = Visibility.Visible;
                }
                else
                {
                    FrontCard.Visibility = Visibility.Visible;
                    BackCard.Visibility = Visibility.Collapsed;
                }

                isFlipped = !isFlipped;

                // المرحلة 2: تفتح مقلوبة
                DoubleAnimation openAnim = new DoubleAnimation
                {
                    To = isFlipped ? -1 : 1,
                    Duration = TimeSpan.FromMilliseconds(400),
                    EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
                };

                CardScale.BeginAnimation(System.Windows.Media.ScaleTransform.ScaleXProperty, openAnim);
            };

            CardScale.BeginAnimation(System.Windows.Media.ScaleTransform.ScaleXProperty, closeAnim);
        }
    }
}