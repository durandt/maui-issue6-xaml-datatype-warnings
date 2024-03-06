using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace maui_issue6_xaml_datatype_warnings.ViewModels;

public partial class PageViewModel : ObservableObject
{
    static class States
    {
        public const string Init = nameof(Init);
        public const string Loaded = nameof(Loaded);
    }

    [ObservableProperty] private int _count;
    [ObservableProperty] private string _counterBtnText = "Click me";
    [ObservableProperty] private string _currentState = States.Init;
    [ObservableProperty] private bool _canStateChange = true;

    partial void OnCountChanged(int oldValue, int newValue)
    {
        if (Count == 1)
        {
            CounterBtnText = $"Clicked {Count} time";
        }
        else
        {
            CounterBtnText = $"Clicked {Count} times";
        }

        SemanticScreenReader.Announce(CounterBtnText);
    }

    [RelayCommand]
    private void Click()
    {
        Count += 1;
    }

    [RelayCommand]
    private void SwitchState()
    {
        CurrentState = States.Loaded;
    }
}