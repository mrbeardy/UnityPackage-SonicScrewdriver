using UnityEditor;
using UnityEngine.UIElements;

namespace Beardy.SonicScrewdriver.Editor
{
    public static class SettingsUIRegister
    {
        [SettingsProvider]
        public static SettingsProvider CreateSettingsProvider()
        {   
            var provider = new SettingsProvider($"Preferences/Beardy/{Constants.PackageTitle}", SettingsScope.User)
            {
                label = Constants.PackageTitle,
                activateHandler = (searchContext, rootElement) =>
                {   
                    rootElement.Add(UIToolkitHelpers.CloneTemplateTree("Preferences"));
                    rootElement.Query<Label>("Title").First().text = Constants.PackageTitle;
                    
                    // TODO: Replace these with binding
                    Toggle autoCollapseInspectors = rootElement.Query<Toggle>("autoCollapseInspectors");
                    autoCollapseInspectors.value = Settings.CollapseInspectors;
                    autoCollapseInspectors.RegisterCallback<ChangeEvent<bool>>((e) =>
                    {
                        Settings.CollapseInspectors = e.newValue;
                    });

                    Toggle debugMode = rootElement.Query<Toggle>("debugMode");
                    debugMode.value = Settings.CollapseInspectors;
                    debugMode.RegisterCallback<ChangeEvent<bool>>((e) =>
                    {
                        Settings.DebugMode = e.newValue;
                    });
                }
            };

            return provider;
        }
    }
}