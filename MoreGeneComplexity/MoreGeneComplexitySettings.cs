using UnityEngine;
using Verse;

namespace MoreGeneComplexity;

public class MoreGeneComplexitySettings: ModSettings
{
    public static int MaxGeneComplexityOffset = 0;
    public static int MaxGeneComplexityMultiplier = 10;
    
    private static string MaxGeneComplexityOffsetBuffer = MaxGeneComplexityOffset.ToString();
    private static string MaxGeneComplexityMultiplierBuffer = MaxGeneComplexityMultiplier.ToString();
    public override void ExposeData()
    {
        Scribe_Values.Look(ref MaxGeneComplexityOffset, "MaxGeneComplexityOffset", 5);
        Scribe_Values.Look(ref MaxGeneComplexityMultiplier, "MaxGeneComplexityMultiplier", 1);
        base.ExposeData();
    }

    public void DoSettingsWindowContents(Rect inRect)
    {
        Listing_Standard listingStandard = new Listing_Standard();
        listingStandard.Begin(inRect);
        
        listingStandard.DrawLabelledNumericSetting(ref MaxGeneComplexityOffset, ref MaxGeneComplexityOffsetBuffer, "MGC_MaxGeneComplexityOffset", 0, 1000);
        listingStandard.DrawLabelledNumericSetting(ref MaxGeneComplexityMultiplier, ref MaxGeneComplexityMultiplierBuffer, "MGC_MaxGeneComplexityMultiplier", 1, 1000);

        listingStandard.End();
    }
}