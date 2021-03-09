using UnityEngine;
using Verse;

namespace ProjectileInversion
{
    // Token: 0x02000006 RID: 6
    public class Settings : ModSettings
    {
        // Token: 0x04000001 RID: 1
        public static int speed = 200;

        // Token: 0x04000002 RID: 2
        public static bool showText = true;

        // Token: 0x06000010 RID: 16 RVA: 0x00002724 File Offset: 0x00000924
        public static void DoSettingsWindowContents(Rect rect)
        {
            var listing_Standard = new Listing_Standard(GameFont.Small) {ColumnWidth = rect.width};
            listing_Standard.Begin(rect);
            listing_Standard.Label("ProjectileInversionSettingSpeedLabel".Translate() + ":" + speed.ToString("0.0"),
                -1f, "ProjectileInversionSettingSpeedDesc".Translate());
            speed = (int) listing_Standard.Slider(speed, 1f, 999f);
            listing_Standard.CheckboxLabeled("ProjectileInversionSettingShowTextLabel".Translate(), ref showText,
                "ProjectileInversionSettingShowTextDesc".Translate());
            listing_Standard.End();
        }

        // Token: 0x06000011 RID: 17 RVA: 0x000027CB File Offset: 0x000009CB
        public override void ExposeData()
        {
            Scribe_Values.Look(ref speed, "PISpeed", 200);
            Scribe_Values.Look(ref showText, "PIShowText", true);
        }
    }
}