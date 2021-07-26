using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace AngleRD.Danmaku2D.Runtime {

    [CreateNodeMenu("Danmaku 2D/Output/Particle Bullet")]
    [DisallowMultipleNodes]
    public class ParticleBulletNode : OutputNode<ParticleBullet> {

        [Input(typeConstraint = TypeConstraint.Strict)] public Vector2 velocity;
        [Input(typeConstraint = TypeConstraint.Strict)] public float rotation;

        protected override void Process() {
            output.velocity = GetInputValue<Vector2>("velocity", this.velocity);
            output.rotation = GetInputValue<float>("rotation", this.rotation);
        }
    }

}