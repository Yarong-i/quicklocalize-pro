using System.Collections.Generic;
using UnityEngine;

namespace Yarong.QuickLocalize
{
    [CreateAssetMenu(menuName="QuickLocalize/Localization DB", fileName="LocalizationDB")]
    public class LocalizationDB : ScriptableObject
    {
        [System.Serializable]
        public class Table
        {
            public Language Language;
            public List<LocalizedEntry> Entries = new();
            public Dictionary<string,string> ToMap()
            {
                var d = new Dictionary<string,string>(Entries.Count);
                foreach (var e in Entries) if (!d.ContainsKey(e.Key)) d[e.Key] = e.Value;
                return d;
            }
        }

        public List<Table> Tables = new();

        public string Get(Language lang, string key)
        {
            var table = Tables.Find(t => t.Language == lang);
            if (table == null) return key;
            foreach (var e in table.Entries) if (e.Key == key) return e.Value;
            return key;
        }
    }
}
