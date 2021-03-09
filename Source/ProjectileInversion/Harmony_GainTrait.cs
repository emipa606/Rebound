using HarmonyLib;
using RimWorld;
using Verse;

namespace ProjectileInversion
{
    // Token: 0x02000004 RID: 4
    [HarmonyPatch(typeof(SkillRecord), "Learn", typeof(float), typeof(bool))]
    public static class Harmony_GainTrait
    {
        // Token: 0x0600000C RID: 12 RVA: 0x00002610 File Offset: 0x00000810
        public static void Postfix(SkillRecord __instance)
        {
            var traverse = Traverse.Create(__instance);
            var value = traverse.Field("pawn").GetValue<Pawn>();
            if (API.hasTrait(value))
            {
                return;
            }

            if (!__instance.def.Equals(SkillDefOf.Melee))
            {
                return;
            }

            if (__instance.levelInt != 20)
            {
                return;
            }

            value.story.traits.GainTrait(new Trait(TraitDef.Named("ProjectileInversion_Trait")));
            var isColonist = value.IsColonist;
            if (isColonist)
            {
                Messages.Message(
                    "YourPawnGainProjectileInversionTraitMsg".Translate(value.Label,
                        TraitDef.Named("ProjectileInversion_Trait").degreeDatas.RandomElement().label.Translate()),
                    value, MessageTypeDefOf.PositiveEvent);
            }
        }
    }
}