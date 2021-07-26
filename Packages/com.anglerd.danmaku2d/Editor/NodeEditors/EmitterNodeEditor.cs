using UnityEditor;
using XNodeEditor;
using AngleRD.Danmaku2D.Runtime;

namespace AngleRD.Danmaku2D.Editor {
    
    [CustomNodeEditor(typeof(EmitterNode))]
    public class EmitterNodeEditor : NodeEditor {

        private EmitterNode emitterNode;

        public override void OnBodyGUI() {
            if (emitterNode == null) emitterNode = target as EmitterNode;

            // Update serialized object's representation
            serializedObject.Update();

            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("emitterPorts"));

            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("type"));

            if (emitterNode.type == Emitter.BulletType.Particle) {
                NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("particleSystemPrefab"));
            } else if (emitterNode.type == Emitter.BulletType.Prefab) {
                NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("bulletPrefab"));
            }

            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("output"));

            // Apply property modifications
            serializedObject.ApplyModifiedProperties();
        }
    }

}