using WalrusLib;
using BepInEx;
using System.Reflection;
using WalrusLib.UI.IMGUI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static PlayerCheats;
using System.Linq;
using HarmonyLib;

namespace CheatEnabler
{
	public class CheatMenu : BaseUI
	{
		private PlayerCheats Cheats;
		private string SelectedEnum = "";
		private static Vector2 scrollPosition;

		public CheatMenu()
		{
			ButtonName = "Cheats";
		}

		public override void OnInit()
		{
		}
		public override void Setup()
		{
			if (Cheats == null)
			{
				GameObject cheatHolder = GameObject.Find("Player Cheats");
				if (cheatHolder != null )
				{
					Cheats = cheatHolder.GetComponent<PlayerCheats>();
				}
			}

			if (Cheats == null )
			{
				GUILayout.Label("Could not find cheats");
				return;
			}

			BoolOption("showMultiplayerDebugInfo", ref Cheats.showMultiplayerDebugInfo, 0);
			BoolOption("infiniteCrafting", ref Cheats.infiniteCrafting, 30);
			BoolOption("hideMachineLights", ref Cheats.hideMachineLights, 60);
			BoolOption("hideMachineParticles", ref Cheats.hideMachineParticles, 90);
			BoolOption("ultraPickaxe", ref Cheats.ultraPickaxe, 120);
			BoolOption("disableStreamedGpuiProps", ref Cheats.disableStreamedGpuiProps, 150);
			BoolOption("disableStreamedRenderers", ref Cheats.disableStreamedRenderers, 180);
			BoolOption("disableStreamedLights", ref Cheats.disableStreamedLights, 210);
			BoolOption("disableStreamedColliders", ref Cheats.disableStreamedColliders, 240);
			BoolOption("disableProductionTerminalDeco", ref Cheats.disableProductionTerminalDeco, 270);
			BoolOption("disableFacilityStaticObjects", ref Cheats.disableFacilityStaticObjects, 300);
			BoolOption("disableWaterfalls", ref Cheats.disableWaterfalls, 330);
			BoolOption("disableWater", ref Cheats.disableWater, 360);
			BoolOption("disableVoxelandVisibilityChange", ref Cheats.disableVoxelandVisibilityChange, 390);
			BoolOption("maxPower", ref Cheats.maxPower, 420);
			BoolOption("showDebugCoords", ref Cheats.showDebugCoords, 450);
			BoolOption("fasterMole", ref Cheats.fasterMole, 480);
			BoolOption("useLookInputSmoothing", ref Cheats.useLookInputSmoothing, 510);

			EnumOption("machineVisualsUpdateMode", 0);
			EnumOption("disableVoxelandVisibility", 30);
			EnumOption("disableScrollRects", 60);
			EnumOption("freeCameraMode", 90);
			
			
			GUILayout.BeginArea(new Rect(570, 0, 180, 115));
			scrollPosition = GUILayout.BeginScrollView(scrollPosition, false, false, GUIStyle.none, GUI.skin.verticalScrollbar);
			if (SelectedEnum == "machineVisualsUpdateMode")
			{
				if (GUILayout.Button("Normal"))
					Cheats.machineVisualsUpdateMode = MachineVisualsUpdateMode.Normal;
				if (GUILayout.Button("NoGPUI"))
					Cheats.machineVisualsUpdateMode = MachineVisualsUpdateMode.NoGPUI;
				if (GUILayout.Button("NoVisualsUpdates"))
					Cheats.machineVisualsUpdateMode = MachineVisualsUpdateMode.NoVisualsUpdates;
				if (GUILayout.Button("ForceStaticUpdates"))
					Cheats.machineVisualsUpdateMode = MachineVisualsUpdateMode.ForceStaticUpdates;
				if (GUILayout.Button("MAX_NUM_MODES"))
					Cheats.machineVisualsUpdateMode = MachineVisualsUpdateMode.MAX_NUM_MODES;
			}
			else if (SelectedEnum == "disableVoxelandVisibility")
			{
				if (GUILayout.Button("Normal"))
					Cheats.disableVoxelandVisibility = VoxelandVisibilityMode.Normal;
				if (GUILayout.Button("UseOcclusionAndFrustrumCulling"))
					Cheats.disableVoxelandVisibility = VoxelandVisibilityMode.UseOcclusionAndFrustrumCulling;
				if (GUILayout.Button("HideAllChunks"))
					Cheats.disableVoxelandVisibility = VoxelandVisibilityMode.HideAllChunks;
				if (GUILayout.Button("MAX_NUM_MODES"))
					Cheats.disableVoxelandVisibility = VoxelandVisibilityMode.MAX_NUM_MODES;
			}
			else if (SelectedEnum == "disableScrollRects")
			{
				if (GUILayout.Button("Normal"))
					Cheats.disableScrollRects = ScrollRectMode.Normal;
				if (GUILayout.Button("DisableAll"))
					Cheats.disableScrollRects = ScrollRectMode.DisableAll;
				if (GUILayout.Button("MAX_NUM_MODES"))
					Cheats.disableScrollRects = ScrollRectMode.MAX_NUM_MODES;
			}
			else if (SelectedEnum == "freeCameraMode")
			{
				if (GUILayout.Button("Normal"))
					Cheats.freeCameraMode = FreeCameraMode.Normal;
				if (GUILayout.Button("Free"))
					Cheats.freeCameraMode = FreeCameraMode.Free;
				if (GUILayout.Button("ScriptedAnimation"))
					Cheats.freeCameraMode = FreeCameraMode.ScriptedAnimation;
			}
			GUILayout.EndScrollView();
			GUILayout.EndArea();

			GUILayout.BeginArea(new Rect(380, 120, 180, 25));
			GUILayout.Label("simSpeed : " + Cheats.simSpeed);
			GUILayout.EndArea();

			GUILayout.BeginArea(new Rect(380, 150, 370, 25));
			Cheats.simSpeed = (int)GUILayout.HorizontalSlider(Cheats.simSpeed, 0, 50);
			GUILayout.EndArea();

		}

		public override void Disable()
		{
		}

		private void BoolOption(string optionName, ref bool option, int y)
		{
			GUILayout.BeginArea(new Rect(0, y, 180, 25));
			GUILayout.Label(optionName + ": ");
			GUILayout.EndArea();

			GUILayout.BeginArea(new Rect(190, y, 180, 25));
			option = GUILayout.Toggle(option, "");
			GUILayout.EndArea();
		}

		private void EnumOption(string optionName, int y)
		{
			GUILayout.BeginArea(new Rect(380, y, 180, 25));
			if (GUILayout.Button(optionName))
			{
				SelectedEnum = optionName;
			}
			GUILayout.EndArea();
		}
	}
}