using System;
using HarmonyLib;
using RimWorld;
using Verse;
using Verse.Sound;

namespace ProjectileInversion
{
	// Token: 0x02000003 RID: 3
	[HarmonyPatch(typeof(Projectile), "ImpactSomething", new Type[]
	{

	})]
	public static class Harmony_Inversion
	{
		// Token: 0x0600000B RID: 11 RVA: 0x000023A0 File Offset: 0x000005A0
		public static bool Prefix(Projectile __instance)
		{
			Traverse traverse = Traverse.Create(__instance);
			Thing thing = traverse.Field("usedTarget").GetValue<LocalTargetInfo>().Thing;
			bool flag = thing != null;
			if (flag)
			{
				Pawn pawn = thing as Pawn;
				bool flag2 = pawn != null && !pawn.kindDef.RaceProps.IsMechanoid;
				if (flag2)
				{
					bool flag3 = pawn.story == null;
					if (flag3)
					{
						return true;
					}
					bool animal = pawn.kindDef.RaceProps.Animal;
					if (animal)
					{
						return true;
					}
					bool flag4 = API.canInverse(pawn, __instance);
					if (flag4)
					{
						Thing value = traverse.Field("launcher").GetValue<Thing>();
						ThingDef def = __instance.def;
						GenClamor.DoClamor(pawn, 2.1f, ClamorDefOf.Impact);
						MoteMaker.MakeStaticMote(pawn.Position, pawn.Map, ThingDef.Named("Mote_SparkFlash"), 1f);
						SoundDefOf.MetalHitImportant.PlayOneShot(pawn);
						Pawn_DrawTracker value2 = Traverse.Create(pawn).Field("drawer").GetValue<Pawn_DrawTracker>();
						value2.Notify_DamageDeflected(new DamageInfo(__instance.def.projectile.damageDef, 1f, 0f, -1f, null, null, null, DamageInfo.SourceCategory.ThingOrUnknown, null));
						bool showText = Settings.showText;
						if (showText)
						{
							MoteMaker.ThrowText(pawn.Position.ToVector3(), pawn.Map, Translator.Translate("ProjectileInversionText"), -1f);
						}
						ThingWithComps thingWithComps = null;
						bool flag5 = pawn.equipment != null && pawn.equipment.Primary != null;
						if (flag5)
						{
							thingWithComps = pawn.equipment.Primary;
						}
						pawn.skills.Learn(SkillDefOf.Melee, 200f, false);
						__instance.Destroy(DestroyMode.Vanish);
						bool flag6 = value != null && pawn.Faction.HostileTo(value.Faction);
						if (flag6)
						{
							Projectile projectile = (Projectile)GenSpawn.Spawn(def, pawn.Position, pawn.Map, WipeMode.Vanish);
							ProjectileHitFlags projectileHitFlags = ProjectileHitFlags.All;
							projectile.Launch(pawn, pawn.Position.ToVector3(), value.Position, value, projectileHitFlags, thingWithComps, null);
						}
						API.damageWeapon(pawn);
						return false;
					}
				}
			}
			return true;
		}
	}
}
