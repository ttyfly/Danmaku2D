using UnityEngine;
using XNode;

namespace AngleRD.Danmaku2D.Runtime {

    [CreateNodeMenu("Danmaku 2D/Math/Vector2 Math")]
    public class Vector2MathNode : Node {

        [Input(typeConstraint = TypeConstraint.Strict)] public Vector2 vectorA;
        [Input(typeConstraint = TypeConstraint.Strict)] public Vector2 vectorB;
        [Input(typeConstraint = TypeConstraint.Strict)] public float @float;

        [Output(typeConstraint = TypeConstraint.Strict)] public Vector2 output;

        public MathType mathType = MathType.Add;
        public enum MathType {
            Add, Subtract, ScalarMultiply, Multiply, ScalarDivide, Divide,
            Normalize, ClampMagnitude, Lerp, LerpUnclamped, MoveTowards,
            Max, Min, Rotate, AngleToVector, Reflect,
        }

        public override object GetValue(NodePort port) {
            Vector2 vectorA = GetInputValue<Vector2>("vectorA", this.vectorA);
            Vector2 vectorB = GetInputValue<Vector2>("vectorB", this.vectorB);
            float @float = GetInputValue<float>("float", this.@float);
            switch (mathType) {
                case MathType.Add: default:     return vectorA + vectorB;
                case MathType.Subtract:         return vectorA - vectorB;
                case MathType.ScalarMultiply:   return vectorA * @float;
                case MathType.Multiply:         return vectorA * vectorB;
                case MathType.ScalarDivide:     return vectorA / @float;
                case MathType.Divide:           return vectorA / vectorB;
                case MathType.Normalize:        return vectorA.normalized;
                case MathType.ClampMagnitude:   return Vector2.ClampMagnitude(vectorA, @float);
                case MathType.Lerp:             return Vector2.Lerp(vectorA, vectorB, @float);
                case MathType.LerpUnclamped:    return Vector2.LerpUnclamped(vectorA, vectorB, @float);
                case MathType.MoveTowards:      return Vector2.MoveTowards(vectorA, vectorB, @float);
                case MathType.Max:              return Vector2.Max(vectorA, vectorB);
                case MathType.Min:              return Vector2.Min(vectorA, vectorB);
                case MathType.Rotate:           return Quaternion.Euler(0, 0, @float) * vectorA;
                case MathType.AngleToVector:    return Quaternion.Euler(0, 0, @float) * Vector3.right;
                case MathType.Reflect:          return Vector2.Reflect(vectorA, vectorB);
            }
        }
    }

}