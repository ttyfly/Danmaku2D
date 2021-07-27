using UnityEngine;

namespace AngleRD.Danmaku2D.Runtime {

    [CreateNodeMenu("Danmaku 2D/Output/Particle Bullet")]
    [DisallowMultipleNodes]
    public class ParticleBulletNode : OutputNode<ParticleBullet> {

        [Input(typeConstraint = TypeConstraint.Strict)] public Vector2 velocity;
        [Input(typeConstraint = TypeConstraint.Strict)] public float rotation;
        [Input(typeConstraint = TypeConstraint.Strict)] public BulletCustomData customData;

        public override ParticleBullet GetOutput() => new ParticleBullet {
            velocity = GetInputValue<Vector2>("velocity", this.velocity),
            rotation = GetInputValue<float>("rotation", this.rotation),
            customData = GetInputValue<BulletCustomData>("customData", this.customData),
        };
    }

}