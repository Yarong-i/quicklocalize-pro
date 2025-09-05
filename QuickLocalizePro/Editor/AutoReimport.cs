using UnityEditor;

namespace Yarong.QuickLocalize.Editor
{
    public class AutoReimport : AssetPostprocessor
    {
        static void OnPostprocessAllAssets(string[] imported, string[] deleted, string[] moved, string[] movedFrom)
        {
            foreach (var path in imported)
                if (path.EndsWith(".csv"))
                    UnityEngine.Debug.Log($"[QuickLocalize] CSV changed: {path}");
        }
    }
}
