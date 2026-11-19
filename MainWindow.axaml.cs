using System;
using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;

namespace _2._1_stoper_4tc_1_iwo_k;

public partial class MainWindow : Window
{
    private readonly Stopwatch _stopwatch = new();
    private readonly DispatcherTimer _timer = new();

    public MainWindow()
    {
        InitializeComponent();

        _timer.Interval = TimeSpan.FromMilliseconds(50);
        _timer.Tick += Timer_Tick;
    }

    private void StartButton_Click(object? sender, RoutedEventArgs e)
    {
        if (!_stopwatch.IsRunning)
        {
            _stopwatch.Start();
            _timer.Start();
        }
    }

    private void StopButton_Click(object? sender, RoutedEventArgs e)
    {
        if (_stopwatch.IsRunning)
        {
            _stopwatch.Stop();
            _timer.Stop();
            UpdateTimeDisplay();
        }
    }

    private void ResetButton_Click(object? sender, RoutedEventArgs e)
    {
        _stopwatch.Reset();
        _timer.Stop();
        UpdateTimeDisplay();
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        UpdateTimeDisplay();
    }

    private void UpdateTimeDisplay()
    {
        TimeSpan elapsed = _stopwatch.Elapsed;
        TimeDisplay.Text = string.Format("{0:00}:{1:00}.{2:00}",
            (int)elapsed.TotalMinutes,
            elapsed.Seconds,
            elapsed.Milliseconds / 10);
    }
}
