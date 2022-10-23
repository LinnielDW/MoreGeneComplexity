using UnityEngine;
using Verse;

namespace MoreGeneComplexity;

public class MoreGeneComplexitySettings: ModSettings
{
    public static int MaxGeneComplexityOffset = 0;
    public static int MaxGeneComplexityMultiplier = 10;
    public static int GeneTuningMin = -10;
    // public static int GeneTuningMax = 10;

    private static string MaxGeneComplexityOffsetBuffer = MaxGeneComplexityOffset.ToString();
    private static string MaxGeneComplexityMultiplierBuffer = MaxGeneComplexityMultiplier.ToString();
    private static string GeneTuningMinBuffer = GeneTuningMin.ToString();
    // private static string GeneTuningMaxBuffer = GeneTuningMax.ToString();

    public override void ExposeData()
    {
        Scribe_Values.Look(ref MaxGeneComplexityOffset, "MaxGeneComplexityOffset", 5);
        Scribe_Values.Look(ref MaxGeneComplexityMultiplier, "MaxGeneComplexityMultiplier", 1);
        Scribe_Values.Look(ref GeneTuningMin, "GeneTuningMin", -10);
        // Scribe_Values.Look(ref GeneTuningMax, "GeneTuningMax", 10);
        base.ExposeData();
    }

    public void DoSettingsWindowContents(Rect inRect)
    {
        Listing_Standard listingStandard = new Listing_Standard();
        listingStandard.Begin(inRect);
        
        listingStandard.DrawLabelledNumericSetting(ref MaxGeneComplexityOffset, ref MaxGeneComplexityOffsetBuffer, "MGC_MaxGeneComplexityOffset", 0, 1000);
        listingStandard.DrawLabelledNumericSetting(ref MaxGeneComplexityMultiplier, ref MaxGeneComplexityMultiplierBuffer, "MGC_MaxGeneComplexityMultiplier", 1, 1000);
        listingStandard.DrawLabelledNumericSetting(ref GeneTuningMin, ref GeneTuningMinBuffer, "MGC_GeneTuningMin", -1000, -5);
        // listingStandard.DrawLabelledNumericSetting(ref GeneTuningMax, ref GeneTuningMaxBuffer, "MGC_GeneTuningMax", 5, 1000);

        listingStandard.End();
    }

    public int newBioStat_Min()
    {
        return GeneTuningMin;
    }
}