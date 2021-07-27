using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace AngleRD.Danmaku2D.Runtime {

    [CreateNodeMenu("Danmaku 2D/Output/Prefab Bullet")]
    [DisallowMultipleNodes]
    public class PrefabBulletNode : OutputNode<PrefabBullet> {

        [Input(typeConstraint = TypeConstraint.Strict)] public Vector2 velocity;
        [Input(typeConstraint = TypeConstraint.Strict)] public float rotation;
        [Input(typeConstraint = TypeConstraint.Strict)] public Emitter attachedEmitters;

        public override PrefabBullet GetOutput() => new PrefabBullet {
            velocity = GetInputValue<Vector2>("velocity", this.velocity),
            rotation = GetInputValue<float>("rotation", this.rotation),
            attachedEmitters = GetInputValues<Emitter>("attachedEmitters"),
        };
    }

}