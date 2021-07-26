using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace AngleRD.Danmaku2D.Runtime {

    [CreateNodeMenu("Danmaku 2D/Type/Emitter")]
    public class EmitterNode : ProcessingNode<Emitter> {

        [Input(typeConstraint = TypeConstraint.Strict)] public EmitterPort emitterPorts;
        public Emitter.BulletType type;
        public GameObject bulletPrefab;
        public GameObject particleSystemPrefab;

        protected override void Process() {
            output.emitterPorts = GetInputValues<EmitterPort>("emitterPorts", this.emitterPorts);
            output.type = this.type;
            if (type == Emitter.BulletType.Particle) {
                output.particleSystemPrefab = this.particleSystemPrefab;
                output.bulletPrefab = null;
            } else if (type == Emitter.BulletType.Prefab) {
                output.bulletPrefab = this.bulletPrefab;
                output.particleSystemPrefab = null;
            }
        }
    }

}