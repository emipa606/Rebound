using System.Reflection;
using HarmonyLib;
using Verse;

namespace ProjectileInversion
{
    [StaticConstructorOnStartup]
    public static class StartUp
    {
        static StartUp()
        {
            new Harmony("net.papaz.projectileinversion").PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}