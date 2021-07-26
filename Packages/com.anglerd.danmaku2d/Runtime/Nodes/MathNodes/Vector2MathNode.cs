using UnityEngine;

namespace AngleRD.Danmaku2D.Runtime {

    [CreateNodeMenu("Danmaku 2D/Math/Vector2 Math")]
    public class Vector2MathNode : ProcessingNode<Vector2> {

        [Input(typeConstraint = TypeConstraint.Strict)] public Vector2 vectorA;
        [Input(typeConstraint = TypeConstraint.Strict)] public Vector2 vectorB;
        [Input(typeConstraint = TypeConstraint.Strict)] public float @float;

        public MathType mathType = MathType.Add;
        public enum MathType {
            Add, Subtract, ScalarMultiply, Multiply, ScalarDivide, Divide,
            Normalize, ClampMagnitude, Lerp, LerpUnclamped, MoveTowards,
            Max, Min, Rotate, AngleToVector, Reflect,
        }

        protected override void Process() {
            Vector2 vectorA = GetInputValue<Vector2>("vectorA", this.vectorA);
            Vector2 vectorB = GetInputValue<Vector2>("vectorB", this.vectorB);
            float @float = GetInputValue<float>("float", this.@float);
            switch (mathType) {
                case MathType.Add: default:     output = vectorA + vectorB; break;
                case MathType.Subtract:         output = vectorA - vectorB; break;
                case MathType.ScalarMultiply:   output = vectorA * @float; break;
                case MathType.Multiply:         output = vectorA * vectorB; break;
                case MathType.ScalarDivide:     output = vectorA / @float; break;
                case MathType.Divide:           output = vectorA / vectorB; break;
                case MathType.Normalize:        output = vectorA.normalized; break;
                case MathType.ClampMagnitude:   output = Vector2.ClampMagnitude(vectorA, @float); break;
                case MathType.Lerp:             output = Vector2.Lerp(vectorA, vectorB, @float); break;
                case MathType.LerpUnclamped:    output = Vector2.LerpUnclamped(vectorA, vectorB, @float); break;
                case MathType.MoveTowards:      output = Vector2.MoveTowards(vectorA, vectorB, @float); break;
                case MathType.Max:              output = Vector2.Max(vectorA, vectorB); break;
                case MathType.Min:              output = Vector2.Min(vectorA, vectorB); break;
                case MathType.Rotate:           output = Quaternion.Euler(0, 0, @float) * vectorA; break;
                case MathType.AngleToVector:    output = Quaternion.Euler(0, 0, @float) * Vector3.right; break;
                case MathType.Reflect:          output = Vector2.Reflect(vectorA, vectorB); break;
            }
        }
    }

}