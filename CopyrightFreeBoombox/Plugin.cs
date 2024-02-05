using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace CopyrightFreeBoombox
{
	[BepInPlugin(ModGUID, ModName, ModVersion)]
	public class CopyrightFreeBoomboxBase : BaseUnityPlugin
	{
		public const string ModGUID = "stormytuna.CopyrightFreeBoombox";
		public const string ModName = "CopyrightFreeBoombox";
		public const string ModVersion = "1.0.0";

		public static ManualLogSource Log = BepInEx.Logging.Logger.CreateLogSource(ModGUID);
		public static CopyrightFreeBoomboxBase Instance;

		private readonly Harmony harmony = new Harmony(ModGUID);

		private void Awake() {
			if (Instance is null) {
				Instance = this;
			}

			Log.LogInfo("Copyright Free Boombox has awoken!");

			harmony.PatchAll();
		}
	}
}
