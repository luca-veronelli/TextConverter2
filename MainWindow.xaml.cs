using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TextConverter2
{
    public partial class MainWindow : Window
    {
        public List<Conversion> DefaultConversions { get; set; }
        public List<Conversion> CustomConversions { get; set; }
        public List<Button> SelectedButtons { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            LoadDefaultConversions();
            SelectedButtons = new List<Button>();
            CustomConversions = new List<Conversion>();
        }

        public void LoadDefaultConversions()
        {
            // Configure default conversions here
            DefaultConversions = new List<Conversion>()
            {
                new Conversion { OldValue = "A", NewValue = "B" },
                new Conversion { OldValue = "B", NewValue = "C" },
            };

            // Create buttons for default conversions
            foreach (Conversion conversion in DefaultConversions)
            {
                Button button = CreateToggleConversionButton(conversion);
                wpDefaultConversions.Children.Add(button);
            }
        }

        public Button CreateToggleConversionButton(Conversion conversion)
        {
            Button button = new Button
            {
                Name = "btnToggleConversion",
                Content = conversion.OldValue,
                Tag = conversion,
                Margin = new Thickness(5),
                Background = Brushes.LightGray,
                Width = 60,
                Height = 30
            };

            button.Click += btnToggleConversion_Click;

            return button;
        }

        private void btnToggleConversion_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            // Select the button
            if (SelectedButtons.Contains(button))
            {
                button.Background = Brushes.LightGray;
                SelectedButtons.Remove(button);
            }
            // Deselect the button
            else
            {
                button.Background = Brushes.LightBlue;
                SelectedButtons.Add(button);
            }
        }

        private void btnAddCustomConversions_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemoveCustomConversion_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class Conversion
    {
        public string OldValue { get; set; }
        public string NewValue { get; set; }

        public override string ToString()
        {
            return $"{OldValue} -> {NewValue}";
        }
    }
}