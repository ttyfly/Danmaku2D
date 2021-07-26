using UnityEditor;
using XNodeEditor;
using AngleRD.Danmaku2D.Runtime;

namespace AngleRD.Danmaku2D.Editor {
    
    [CustomNodeEditor(typeof(Vector2MathNode))]
    public class Vector2MathNodeEditor : NodeEditor {

        private Vector2MathNode node;

        public override void OnBodyGUI() {
            if (node == null) node = target as Vector2MathNode;

            // Update serialized object's representation
            serializedObject.Update();

            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("mathType"));

            switch (node.mathType) {
                case Vector2MathNode.MathType.Normalize:
                    NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("vectorA"));
                    break;
                case Vector2MathNode.MathType.AngleToVector:
                    NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("float"));
                    break;
                case Vector2MathNode.MathType.Add:
                case Vector2MathNode.MathType.Subtract:
                case Vector2MathNode.MathType.Multiply:
                case Vector2MathNode.MathType.Divide:
                case Vector2MathNode.MathType.Max:
                case Vector2MathNode.MathType.Min:
                case Vector2MathNode.MathType.Reflect:
                default:
                    NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("vectorA"));
                    NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("vectorB"));
                    break;
                case Vector2MathNode.MathType.ScalarMultiply:
                case Vector2MathNode.MathType.ScalarDivide:
                case Vector2MathNode.MathType.ClampMagnitude:
                case Vector2MathNode.MathType.Rotate:
                    NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("vectorA"));
                    NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("float"));
                    break;
                case Vector2MathNode.MathType.Lerp:
                case Vector2MathNode.MathType.LerpUnclamped:
                case Vector2MathNode.MathType.MoveTowards:
                    NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("vectorA"));
                    NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("vectorB"));
                    NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("float"));
                    break;
            }

            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("output"));

            // Apply property modifications
            serializedObject.ApplyModifiedProperties();
        }
    }

}