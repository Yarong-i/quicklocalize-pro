# QuickLocalize Pro (v0.2.3)

CSV-driven localization for **TextMeshPro**. Import the sample, assign a DB, press **Play** — switch languages in minutes.

![Hero](media/qlp_cover_1950x1300.png)

**Asset Store:** (add link after approval)  
**Docs:** https://yarong-i.github.io/quicklocalize-docs  
**Issues:** https://github.com/Yarong-i/quicklocalize-pro/issues

---

## Why QLP?
- CSV (`key,en,ko…`) + `QLPBootstrap` → **2-minute setup**
- TMP-first workflow (`LocalizedTextTMP`)
- Lean runtime, no Asset Store deps
- Clean assemblies (Runtime / Editor / Samples)

## Quick Start
1) Import from Asset Store  
2) Package card → **Samples → Quick Start → Import**  
3) Add **`QLPBootstrap`** to an empty GameObject, assign `DemoDB`  
4) **Play** → press **1 / 2** for **en / ko**

```csharp
using UnityEngine;
using Yarong.QuickLocalize;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] LocalizationDB db;

    void Awake()
    {
        LocalizationService.SetDatabase(db);
        LocalizationService.Restore(); // saved language or default (en)
    }
}
Compatibility

Unity 2022.3 LTS+

Render pipelines: Built-in / URP / HDRP

Dependency: TextMeshPro 3.x (UPM)

AI-assisted development

Parts of the source code were authored with ChatGPT; all code was reviewed, edited, and tested by the author.
No AI/ML models or generated media are included.

License

MIT (see LICENSE
)

Changelog

See CHANGELOG.md
