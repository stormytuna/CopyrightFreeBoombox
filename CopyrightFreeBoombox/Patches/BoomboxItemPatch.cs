using System.Linq;
using HarmonyLib;
using UnityEngine;

namespace CopyrightFreeBoombox.Patches
{
	[HarmonyPatch(typeof(BoomboxItem))]
	public class BoomboxItemPatch
	{
		private static bool IsNotCopyrighted(AudioClip audioClip) {
			switch (audioClip.name) {
				case "BoomboxMusic1": return true;
				case "BoomboxMusic2": return true;
				case "BoomboxMusic3": return true;
				case "BoomboxMusic4": return true;
				default: return false;
			}
		}

		[HarmonyPrefix]
		[HarmonyPatch(nameof(BoomboxItem.StartMusic))]
		public static void RemoveCopyrightedMusic(ref AudioClip[] ___musicAudios) {
			if (___musicAudios is null) {
				CopyrightFreeBoomboxBase.Log.LogError("Failed to patch out copyrighted music!!");
				return;
			}

			CopyrightFreeBoomboxBase.Log.LogInfo("BEFORE");
			foreach (AudioClip music in ___musicAudios) {
				CopyrightFreeBoomboxBase.Log.LogInfo(music.name);
			}

			___musicAudios = ___musicAudios.Where(IsNotCopyrighted).ToArray();

			CopyrightFreeBoomboxBase.Log.LogInfo("AFTER");
			foreach (AudioClip music in ___musicAudios) {
				CopyrightFreeBoomboxBase.Log.LogInfo(music.name);
			}
		}
	}
}
