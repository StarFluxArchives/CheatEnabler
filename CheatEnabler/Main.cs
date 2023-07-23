using WalrusLib;
using BepInEx;
using System.Reflection;
using UnityEngine;
using static PlayerCheats;

namespace CheatEnabler
{
	[BepInPlugin(MOD_ID, MOD_NAME, MOD_VERSION)]
	public class Main : BaseMod
	{
		public const string MOD_ID = "starfluxgames.cheatenabler";
		public const string MOD_NAME = "Cheat Enabler";
		public const string MOD_VERSION = "0.1.0";
		public const string MOD_BETA_VERSION = "";

		public Main() : base(MOD_ID, MOD_NAME, MOD_VERSION, MOD_BETA_VERSION, Assembly.GetExecutingAssembly()) { }

		void Awake()
		{
			RegisterMenu<CheatMenu>();
		}
	}
}