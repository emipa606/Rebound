using System.Reflection;
using HarmonyLib;
using Verse;

namespace ProjectileInversion
{
    [StaticConstructorOnStartup]
    public static class CERebound
    {
        static CERebound()
        {
            new Harmony("net.papaz.projectileinversion.ce").PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}