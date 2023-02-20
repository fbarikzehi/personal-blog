namespace common.ui.ViewModels;

public abstract class ViewModelBase<TId>
{
    public TId Id { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; }


    public void ChangeSuccess(bool isSuccess, string message)
    {
        IsSuccess=isSuccess;
        Message=message;
    }
}
