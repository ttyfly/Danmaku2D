using UnityEngine;
using XNode;

namespace AngleRD.Danmaku2D.Runtime {

    [CreateNodeMenu("Danmaku 2D/Type/Emitter")]
    public class EmitterNode : Node {

        [Input(typeConstraint = TypeConstraint.Strict)] public EmitterPort emitterPorts;
        public Emitter.BulletType type;
        public GameObject bulletPrefab;
        public GameObject particleSystemPrefab;

        [Output(typeConstraint = TypeConstraint.Strict)] public Emitter output;

        public override object GetValue(NodePort port) => new Emitter {
            emitterPorts = GetInputValues<EmitterPort>("emitterPorts", this.emitterPorts),
            type = this.type,
            particleSystemPrefab = type == Emitter.BulletType.Particle ? this.particleSystemPrefab : null,
            bulletPrefab = type == Emitter.BulletType.Prefab ? this.bulletPrefab : null,
        };
    }

}