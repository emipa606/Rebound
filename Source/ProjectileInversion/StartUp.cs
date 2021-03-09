using System.Reflection;
using HarmonyLib;
using Verse;

namespace ProjectileInversion
{
    // Token: 0x02000007 RID: 7
    [StaticConstructorOnStartup]
    public static class StartUp
    {
        // Token: 0x06000014 RID: 20 RVA: 0x00002811 File Offset: 0x00000A11
        static StartUp()
        {
            new Harmony("net.papaz.projectileinversion").PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}