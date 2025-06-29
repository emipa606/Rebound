using CombatExtended;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;
using Verse.Sound;

namespace ProjectileInversion;

[HarmonyPatch(typeof(BulletCE), nameof(BulletCE.Impact), typeof(Thing))]
public static class BulletCE_Impact
{
    public static bool Prefix(Thing hitThing, BulletCE __instance, ref Thing ___launcher,
        ref Thing ___intendedTarget, ref Ray ___shotLine,
        ref float ___shotRotation, ref Vector2 ___origin, ref bool ___landed)
    {
        if (hitThing is not Pawn pawn || pawn.kindDef.RaceProps.IsMechanoid)
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

        if (!CEAPI.CanInverse(pawn, __instance))
        {
            return true;
        }

        GenClamor.DoClamor(pawn, 2.1f, ClamorDefOf.Impact);
        FleckMaker.Static(pawn.Position, pawn.Map, FleckDefOf.ShotFlash);
        SoundDefOf.MetalHitImportant.PlayOneShot(pawn);
        var value2 = Traverse.Create(pawn).Field("drawer").GetValue<Pawn_DrawTracker>();
        value2.Notify_DamageDeflected(new DamageInfo(__instance.def.projectile.damageDef, 1f));
        var showText = Settings.ShowText;

        pawn.skills.Learn(SkillDefOf.Melee, 200f);
        if (!Settings.NoRebound && ___launcher != null && pawn.Faction.HostileTo(___launcher.Faction))
        {
            ___intendedTarget = ___launcher;
            ___launcher = hitThing;
            ___shotRotation = (___shotRotation + 180) % 360;
            ___shotLine = new Ray(___shotLine.direction, ___shotLine.origin);
            __instance.Destination = ___origin;
            ___origin = new Vector2(__instance.Position.x, __instance.Position.z);
            ___landed = false;
            if (showText)
            {
                MoteMaker.ThrowText(pawn.Position.ToVector3(), pawn.Map, "ProjectileInversionText".Translate());
            }
        }
        else
        {
            __instance.Destroy();
            if (showText)
            {
                MoteMaker.ThrowText(pawn.Position.ToVector3(), pawn.Map,
                    "ProjectileInversionBlockText".Translate());
            }
        }

        API.DamageWeapon(pawn);
        return false;
    }
}