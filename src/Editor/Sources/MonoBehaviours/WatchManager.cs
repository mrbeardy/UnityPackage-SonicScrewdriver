using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Beardy.SonicScrewdriver.Runtime.Attributes;
using UnityEngine;

namespace Beardy.SonicScrewdriver.Editor.MonoBehaviours
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class WatchManager : MonoBehaviour
    {
        public Transform GroupContainer;
        
        private void Awake()    
        {
            name = $"[ {Constants.PackageTitle} : WatchManager ]";

            if (!Settings.DebugMode)
                gameObject.hideFlags = HideFlags.HideInHierarchy;

            var monoBehaviours = FindObjectsOfType<MonoBehaviour>();

            foreach (var monoBehaviour in monoBehaviours)
            {
                IEnumerable<FieldInfo> attrFields = Helpers.GetFieldsWithAttribute<WatchAttribute>(monoBehaviour);
                
                if (!attrFields.Any()) continue;
                
                WatchGroup watchGroup = Helpers.InstantiatePrefab<WatchGroup>("WatchGroup");
                watchGroup.transform.SetParent(GroupContainer, false);
                
                watchGroup.Init(monoBehaviour, attrFields);
            } 
        }
    }
}