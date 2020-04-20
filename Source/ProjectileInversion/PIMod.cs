using System;
using UnityEngine;
using Verse;

namespace ProjectileInversion
{
	// Token: 0x02000005 RID: 5
	public class PIMod : Mod
	{
		// Token: 0x0600000D RID: 13 RVA: 0x000026EA File Offset: 0x000008EA
		public PIMod(ModContentPack content) : base(content)
		{
			base.GetSettings<Settings>();
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000026FC File Offset: 0x000008FC
		public override string SettingsCategory()
		{
			return Translator.Translate("ProjectileInversionCategory");
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002718 File Offset: 0x00000918
		public override void DoSettingsWindowContents(Rect inRect)
		{
			Settings.DoSettingsWindowContents(inRect);
		}
	}
}
