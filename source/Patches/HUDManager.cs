using CruiserImproved.Network;
using HarmonyLib;

namespace CruiserImproved.Patches;

[HarmonyPatch(typeof(HUDManager))]
internal class HUDManagerPatches
{
    [HarmonyPatch("CanPlayerScan")]
    [HarmonyPostfix]
    static void CanPlayerScan_Postfix(ref bool __result)
    {
        if (!NetworkSync.Config.ScanWhileSeated || __result) return;

        //override to allow scan while seated
        if (GameNetworkManager.Instance.localPlayerController.inVehicleAnimation && !GameNetworkManager.Instance.localPlayerController.isPlayerDead)
            __result = true;
    }
}
