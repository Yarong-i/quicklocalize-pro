using UnityEngine;
using Yarong.QuickLocalize;

public class Bootstrap : MonoBehaviour
{
    public LocalizationDB db;
    void Awake()
    {
        LocalizationService.SetDatabase(db);
        LocalizationService.SetLanguage("en");
    }
}
