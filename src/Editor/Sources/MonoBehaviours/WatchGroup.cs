using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Beardy.SonicScrewdriver.Editor;
using Beardy.SonicScrewdriver.Editor.MonoBehaviours;
using TMPro;
using UnityEngine;

public class WatchGroup : MonoBehaviour
{
    public TextMeshProUGUI Header;
    public GameObject WatchFieldsContainer;

    public void Init(MonoBehaviour watchMonoBehaviour, IEnumerable<FieldInfo> watchFields)
    {
        Header.text = watchMonoBehaviour.name;
        
        foreach (var watchField in watchFields)
        {
            WatchField watchFieldGameObject = Helpers.InstantiatePrefab<WatchField>("WatchField");
            watchFieldGameObject.transform.SetParent(WatchFieldsContainer.transform, false);
            
            watchFieldGameObject.Init(watchMonoBehaviour, watchField);
        } 
    }
}
