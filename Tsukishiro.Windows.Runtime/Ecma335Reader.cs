using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

namespace Tsukishiro.Windows.Runtime;

public class Ecma335Reader: IDisposable
{
    private MetadataReader _reader;
    private PEReader _peReader;

    public Ecma335Reader(string location)
    {
        _peReader = new PEReader(File.OpenRead(location));
        _reader = _peReader.GetMetadataReader();
    }

    public List<TypeDefinition> GetType(IEnumerable<KeyValuePair<string,string>> ns)
    {
        var hashset = new HashSet<(string Key, string Value)>(ns.Select(kvp => (kvp.Key, kvp.Value)));

        return _reader.TypeDefinitions.Select(defHandle => _reader.GetTypeDefinition(defHandle)).Where(def =>
            hashset.Contains((_reader.GetString(def.Namespace), _reader.GetString(def.Name)))).ToList();
    }
    
    public List<TypeDefinition> FilterType(List<TypeDefinition> types){}

    ~Ecma335Reader()
    {
        Dispose(false);
    }

    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            _peReader.Dispose();
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        Dispose(true);
    }
}