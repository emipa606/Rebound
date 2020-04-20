using System;
using UnityEngine;
using Verse;

namespace ProjectileInversion
{
	// Token: 0x02000006 RID: 6
	public class Settings : ModSettings
	{
		// Token: 0x06000010 RID: 16 RVA: 0x00002724 File Offset: 0x00000924
		public static void DoSettingsWindowContents(Rect rect)
		{
			Listing_Standard listing_Standard = new Listing_Standard(GameFont.Small);
			listing_Standard.ColumnWidth = rect.width;
			listing_Standard.Begin(rect);
			listing_Standard.Label(Translator.Translate("ProjectileInversionSettingSpeedLabel") + ":" + Settings.speed.ToString("0.0"), -1f, Translator.Translate("ProjectileInversionSettingSpeedDesc"));
			Settings.speed = (int)listing_Standard.Slider((float)Settings.speed, 1f, 999f);
			listing_Standard.CheckboxLabeled(Translator.Translate("ProjectileInversionSettingShowTextLabel"), ref Settings.showText, Translator.Translate("ProjectileInversionSettingShowTextDesc"));
			listing_Standard.End();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000027CB File Offset: 0x000009CB
		public override void ExposeData()
		{
			Scribe_Values.Look<int>(ref Settings.speed, "PISpeed", 200, false);
			Scribe_Values.Look<bool>(ref Settings.showText, "PIShowText", true, false);
		}

		// Token: 0x04000001 RID: 1
		public static int speed = 200;

		// Token: 0x04000002 RID: 2
		public static bool showText = true;
	}
}
