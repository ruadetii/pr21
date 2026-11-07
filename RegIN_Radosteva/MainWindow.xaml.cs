using RegIN_Radosteva.Classes;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace RegIN_Radosteva
{
    public partial class MainWindow : Window
    {
        public static MainWindow mainWindow;
        public User UserLogIn = new User();
        public MainWindow()
        {
            InitializeComponent();
            mainWindow = this;

        }
        public void OpenPage(Page page) 
        {
            DoubleAnimation StartAnimation = new DoubleAnimation();
            StartAnimation.From = 1;
            StartAnimation.To = 0;
            StartAnimation.Duration = TimeSpan.FromSeconds(0.6);
            StartAnimation.Completed += delegate 
            {
                frame.Navigate(page);
                DoubleAnimation EndAnimation = new DoubleAnimation();
                EndAnimation.From = 0;
                EndAnimation.To = 1;
                EndAnimation.Duration = TimeSpan.FromSeconds(1.2);
                frame.BeginAnimation(Frame.OpacityProperty, EndAnimation);
            };
            frame.BeginAnimation(Frame.OpacityProperty, StartAnimation);
        }
    }
}
