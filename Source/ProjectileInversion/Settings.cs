using System;
using UnityEngine;
using Verse;

namespace ProjectileInversion;

public class Settings : ModSettings
{
    public static int Speed = 200;

    public static bool ShowText = true;
    public static bool NoRebound;
    public static bool AddTrait = true;
    public static string CurrentVersion;
    public static int WeaponDamage = 1;
    public static int LevelToTrigger = 20;
    public static float BaseChance = 0.5f;
    public static bool UncapManipulation;

    public static void DoSettingsWindowContents(Rect rect)
    {
        var listingStandard = new Listing_Standard(GameFont.Small) { ColumnWidth = rect.width };
        listingStandard.Begin(rect);
        listingStandard.Label("ProjectileInversionSettingSpeedLabel".Translate() + ":" + Speed.ToString("0.0"),
            -1f, "ProjectileInversionSettingSpeedDesc".Translate());
        Speed = (int)listingStandard.Slider(Speed, 1f, 999f);
        listingStandard.CheckboxLabeled("ProjectileInversionSettingShowTextLabel".Translate(), ref ShowText,
            "ProjectileInversionSettingShowTextDesc".Translate());
        listingStandard.CheckboxLabeled("ProjectileInversionSettingNoReboundLabel".Translate(), ref NoRebound,
            "ProjectileInversionSettingNoReboundDesc".Translate());
        listingStandard.CheckboxLabeled("ProjectileInversionSettingAutoTraitLabel".Translate(), ref AddTrait,
            "ProjectileInversionSettingAutoTraitDesc".Translate());
        listingStandard.CheckboxLabeled("ProjectileInversionSettingUncapManipulationLabel".Translate(),
            ref UncapManipulation,
            "ProjectileInversionSettingUncapManipulationDesc".Translate());
        listingStandard.Label("ProjectileInversionSettingLevelToTriggerLabel".Translate(LevelToTrigger), -1f,
            "ProjectileInversionSettingLevelToTriggerDesc".Translate());
        listingStandard.IntAdjuster(ref LevelToTrigger, 1, 1);
        if (LevelToTrigger > 20 && !StartUp.UnlimitedSkillPossible)
        {
            LevelToTrigger = 20;
        }

        listingStandard.Gap();
        listingStandard.Label("ProjectileInversionSettingWeaponDamageLabel".Translate(WeaponDamage));
        listingStandard.IntAdjuster(ref WeaponDamage, 1);
        listingStandard.Gap();
        listingStandard.Label("ProjectileInversionSettingBaseChanceLabel".Translate(BaseChance * 100));
        BaseChance = (float)Math.Round(listingStandard.Slider(BaseChance, 0.01f, 1f), 2);
        if (CurrentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("ProjectileInversionSettingCurrentModVersionLabel".Translate(CurrentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
    }

    public override void ExposeData()
    {
        Scribe_Values.Look(ref LevelToTrigger, "PILevelToTrigger", 20);
        Scribe_Values.Look(ref Speed, "PISpeed", 200);
        Scribe_Values.Look(ref ShowText, "PIShowText", true);
        Scribe_Values.Look(ref AddTrait, "PIAddTrait", true);
        Scribe_Values.Look(ref NoRebound, "PINoRebound");
        Scribe_Values.Look(ref UncapManipulation, "uncapManipulation");
        Scribe_Values.Look(ref WeaponDamage, "PIWeaponDamage", 1);
        Scribe_Values.Look(ref BaseChance, "PIBaseChance", 0.5f);
    }
}