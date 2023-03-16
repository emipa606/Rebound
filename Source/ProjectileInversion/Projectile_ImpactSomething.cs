using HarmonyLib;
using RimWorld;
using Verse;
using Verse.Sound;

namespace ProjectileInversion;

[HarmonyPatch(typeof(Projectile), "ImpactSomething")]
public static class Projectile_ImpactSomething
{
    public static bool Prefix(Projectile __instance, LocalTargetInfo ___usedTarget, Thing ___launcher)
    {
        var thing = ___usedTarget.Thing;

        if (thing is not Pawn pawn || pawn.kindDef.RaceProps.IsMechanoid)
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

        var def = __instance.def;
        GenClamor.DoClamor(pawn, 2.1f, ClamorDefOf.Impact);
        FleckMaker.Static(pawn.Position, pawn.Map, FleckDefOf.ShotFlash);
        SoundDefOf.MetalHitImportant.PlayOneShot(pawn);
        pawn.drawer.Notify_DamageDeflected(new DamageInfo(__instance.def.projectile.damageDef, 1f));
        var showText = Settings.showText;

        ThingWithComps thingWithComps = null;
        if (pawn.equipment?.Primary != null)
        {
            thingWithComps = pawn.equipment.Primary;
        }

        pawn.skills.Learn(SkillDefOf.Melee, 200f);
        __instance.Destroy();
        if (!Settings.noRebound && ___launcher != null && pawn.Faction.HostileTo(___launcher.Faction))
        {
            var projectile = (Projectile)GenSpawn.Spawn(def, pawn.Position, pawn.Map);
            var all = ProjectileHitFlags.All;
            projectile.Launch(pawn, pawn.Position.ToVector3(), new LocalTargetInfo(___launcher.Position), ___launcher,
                all, false, thingWithComps);
            if (showText)
            {
                MoteMaker.ThrowText(pawn.Position.ToVector3(), pawn.Map, "ProjectileInversionText".Translate());
            }
        }
        else
        {
            if (showText)
            {
                MoteMaker.ThrowText(pawn.Position.ToVector3(), pawn.Map,
                    "ProjectileInversionBlockText".Translate());
            }
        }

        API.damageWeapon(pawn);
        return false;
    }
}