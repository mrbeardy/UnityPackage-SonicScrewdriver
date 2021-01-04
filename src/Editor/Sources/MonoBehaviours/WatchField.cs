using System.Reflection;
using TMPro;
using UnityEngine;

namespace Beardy.SonicScrewdriver.Editor.MonoBehaviours
{
    public class WatchField : MonoBehaviour
    {
        private MonoBehaviour _watchObject;
        private FieldInfo _fieldInfo;
        private TextMeshProUGUI textComponent;

        public void Init(MonoBehaviour watchObject, FieldInfo fieldInfo)
        {
            _watchObject = watchObject;
            _fieldInfo = fieldInfo;
        }

        private void Awake()
        {
            textComponent = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            if (!_watchObject || _fieldInfo == null) return;

            textComponent.text = $"{_fieldInfo.Name}: {_fieldInfo.GetValue(_watchObject)}";
        }
    }
}