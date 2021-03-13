namespace SharpBoard.Domain.Keyboards
{
    public interface IKeyboardFactory
    {
        IKeyBoard Create(KeyboardKind keyboardKind);
    }
}