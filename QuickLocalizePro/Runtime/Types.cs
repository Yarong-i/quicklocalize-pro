using System;
using UnityEngine;

namespace Yarong.QuickLocalize
{
    [Serializable]
    public enum Language { ko, en, ja, zh, fr, de, es, ru, ar }

    [Serializable]
    public struct LocalizedEntry
    {
        public string Key;
        public string Value;
    }
}
