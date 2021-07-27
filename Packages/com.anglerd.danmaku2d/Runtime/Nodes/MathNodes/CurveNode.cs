using UnityEngine;
using XNode;

namespace AngleRD.Danmaku2D.Runtime {

    [CreateNodeMenu("Danmaku 2D/Math/Curve")]
    public class CurveNode : Node {

        [Input(typeConstraint = TypeConstraint.Strict)] public float input;
        public AnimationCurve curve;

        [Output(typeConstraint = TypeConstraint.Strict)] public float output;

        public override object GetValue(NodePort port) {
            float input = GetInputValue<float>("input", this.input);
            return curve.Evaluate(input);
        }
    }
}