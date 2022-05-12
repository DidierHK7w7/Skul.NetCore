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

        public IEnumerable<Evaluation> GetEvaluationsList()
        {
            if(_dictionary.TryGetValue(DictionaryKeys.Evaluation, out IEnumerable<SchoolBaseObject>list))    //TryGetValue, trata de encontrar el valor, si lo encuentra devuleve la lista, si no la devuelve null
            {
                return list.Cast<Evaluation>();
            }else
            {
                return new List<Evaluation>();
            }
        }

        public IEnumerable<string> GetSubjectsList()    //sobrecarga
        {
            return GetSubjectsList(out var dummy);
        }

        public IEnumerable<string> GetSubjectsList(out IEnumerable<Evaluation> evaluationsList)
        {
            evaluationsList = GetEvaluationsList();
            
            return (from ev in evaluationsList
                            select ev.Subject.Name).Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluation>> GetAssessmentDicBySubject()
        {
            var result = new Dictionary<string, IEnumerable<Evaluation>>();
            var subjectsList = GetSubjectsList(out var evaluationsList);
            foreach (var subjects in subjectsList)
            {
                var subjectEvaluation = from ev in evaluationsList
                                    where ev.Subject.Name == subjects
                                    select ev;
                result.Add(subjects, subjectEvaluation);
            }
            return result;
        }
    }
}