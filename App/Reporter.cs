using System.Linq;
using System;
using System.Collections.Generic;
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

        public IEnumerable<School> GetEvaluationsList()
        {
            IEnumerable<School> result;
            if(_dictionary.TryGetValue(DictionaryKeys.School, out IEnumerable<SchoolBaseObject>list))    //TryGetValue, trata de encontrar el valor, si lo encuentra devuleve la lista, si no la devuelve null
            {
                result = list.Cast<School>();
            }else
            {
                result = null;
            }
            return result;
        }
    }
}