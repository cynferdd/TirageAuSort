using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Abstraction
{
    public interface IFileManager
    {
        IList<string> GetData(string filePath);

        void WriteData(string filePath, IList<string> data);

        void WriteData(string filePath, IDictionary<string, string> data);
    }
}
