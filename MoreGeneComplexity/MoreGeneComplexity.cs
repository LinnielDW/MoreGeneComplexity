using System.Reflection;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;
using static MoreGeneComplexity.MoreGeneComplexitySettings;

namespace MoreGeneComplexity;

[StaticConstructorOnStartup]
public class MoreGeneComplexityPatches
{
    static MoreGeneComplexityPatches()
    {
        AccessTools.Field(typeof(GeneTuning), "BiostatRange").SetValue(GeneTuning.BiostatRange,new IntRange(GeneTuningMin, 5));
        
        var harmony = new Harmony("com.arquebus.rimworld.mod.moregenecomplexity");
        harmony.PatchAll(Assembly.GetExecutingAssembly());
    }
}

public class MoreGeneComplexity : Mod
{
    readonly MoreGeneComplexitySettings settings;

    public MoreGeneComplexity(ModContentPack content) : base(content)
    {
        settings = GetSettings<MoreGeneComplexitySettings>();
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        settings.DoSettingsWindowContents(inRect);
        base.DoSettingsWindowContents(inRect);
    }

    public override string SettingsCategory()
    {
        return "MGC_SettingsTitle".Translate();
    }
}