using System;
using System.Windows.Input;
using Avalonia.Media;

namespace NotNull;

public class CellViewModel : ViewModelBase
{
    private Player _owner = Player.None;

    public Player Owner
    {
        get => _owner;
        set
        {
            _owner = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Fill));
        }
    }

    public IBrush Fill =>
        Owner switch
        {
            Player.Player1 => Brushes.Red,
            Player.Player2 => Brushes.Blue,
            _ => Brushes.White
        };

    public ICommand ClickCommand { get; }

    public CellViewModel(Action<CellViewModel> onClick)
    {
        ClickCommand = new RelayCommand(() => onClick(this));
    }
}