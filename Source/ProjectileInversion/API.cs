using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace ProjectileInversion;

public static class API
{
    public static bool canInverse(Pawn pawn, Projectile p)
    {
        var result = checkPawnInverseChance(pawn) && checkProjectileInversion(p);
        return result;
    }

    public static void damageWeapon(Pawn pawn)
    {
        if (!hasWeapon(pawn))
        {
            return;
        }

        if (!canDamageWeapon(pawn))
        {
            return;
        }

        var primary = pawn.equipment.Primary;
        var hitPoints = primary.HitPoints;
        primary.HitPoints = hitPoints - Settings.weaponDamage;
    }

    private static bool hasWeapon(Pawn pawn)
    {
        return !(pawn.equipment.Primary == null || !pawn.equipment.Primary.def.IsMeleeWeapon ||
                 pawn.equipment.Primary.IsBrokenDown());
    }

    private static bool randomCheck(float chance)
    {
        var random = new Random();
        var num = random.Next(0, 100);
        return num <= chance * 100f;
    }

    public static bool hasTrait(Pawn pawn)
    {
        return StartUp.ValidTraitDefs.Any(pawn.story.traits.HasTrait);
    }

    public static bool checkPawnInverseChance(Pawn pawn)
    {
        if (pawn.IsColonist && !pawn.Drafted)
        {
            return false;
        }

        if (!hasTrait(pawn))
        {
            return false;
        }

        if (!hasWeapon(pawn))
        {
            return false;
        }

        if (pawn.equipment.Primary.def.useHitPoints && pawn.equipment.Primary.HitPoints <= 1)
        {
            pawn.equipment.TryDropEquipment(pawn.equipment.Primary, out _, pawn.Position);
        }

        var num = (float)pawn.skills.GetSkill(SkillDefOf.Melee).levelInt;
        var num2 = pawn.health.capacities.GetLevel(PawnCapacityDefOf.Manipulation);
        if (num2 > 1f)
        {
            num2 = 1f;
        }

        var chance = Settings.baseChance * num2 * (num / 10f);
        return randomCheck(chance);
    }

    private static bool canDamageWeapon(Pawn pawn)
    {
        bool result;
        if (!hasWeapon(pawn))
        {
            result = false;
        }
        else
        {
            var num = (float)pawn.skills.GetSkill(SkillDefOf.Melee).levelInt;
            var chance = 0.4f / (num / 5f);
            result = randomCheck(chance);
        }

        return result;
    }

    private static bool isVanillaProjectile(Projectile p)
    {
        return new List<Type>
        {
            typeof(Bullet),
            typeof(Projectile_Explosive),
            typeof(Projectile_DoomsdayRocket)
        }.Contains(p.GetType());
    }

    private static bool isProjectileTooFast(Projectile p)
    {
        return p.def.projectile.speed >= Settings.speed;
    }

    private static bool checkProjectileInversion(Projectile p)
    {
        return !isProjectileTooFast(p);
    }
}