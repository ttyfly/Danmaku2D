using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace AngleRD.Danmaku2D.Runtime {

    [CreateNodeMenu("Danmaku 2D/Type/Float To Int")]
    public class Float2IntNode : ProcessingNode<int> {

        [Input(typeConstraint = TypeConstraint.Strict)] public float input;

        protected override void Process() {
            output = (int)GetInputValue<float>("input", this.input);
        }
    }

}