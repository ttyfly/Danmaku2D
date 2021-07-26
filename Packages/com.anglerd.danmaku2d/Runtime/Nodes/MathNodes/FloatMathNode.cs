namespace AngleRD.Danmaku2D.Runtime {

    [CreateNodeMenu("Danmaku 2D/Math/Float Math")]
    public class FloatMathNode : ProcessingNode<float> {

        [Input(typeConstraint = TypeConstraint.Strict)] public float a;
        [Input(typeConstraint = TypeConstraint.Strict)] public float b;

        public MathType mathType = MathType.Add;
        public enum MathType { Add, Subtract, Multiply, Divide }

        protected override void Process() {
            float a = GetInputValue<float>("a", this.a);
            float b = GetInputValue<float>("b", this.b);
            switch (mathType) {
                case MathType.Add: default: output = a + b; break;
                case MathType.Subtract: output = a - b; break;
                case MathType.Multiply: output = a * b; break;
                case MathType.Divide: output = a / b; break;
            }
        }
    }

}