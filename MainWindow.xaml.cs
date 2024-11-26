using System;
using System.Windows;

namespace ReferenceGeneratorApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the prefix from the TextBox
            string prefix = PrefixTextBox.Text.Trim();

            // Validate the prefix
            if (string.IsNullOrEmpty(prefix))
            {
                MessageBox.Show("Please enter a valid prefix.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Generate a unique reference
            string datePart = DateTime.Now.ToString("yyyyMMdd");
            string randomPart = new Random().Next(1000, 9999).ToString();
            string reference = $"{prefix}-{datePart}-{randomPart}";

            // Display the result
            ReferenceOutput.Text = reference;

            CopyButton.Visibility = Visibility.Visible;
        }


        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ReferenceOutput.Text))
            {
                Clipboard.SetText(ReferenceOutput.Text);
                MessageBox.Show("Reference copied to clipboard!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No reference to copy.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
