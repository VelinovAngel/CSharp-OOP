namespace _01.Logger.IOManegment.Contracts
{
    public interface IWriter
    {
        void Write(string text);

        void WriteLine(string text);
    }
}
