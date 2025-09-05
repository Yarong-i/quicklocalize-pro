using TMPro;
using UnityEngine;

namespace Yarong.QuickLocalize
{
    [RequireComponent(typeof(TMP_Text))]
    public class LocalizedTextTMP : MonoBehaviour
    {
        public string Key;
        TMP_Text _text;
        void Awake()
        {
            _text = GetComponent<TMP_Text>();
            LocalizationService.OnLanguageChanged += _ => Refresh();
            Refresh();
        }
        void OnDestroy() => LocalizationService.OnLanguageChanged -= _ => Refresh();
        public void Refresh() { if (_text) _text.text = LocalizationService.Get(Key); }
    }
}
