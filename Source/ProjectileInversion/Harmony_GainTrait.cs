using System;
using HarmonyLib;
using RimWorld;
using Verse;

namespace ProjectileInversion
{
	// Token: 0x02000004 RID: 4
	[HarmonyPatch(typeof(SkillRecord), "Learn", new Type[]
	{
		typeof(float),
		typeof(bool)
	})]
	public static class Harmony_GainTrait
	{
		// Token: 0x0600000C RID: 12 RVA: 0x00002610 File Offset: 0x00000810
		public static void Postfix(SkillRecord __instance)
		{
			Traverse traverse = Traverse.Create(__instance);
			Pawn value = traverse.Field("pawn").GetValue<Pawn>();
			bool flag = API.hasTrait(value);
			if (!flag)
			{
				bool flag2 = __instance.def.Equals(SkillDefOf.Melee);
				if (flag2)
				{
					bool flag3 = __instance.levelInt == 20;
					if (flag3)
					{
						value.story.traits.GainTrait(new Trait(TraitDef.Named("ProjectileInversion_Trait"), 0, false));
						bool isColonist = value.IsColonist;
						if (isColonist)
						{
							Messages.Message(TranslatorFormattedStringExtensions.Translate("YourPawnGainProjectileInversionTraitMsg", value.Label, Translator.Translate(TraitDef.Named("ProjectileInversion_Trait").degreeDatas.RandomElement<TraitDegreeData>().label)), value, MessageTypeDefOf.PositiveEvent, true);
						}
					}
				}
			}
		}
	}
}
