using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace RegIN_Radosteva.Elements
{
    public partial class ElementCapture : UserControl
    {
        public CorrectCapture HandlerCorrectCapture;
        public delegate void CorrectCapture();
        string StrCapture = "";
        int ElementWidth = 280;
        int ElementHeight = 50;
        public ElementCapture()
        {
            InitializeComponent();
            CreateCapture();
        }
        public void CreateCapture()
        {
            InputCapture.Text = "";
            Capture.Children.Clear();
            StrCapture = "";
            CreateBackground();
            Background();
        }
        void CreateBackground() 
        {
            Random random = new Random();
            for (int i = 0; i < 100; i++) 
            {
                int back = random.Next(0, 10);
                Label LBackground = new Label()
                {
                    Content = back,
                    FontSize = random.Next(10, 16),
                    FontWeight = FontWeights.Bold,
                    Foreground = new SolidColorBrush(Color.FromArgb(100, (byte)random.Next(0,255), (byte)random.Next(0, 255), (byte)random.Next(0, 255))),
                    Margin = new Thickness(random.Next(0, ElementWidth - 20), random.Next(0, ElementHeight - 20), 0, 0)
                };
                Capture.Children.Add(LBackground);
            }
        }
        void Background() 
        {
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                int back = random.Next(0, 10);
                Label LCode = new Label()
                {
                    Content = back,
                    FontSize = 30,
                    FontWeight = FontWeights.Bold,
                    Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255))),
                    Margin = new Thickness(ElementWidth/2 - 60 + i*30, random.Next(-10,10), 0, 0)
                };
                StrCapture += back.ToString();
                Capture.Children.Add(LCode);
            }
        }
        public bool OnCapture() 
        {
            return StrCapture == InputCapture.Text;
        }
        private void EnterCapture(object sender, KeyEventArgs e)
        {
            if (InputCapture.Text.Length == 4) 
            {
                if (!OnCapture())
                {
                    CreateCapture();
                }
                else if (HandlerCorrectCapture != null) 
                {
                    HandlerCorrectCapture.Invoke();
                }
            }
        }
    }
}
