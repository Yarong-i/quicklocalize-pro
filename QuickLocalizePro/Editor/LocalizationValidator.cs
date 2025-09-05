using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Yarong.QuickLocalize.Editor
{
    public static class LocalizationValidator
    {
        [MenuItem("Window/QuickLocalize/Validate DB")]
        public static void Validate()
        {
            var db = Selection.activeObject as Yarong.QuickLocalize.LocalizationDB;
            if (db == null){ EditorUtility.DisplayDialog("QuickLocalize","Select a LocalizationDB asset","OK"); return; }

            var keySeen = new HashSet<string>();
            var duplicates = new HashSet<string>();
            int emptyValues = 0;

            foreach (var t in db.Tables)
            {
                foreach (var e in t.Entries)
                {
                    if (!keySeen.Add(e.Key)) duplicates.Add(e.Key);
                    if (string.IsNullOrWhiteSpace(e.Value)) emptyValues++;
                }
            }

            EditorUtility.DisplayDialog("Validation",
                $"Duplicate keys: {duplicates.Count}\nEmpty values: {emptyValues}",
                "OK");
        }
    }
}
