using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace AngleRD.Danmaku2D.Runtime {

    [CreateNodeMenu("Danmaku 2D/Type/Emitter Port")]
    public class EmitterPortNode : ProcessingNode<EmitterPort> {

        [Input(typeConstraint = TypeConstraint.Strict)] public Vector2 deltaPosition;
        [Input(typeConstraint = TypeConstraint.Strict)] public float rotation;
        [Input(typeConstraint = TypeConstraint.Strict)] public int emitCount;
        [Input(typeConstraint = TypeConstraint.Strict)] public float duration;

        protected override void Process() {
            output.deltaPosition = GetInputValue<Vector2>("deltaPosition", this.deltaPosition);
            output.rotation = GetInputValue<float>("rotation", this.rotation);
            output.emitCount = GetInputValue<int>("emitCount", this.emitCount);
            output.duration = GetInputValue<float>("duration", this.duration);
        }
    }

}