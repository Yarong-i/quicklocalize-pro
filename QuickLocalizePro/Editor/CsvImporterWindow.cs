using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Yarong.QuickLocalize.Editor
{
    public class CsvImporterWindow : EditorWindow
    {
        [MenuItem("Window/QuickLocalize/CSV Importer")]
        static void Open() => GetWindow<CsvImporterWindow>("CSV Importer");

        TextAsset _csv;
        LocalizationDB _db;
        Language[] _langs;
        string[][] _rows;

        void OnGUI()
        {
            GUILayout.Label("CSV → LocalizationDB", EditorStyles.boldLabel);
            _csv = (TextAsset)EditorGUILayout.ObjectField("CSV", _csv, typeof(TextAsset), false);
            _db  = (LocalizationDB)EditorGUILayout.ObjectField("Target DB", _db, typeof(LocalizationDB), false);

            if (GUILayout.Button("Parse")) Parse();
            using (new EditorGUI.DisabledScope(_rows == null || _db == null))
                if (GUILayout.Button("Import to DB")) ImportToDB();
        }

        void Parse()
        {
            if (_csv == null){ Msg("CSV not set"); return; }
            var lines = _csv.text.Replace("\r","").Split('\n');
            if (lines.Length < 2){ Msg("CSV empty"); return; }

            var header = Split(lines[0]);
            var langList = new List<Language>();
            for (int i=1;i<header.Length;i++)
                if (Enum.TryParse<Language>(header[i], true, out var l)) langList.Add(l);
            _langs = langList.ToArray();

            var list = new List<string[]>();
            for (int i=1;i<lines.Length;i++)
                if (!string.IsNullOrWhiteSpace(lines[i])) list.Add(Split(lines[i]));
            _rows = list.ToArray();
            Msg($"Parsed rows={_rows.Length}, langs={string.Join(",", _langs)}");
        }

        void ImportToDB()
        {
            var map = new Dictionary<Language, LocalizationDB.Table>();
            foreach (var l in _langs)
            {
                var t = _db.Tables.Find(x=>x.Language==l);
                if (t==null){ t=new LocalizationDB.Table{Language=l}; _db.Tables.Add(t); }
                t.Entries.Clear();
                map[l] = t;
            }
            foreach (var r in _rows)
            {
                if (r.Length==0) continue;
                var key = r[0];
                for (int i=0;i<_langs.Length;i++)
                {
                    var lang = _langs[i];
                    var val = (i+1<r.Length) ? r[i+1] : "";
                    map[lang].Entries.Add(new LocalizedEntry{ Key=key, Value=val });
                }
            }
            EditorUtility.SetDirty(_db);
            AssetDatabase.SaveAssets();
            Msg("Import finished");
        }

        string[] Split(string line)
        {
            var list = new List<string>(); bool q=false; var cur="";
            for(int i=0;i<line.Length;i++){
                var c=line[i];
                if(c=='"'){ q=!q; continue; }
                if(c==',' && !q){ list.Add(cur); cur=""; }
                else cur+=c;
            }
            list.Add(cur);
            return list.ToArray();
        }

        void Msg(string m) => EditorUtility.DisplayDialog("QuickLocalize", m, "OK");
    }
}
