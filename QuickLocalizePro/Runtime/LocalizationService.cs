using System;
using UnityEngine;

namespace Yarong.QuickLocalize
{
    public static class LocalizationService
    {
        public static event Action<Language> OnLanguageChanged;

        static LocalizationDB _db;
        static Language _current = Language.en;

        public static void SetDatabase(LocalizationDB db) => _db = db;

        public static void SetLanguage(string code)
        {
            if (Enum.TryParse<Language>(code, true, out var lang))
                SetLanguage(lang);
        }

        public static void SetLanguage(Language lang)
        {
            if (_current == lang) return;
            _current = lang;
            PlayerPrefs.SetString("QLang", _current.ToString());
            OnLanguageChanged?.Invoke(_current);
        }

        [RuntimeInitializeOnLoadMethod]
        static void Restore()
        {
            var saved = PlayerPrefs.GetString("QLang", "en");
            SetLanguage(saved);
        }

        public static string Get(string key) => _db == null ? key : _db.Get(_current, key);
        public static Language Current => _current;
    }
}
