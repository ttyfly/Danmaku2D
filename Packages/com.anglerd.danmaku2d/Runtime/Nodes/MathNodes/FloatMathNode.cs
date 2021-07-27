using XNode;

namespace AngleRD.Danmaku2D.Runtime {

    [CreateNodeMenu("Danmaku 2D/Math/Float Math")]
    public class FloatMathNode : Node {

        [Input(typeConstraint = TypeConstraint.Strict)] public float a;
        [Input(typeConstraint = TypeConstraint.Strict)] public float b;

        public MathType mathType = MathType.Add;
        public enum MathType { Add, Subtract, Multiply, Divide }

        [Output(typeConstraint = TypeConstraint.Strict)] public float output;

        public override object GetValue(NodePort port) {
            float a = GetInputValue<float>("a", this.a);
            float b = GetInputValue<float>("b", this.b);
            switch (mathType) {
                case MathType.Add: default:     return a + b;
                case MathType.Subtract:         return a - b;
                case MathType.Multiply:         return a * b;
                case MathType.Divide:           return a / b;
            }
        }
    }

}