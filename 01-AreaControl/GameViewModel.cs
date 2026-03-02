using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia.Controls;

namespace NotNull;

public class GameViewModel : ViewModelBase
{
    private Player _currentPlayer = Player.Player1;

    public Player CurrentPlayer
    {
        get => _currentPlayer;
        set
        {
            _currentPlayer = value;
            OnPropertyChanged();
        }
    }

    public int Rows { get; set; } = 6;
    public int Columns { get; set; } = 6;

    public ObservableCollection<CellViewModel> Cells { get; } = new();
    public ICommand OpenResizeDialogCommand { get; }

    public GameViewModel()
    {
        OpenResizeDialogCommand = new RelayCommand(OpenResizeDialog);
        BuildBoard();
    }

    private void BuildBoard()
    {
        Cells.Clear();

        for (int i = 0; i < Rows * Columns; i++)
        {
            Cells.Add(new CellViewModel(OnCellClicked));
        }
    }

    private void OnCellClicked(CellViewModel cell)
    {
        // Prevent overwriting
        if (cell.Owner != Player.None)
            return;

        cell.Owner = CurrentPlayer;

        SwitchTurn();
    }

    private void SwitchTurn()
    {
        CurrentPlayer = CurrentPlayer == Player.Player1
            ? Player.Player2
            : Player.Player1;
    }

    private void OpenResizeDialog()
    {
        var dialog = new ResizeDialog();

        // Set DataContext with callback to resize
        dialog.DataContext = new ResizeDialogViewModel((newRows, newColumns) =>
        {
            Rows = newRows;
            Columns = newColumns;
            BuildBoard(); // rebuild board with new size
            dialog.Close(); // close dialog after applying
        }, Rows, Columns);

        // Show as modal dialog
        if (Avalonia.Application.Current != null && Avalonia.Application.Current.ApplicationLifetime is Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime desktop)
        {
            dialog.ShowDialog(desktop.MainWindow);
        }
    }
}