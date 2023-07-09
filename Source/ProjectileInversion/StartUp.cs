using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace ProjectileInversion;

[StaticConstructorOnStartup]
public static class StartUp
{
    public static readonly List<TraitDef> ValidTraitDefs;
    public static bool UnlimitedSkillPossible;

    static StartUp()
    {
        new Harmony("net.papaz.projectileinversion").PatchAll(Assembly.GetExecutingAssembly());
        ValidTraitDefs = new List<TraitDef>();
        foreach (var traitDef in DefDatabase<TraitDef>.AllDefsListForReading)
        {
            if (traitDef.HasModExtension<ProjectileInversion_ModExtension>())
            {
                ValidTraitDefs.Add(traitDef);
            }
        }

        UnlimitedSkillPossible =
            new SkillRecord
            {
                levelInt = 100, cachedTotallyDisabled = BoolUnknown.False, cachedPermanentlyDisabled = BoolUnknown.False
            }.GetLevel(false) != 20;

        Log.Message(
            $"[Rebound]: Added {ValidTraitDefs.Count} traits as rebound-traits. {string.Join(", ", ValidTraitDefs)}");
    }
}