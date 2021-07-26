using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace AngleRD.Danmaku2D.Runtime {

    [CreateNodeMenu("Danmaku 2D/Math/Curve")]
    public class CurveNode : ProcessingNode<float> {

        [Input(typeConstraint = TypeConstraint.Strict)] public float input;
        public AnimationCurve curve;

        protected override void Process() {
            float input = GetInputValue<float>("input", this.input);
            output = curve.Evaluate(input);
        }
    }
}