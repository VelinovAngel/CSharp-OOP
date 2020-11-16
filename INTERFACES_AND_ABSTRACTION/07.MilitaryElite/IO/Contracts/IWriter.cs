using System;
namespace _07.MilitaryElite.IO.Contracts
{
    public interface IWriter
    {
        string Write(string text);

        string WriteLine(string text);
    }
}
