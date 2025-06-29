using CombatExtended;
using Verse;

namespace ProjectileInversion;

public static class CEAPI
{
    public static bool CanInverse(Pawn pawn, BulletCE p)
    {
        var result = API.CheckPawnInverseChance(pawn) && checkProjectileInversion(p);
        return result;
    }

    private static bool isProjectileTooFast(BulletCE p)
    {
        return p.def.projectile.speed >= Settings.Speed;
    }

    private static bool checkProjectileInversion(BulletCE p)
    {
        return !isProjectileTooFast(p);
    }
}