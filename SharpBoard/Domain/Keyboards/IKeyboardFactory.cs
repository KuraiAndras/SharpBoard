namespace SharpBoard.Domain.Keyboards
{
    public interface IKeyboardFactory
    {
        IKeyboard CreateKeyboard(KeyboardKind keyboard);
    }
}