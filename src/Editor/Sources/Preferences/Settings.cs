using System;
using UnityEditor;
using UnityEngine;

namespace Beardy.SonicScrewdriver.Editor
{
    public static class Settings
    {
        public static bool CollapseInspectors
        {
            get { return EditorPrefs.GetBool(PrefName("CollapseInspectors"), true); }
            set { EditorPrefs.SetBool(PrefName("CollapseInspectors"), value); }
        }

        public static bool DebugMode
        {
            get { return EditorPrefs.GetBool(PrefName("DebugMode"), false); }
            set { EditorPrefs.SetBool(PrefName("DebugMode"), value); }
        }

        private static string PrefName(string settingName)
        {
            return $"Beardy_SonicScrewdriver_{settingName}";
        }
    }
}