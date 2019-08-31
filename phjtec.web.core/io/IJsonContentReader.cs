using System.Collections.Generic;

namespace phjtec.web.core.io
{
    public interface IJsonContentReader
    {
        IEnumerable<T> ReadMany<T>(string path) where T : class;
        T ReadSingle<T>(string path) where T : class;
    }
}
