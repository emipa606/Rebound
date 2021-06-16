using UnityEngine;
using Verse;

namespace ProjectileInversion
{
    public class Settings : ModSettings
    {
        public static int speed = 200;

        public static bool showText = true;
        public static bool noRebound;

        public static void DoSettingsWindowContents(Rect rect)
        {
            var listing_Standard = new Listing_Standard(GameFont.Small) {ColumnWidth = rect.width};
            listing_Standard.Begin(rect);
            listing_Standard.Label("ProjectileInversionSettingSpeedLabel".Translate() + ":" + speed.ToString("0.0"),
                -1f, "ProjectileInversionSettingSpeedDesc".Translate());
            speed = (int) listing_Standard.Slider(speed, 1f, 999f);
            listing_Standard.CheckboxLabeled("ProjectileInversionSettingShowTextLabel".Translate(), ref showText,
                "ProjectileInversionSettingShowTextDesc".Translate());
            listing_Standard.CheckboxLabeled("ProjectileInversionSettingNoReboundLabel".Translate(), ref noRebound,
                "ProjectileInversionSettingNoReboundDesc".Translate());
            listing_Standard.End();
        }

        public override void ExposeData()
        {
            Scribe_Values.Look(ref speed, "PISpeed", 200);
            Scribe_Values.Look(ref showText, "PIShowText", true);
            Scribe_Values.Look(ref noRebound, "PINoRebound");
        }
    }
}