using UnityEngine;
using XNode;

namespace AngleRD.Danmaku2D.Runtime {

    [CreateNodeMenu("Danmaku 2D/Type/Vector2")]
    public class Vector2Node : Node {

        [Input(typeConstraint = TypeConstraint.Strict)] public float x;
        [Input(typeConstraint = TypeConstraint.Strict)] public float y;

        [Output(typeConstraint = TypeConstraint.Strict)] public Vector2 output;

        public override object GetValue(NodePort port) => new Vector2 {
            x = GetInputValue<float>("x", this.x),
            y = GetInputValue<float>("y", this.y),
        };
    }

}