using Mlie;
using UnityEngine;
using Verse;

namespace ProjectileInversion;

public class PIMod : Mod
{
    public PIMod(ModContentPack content) : base(content)
    {
        GetSettings<Settings>();
        Settings.currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    public override string SettingsCategory()
    {
        return "ProjectileInversionCategory".Translate();
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        Settings.DoSettingsWindowContents(inRect);
    }
}