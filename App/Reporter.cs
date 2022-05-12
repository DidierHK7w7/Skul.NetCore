using Skul.Entities;

namespace Skul.App
{
    public class Reporter
    {
        Dictionary<DictionaryKeys, IEnumerable<SchoolBaseObject>> _dictionary;
        public Reporter(Dictionary<DictionaryKeys, IEnumerable<SchoolBaseObject>> schoolObjectDictionary)
        {
            if (schoolObjectDictionary == null)
            {
                throw new ArgumentNullException(nameof (schoolObjectDictionary));
            }
            _dictionary = schoolObjectDictionary;
        }

        
    }
}