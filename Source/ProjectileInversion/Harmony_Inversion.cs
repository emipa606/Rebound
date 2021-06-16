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
            var traverse = Traverse.Create(__instance);
            var thing = traverse.Field("usedTarget").GetValue<LocalTargetInfo>().Thing;

            if (!(thing is Pawn pawn) || pawn.kindDef.RaceProps.IsMechanoid)
            {
                return true;
            }

            if (pawn.story == null)
            {
                return true;
            }

            var animal = pawn.kindDef.RaceProps.Animal;
            if (animal)
            {
                return true;
            }

            if (!API.canInverse(pawn, __instance))
            {
                return true;
            }

            var value = traverse.Field("launcher").GetValue<Thing>();
            var def = __instance.def;
            GenClamor.DoClamor(pawn, 2.1f, ClamorDefOf.Impact);
            MoteMaker.MakeStaticMote(pawn.Position, pawn.Map, ThingDef.Named("Mote_SparkFlash"));
            SoundDefOf.MetalHitImportant.PlayOneShot(pawn);
            var value2 = Traverse.Create(pawn).Field("drawer").GetValue<Pawn_DrawTracker>();
            value2.Notify_DamageDeflected(new DamageInfo(__instance.def.projectile.damageDef, 1f));
            var showText = Settings.showText;
            if (showText)
            {
                MoteMaker.ThrowText(pawn.Position.ToVector3(), pawn.Map,
                    Settings.noRebound
                        ? "ProjectileInversionBlockText".Translate()
                        : "ProjectileInversionText".Translate());
            }

            ThingWithComps thingWithComps = null;
            if (pawn.equipment?.Primary != null)
            {
                thingWithComps = pawn.equipment.Primary;
            }

            pawn.skills.Learn(SkillDefOf.Melee, 200f);
            __instance.Destroy();
            if (!Settings.noRebound && value != null && pawn.Faction.HostileTo(value.Faction))
            {
                var projectile = (Projectile) GenSpawn.Spawn(def, pawn.Position, pawn.Map);
                var projectileHitFlags = ProjectileHitFlags.All;
                projectile.Launch(pawn, pawn.Position.ToVector3(), value.Position, value,
                    projectileHitFlags, thingWithComps);
            }

            API.damageWeapon(pawn);
            return false;
        }
    }
}