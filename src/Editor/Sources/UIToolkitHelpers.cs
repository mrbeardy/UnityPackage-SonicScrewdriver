using UnityEditor;
using UnityEngine.UIElements;

namespace Beardy.SonicScrewdriver.Editor
{
    public static class UIToolkitHelpers
    {
        public static TemplateContainer CloneTemplateTree(string name)
        {
            return LoadTemplate(name).CloneTree();
        }
        
        public static VisualTreeAsset LoadTemplate(string name)
        {
            return AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(TemplatePath(name));
        }

        public static string TemplatePath(string name)
        {
            return $"{Constants.EditorUIPath}/{name}.uxml";
        }
    }
}