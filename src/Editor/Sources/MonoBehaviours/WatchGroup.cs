using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Beardy.SonicScrewdriver.Editor;
using Beardy.SonicScrewdriver.Editor.MonoBehaviours;
using Beardy.SonicScrewdriver.Runtime.Attributes;
using TMPro;
using UnityEditor;
using UnityEngine;

public class WatchGroup : MonoBehaviour
{
    public TextMeshProUGUI Header;
    public GameObject WatchFieldsContainer;

    private Canvas _canvas;
    private GameObject _watchGameObject;
    private WatchPlayer _watchPlayer;
    private RectTransform _rectTransform;

    public void Init(
        MonoBehaviour watchMonoBehaviour,
        IEnumerable<FieldInfo> watchFields,
        WatchOptionsAttribute.DisplayType displayType
    )
    {
        _watchGameObject = watchMonoBehaviour.gameObject;
        _watchPlayer = FindObjectOfType<WatchPlayer>();
        _rectTransform = GetComponent<RectTransform>();
        Header.text = watchMonoBehaviour.name;

        if (displayType == WatchOptionsAttribute.DisplayType.WorldSpace)
        {
            // TODO: Move this into a separate Prefab, and instantiate the WorldSpace prefab from WatchManager.
            GameObject container = new GameObject();
            _canvas = container.AddComponent<Canvas>();
            _canvas.renderMode = RenderMode.WorldSpace;
            _canvas.transform.position = _watchGameObject.transform.position;

            // TODO: Expose this scaling to the user, to allow them to control how the UI should look when using
            //       WorldSpace display.
            _canvas.transform.localScale = new Vector3(-0.005f, 0.005f, 1);

            _rectTransform.anchorMax = new Vector2(0.5f, 0);
            _rectTransform.anchorMin = new Vector2(0.5f, 0);
            _rectTransform.pivot = new Vector2(0.5f, 0);

            transform.SetParent(container.transform, false);
        }
        
        foreach (var watchField in watchFields)
        {
            WatchField watchFieldGameObject = Helpers.InstantiatePrefab<WatchField>("WatchField");
            watchFieldGameObject.transform.SetParent(WatchFieldsContainer.transform, false);

            watchFieldGameObject.Init(watchMonoBehaviour, watchField);
        } 
    }

    private void Update()
    {
        if (!_watchPlayer || !_canvas || _canvas.renderMode != RenderMode.WorldSpace) return;

        _canvas.transform.rotation = Quaternion.LookRotation(_watchPlayer.playerCamera.transform.position - transform.position);

        _canvas.transform.position = _watchGameObject.transform.position;
    }
}
