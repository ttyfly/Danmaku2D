using UnityEngine;
using XNode;

namespace AngleRD.Danmaku2D.Runtime {

    [CreateNodeMenu("Danmaku 2D/Type/Emitter Port")]
    public class EmitterPortNode : Node {

        [Input(typeConstraint = TypeConstraint.Strict)] public Vector2 deltaPosition;
        [Input(typeConstraint = TypeConstraint.Strict)] public float rotation;
        [Input(typeConstraint = TypeConstraint.Strict)] public float emitCount;
        [Input(typeConstraint = TypeConstraint.Strict)] public float duration;

        [Output(typeConstraint = TypeConstraint.Strict)] public EmitterPort output;

        public override object GetValue(NodePort port) => new EmitterPort {
            deltaPosition = GetInputValue<Vector2>("deltaPosition", this.deltaPosition),
            rotation = GetInputValue<float>("rotation", this.rotation),
            emitCount = (int)GetInputValue<float>("emitCount", this.emitCount),
            duration = GetInputValue<float>("duration", this.duration),
        };
    }

}