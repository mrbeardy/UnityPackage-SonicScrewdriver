using UnityEditor;

namespace Beardy.SonicScrewdriver.Editor.Features
{
    [InitializeOnLoad]
    public static class AutoCollapseInspectors
    {
        static AutoCollapseInspectors()
        {
            Selection.selectionChanged += CollapseInspectors;
        }

        private static void CollapseInspectors()
        {
            if (!Settings.CollapseInspectors) return;
            
            var activeEditorTracker = ActiveEditorTracker.sharedTracker;
 
            // We start at index 2 to avoid collapsing the info and transform panels
            for (int i = 2; i < activeEditorTracker.activeEditors.Length; i++)
                activeEditorTracker.SetVisible(i, visible: 0);
        }
    }
}