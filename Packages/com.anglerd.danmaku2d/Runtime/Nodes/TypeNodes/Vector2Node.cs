using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using XNode;

namespace AngleRD.Danmaku2D.Runtime {

    [CreateNodeMenu("Danmaku 2D/Type/Vector2")]
    public class Vector2Node : ProcessingNode<Vector2> {

        [Input(typeConstraint = TypeConstraint.Strict)] public float x;
        [Input(typeConstraint = TypeConstraint.Strict)] public float y;

        protected override void Process() {
            output.x = GetInputValue<float>("x", this.x);
            output.y = GetInputValue<float>("y", this.y);
        }
    }

}