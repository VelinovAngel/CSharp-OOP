using _01.Logger.Models.Contracts;

namespace _01.Logger.Models.Files
{
    public class LogFile : IFile
    {

        public LogFile()
        {
        }

        public string Path { get; }

        public long Size { get; }

        public string Write(ILayout layout, IError error)
        {
            throw new System.NotImplementedException();
        }
    }
}
