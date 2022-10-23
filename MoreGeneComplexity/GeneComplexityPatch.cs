using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using RimWorld;
using Verse;
using static MoreGeneComplexity.MoreGeneComplexitySettings;

namespace MoreGeneComplexity;

public class Patches
{
    [HarmonyPatch(typeof(Building_GeneAssembler))]
    [HarmonyPatch("MaxComplexity")]
    public static class GeneComplexityPatch
    {
        static void Postfix(ref int __result)
        {
            __result = __result * MaxGeneComplexityMultiplier + MaxGeneComplexityOffset;
        }
    }

    [StaticConstructorOnStartup]
    [HarmonyPatch]
    public static class BioStat_Transpiler
    {
        static IEnumerable<MethodBase> TargetMethods()
        {
            yield return AccessTools.Method(typeof(BiostatsTable), "Draw");
            yield return AccessTools.Method(typeof(GeneCreationDialogBase), "WithinAcceptableBiostatLimits");
            yield return AccessTools.Method(typeof(Dialog_CreateXenotype), "GetWarnings");
            yield return AccessTools.Method(typeof(Xenogerm), "GetGizmos");
            yield return AccessTools.Method(typeof(Xenogerm), "<GetGizmos>b__15_0");
            yield return AccessTools.Method(typeof(Xenogerm), "GetFloatMenuOptions");
            yield return AccessTools.Inner(typeof(Xenogerm), "<GetFloatMenuOptions>d__14")
                .GetMethod("MoveNext", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            // foreach(MethodBase method in TargetMethods())
            // {
            //     Log.Warning(method.Name);
            // }

            var codes = new List<CodeInstruction>(instructions);
            var x = AccessTools.Method(typeof(IntRange), "get_TrueMin");

            foreach (var code in codes)
            {
                if (code.opcode == OpCodes.Call && code.operand == x)
                {
                    // Log.Warning("CodeInstruction: " + " opCode: " + code.opcode + " operand: " + code.operand);
                    code.operand = AccessTools.Method(typeof(MoreGeneComplexitySettings), "newBioStat_Min");
                    // Log.Warning("CodeInstruction: " + " opCode: " + code.opcode + " operand: " + code.operand);
                }

                yield return code;
            }
        }
    }
}