using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Media;

namespace NotNull;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.Width = 900; 
        this.Height = 750;
    }

    private bool isBlueTurn = true;

    private void OnCellClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {

        Console.WriteLine("Clicked!");

        if (sender is Button button)
        {
            if (!button.IsEnabled)
                return;

            if (isBlueTurn)
                button.Background = Brushes.Blue;
            else
                button.Background = Brushes.Red;

            button.IsEnabled = false;

            isBlueTurn = !isBlueTurn;
        }
    }

}

