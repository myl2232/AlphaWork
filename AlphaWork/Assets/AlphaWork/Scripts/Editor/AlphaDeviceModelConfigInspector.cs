using UnityEditor;
using UnityEngine;

namespace AlphaWork.Editor
{
    [CustomEditor(typeof(AlphaDeviceModelConfig))]
    public class AlphaDeviceModelConfigInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Open Device Model Config Editor"))
            {
                AlphaDeviceModelConfigEditorWindow.OpenWindow((/*Texture2D*/AlphaDeviceModelConfig)target);
            }
        }
    }
}
