# QuickLocalize Pro (v0.2.3)

**TextMeshPro** 전용 **CSV 기반 로컬라이즈 툴**. 샘플 임포트 → DB 할당 → **Play** — 몇 분 만에 언어 전환.

![Hero](media/qlp_cover_1950x1300.png)

**Asset Store:** (승인 후 링크 추가)  
**문서:** https://yarong-i.github.io/quicklocalize-docs  
**이슈:** https://github.com/Yarong-i/quicklocalize-pro/issues

---

## 왜 QLP인가
- CSV(`key,en,ko…`) + `QLPBootstrap` → **2분 셋업**
- TMP 특화 워크플로(`LocalizedTextTMP`)
- 경량 런타임, Asset Store 의존성 없음
- 어셈블리 분리(Runtime / Editor / Samples)

## 퀵 스타트
1) Asset Store에서 임포트  
2) 패키지 카드 → **Samples → Quick Start → Import**  
3) 빈 오브젝트에 **`QLPBootstrap`** 추가, `DemoDB` 할당  
4) **Play** → **1 / 2** 키로 **en / ko** 전환

```csharp
using UnityEngine;
using Yarong.QuickLocalize;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] LocalizationDB db;

    void Awake()
    {
        LocalizationService.SetDatabase(db);
        LocalizationService.Restore(); // 저장 언어 복원 또는 기본값(en)
    }
}

호환성

Unity 2022.3 LTS+

Render Pipeline: Built-in / URP / HDRP

의존성: TextMeshPro 3.x (UPM)

AI 보조 개발

일부 소스 코드는 ChatGPT의 도움을 받아 작성되었으며, 모든 코드는 개발자가 검토/수정/테스트했습니다.
패키지에는 AI/ML 모델이나 생성 미디어가 포함되지 않습니다.

라이선스

MIT (자세한 내용은 LICENSE
)

변경 기록

CHANGELOG.md

