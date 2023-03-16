using HarmonyLib;
using RimWorld;
using Verse;

namespace ProjectileInversion;

[HarmonyPatch(typeof(SkillRecord), "Learn", typeof(float), typeof(bool))]
public static class SkillRecord_Learn
{
    public static void Postfix(SkillRecord __instance, ref Pawn ___pawn)
    {
        if (!Settings.addTrait)
        {
            return;
        }

        if (API.hasTrait(___pawn))
        {
            return;
        }

        if (!__instance.def.Equals(SkillDefOf.Melee))
        {
            return;
        }

        if (__instance.GetLevel() < 20)
        {
            return;
        }

        ___pawn.story.traits.GainTrait(new Trait(TraitDef.Named("ProjectileInversion_Trait")));
        var isColonist = ___pawn.IsColonist;
        if (isColonist)
        {
            Messages.Message(
                "YourPawnGainProjectileInversionTraitMsg".Translate(___pawn.Label,
                    TraitDef.Named("ProjectileInversion_Trait").degreeDatas.RandomElement().label),
                ___pawn, MessageTypeDefOf.PositiveEvent);
        }
    }
}