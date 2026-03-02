using System;
using System.Windows.Input;

namespace NotNull;

public class ResizeDialogViewModel : ViewModelBase
{
    public int Rows { get; set; }
    public int Columns { get; set; }

    public ICommand ApplyCommand { get; }

    private readonly Action<int, int> _onApply;

    public ResizeDialogViewModel(Action<int, int> onApply, int currentRows, int currentColumns)
    {
        _onApply = onApply;
        Rows = currentRows;
        Columns = currentColumns;

        ApplyCommand = new RelayCommand(() =>
        {
            _onApply(Rows, Columns);
        });
    }
}