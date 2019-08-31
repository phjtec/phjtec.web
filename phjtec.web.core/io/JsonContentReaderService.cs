using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace phjtec.web.core.io
{
    public class JsonContentReaderService : IJsonContentReader
    {
        public IEnumerable<T> ReadMany<T>(string path) where T : class
        {
            ValidPathCheck(path);

            foreach(var file in Directory.EnumerateFiles(path))
            {
                using (var sr = new StreamReader(file))
                {
                    var content = sr.ReadToEnd();
                    yield return JsonConvert.DeserializeObject<T>(content);
                }                
            }

            yield break;       
        }

        public T ReadSingle<T>(string path) where T : class
        {
            ValidPathCheck(path);

            using (var sr = new StreamReader(path))
            {
                var content = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(content);
            }
        }


        private void ValidPathCheck(string path)
        {
            var attr = File.GetAttributes(path);

            if (!attr.HasFlag(FileAttributes.Directory) && !File.Exists(path))
            {
                throw new FileNotFoundException("Cannot find the content file requested", path);
            }

            if (attr.HasFlag(FileAttributes.Directory) && !Directory.Exists(path))
            {
                throw new DirectoryNotFoundException($"Cannot find the directory requested: {path}");
            }
        }
    }
}
