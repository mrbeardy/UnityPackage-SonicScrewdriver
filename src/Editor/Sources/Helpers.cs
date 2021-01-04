using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Beardy.SonicScrewdriver.Runtime.Attributes;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Beardy.SonicScrewdriver.Editor
{
    public static class Helpers
    {
        public static GameObject InstantiatePrefab(string name)
        {
            return InstantiatePrefab<GameObject>(name);
        }
        
        public static T InstantiatePrefab<T>(string name) where T : Object
        {
            return PrefabUtility.InstantiatePrefab(LoadPrefab<T>(name)) as T;
        }
        
        public static T LoadPrefab<T>(string name) where T : Object
        {
            return LoadResource<T>($"Prefabs/{name}.prefab");
        }

        public static T LoadResource<T>(string name) where T : Object
        {
            return AssetDatabase.LoadAssetAtPath<T>($"{Constants.EditorResourcesPath}/{name}");
        }
        
        public static IEnumerable<FieldInfo> GetFieldsWithAttribute<T>(
            Object obj, 
            BindingFlags bindingAttr = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance
        ) where T : Attribute
        {
            return obj.GetType().GetFields(bindingAttr).Where(field => field.IsDefined(typeof(T), false));    
        }
    }
}