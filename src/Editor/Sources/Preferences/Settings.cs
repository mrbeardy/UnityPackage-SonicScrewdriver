using System;
using UnityEditor;
using UnityEngine;

namespace Beardy.SonicScrewdriver.Editor
{
    public static class Settings
    {
        public static bool CollapseInspectors
        {
            get { return EditorPrefs.GetBool("Beardy_SonicScrewdriver_CollapseInspectors", true); }
            set { EditorPrefs.SetBool("Beardy_SonicScrewdriver_CollapseInspectors", value); }
        }
    }
}