using System.Linq;
using System.Collections.Generic;
using System.IO;
using Infrastructure.Abstraction;
using Newtonsoft.Json;
using System.Text;

namespace Infrastructure
{
    public class FileManager : IFileManager
    {
        private Encoding encoding = Encoding.GetEncoding("iso-8859-1");
        public IList<string> GetData(string filePath)
        {
            
            IList<string> lines = Open(filePath);
            return lines;
        }

        public void WriteData(string filePath, IList<string> data)
        {
            File.WriteAllLines(filePath, data, encoding);
        }

        public void WriteData(string filePath, IDictionary<string, string> data)
        {
            string content = JsonConvert.SerializeObject(data);
            File.WriteAllText(filePath, content, encoding);
        }

        private IList<string> Open(string filePath)
        {
            if (!File.Exists(filePath))
            {
                
                return null;
            }
            string[] lines = File.ReadAllLines(filePath, encoding);
            return lines?.ToList() ?? new List<string>();
        }
    }
}
