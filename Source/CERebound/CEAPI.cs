using CombatExtended;
using Verse;

namespace ProjectileInversion
{
    public static class CEAPI
    {
        public static bool canInverse(Pawn pawn, BulletCE p)
        {
            var result = API.checkPawnInverseChance(pawn) && checkProjectileInversion(p);
            return result;
        }

        private static bool isProjectileTooFast(BulletCE p)
        {
            return p.def.projectile.speed >= Settings.speed;
        }

        private static bool checkProjectileInversion(BulletCE p)
        {
            return !isProjectileTooFast(p);
        }
    }
}