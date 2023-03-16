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

        Log.Message(
            $"[Rebound]: Added {ValidTraitDefs.Count} traits as rebound-traits. {string.Join(", ", ValidTraitDefs)}");
    }
}