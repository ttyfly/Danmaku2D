using System;
using UnityEngine;

namespace AngleRD.Danmaku2D.Runtime {

    /// <summary>
    /// 发射器类。一个发射器仅发射一种类型的子弹。
    /// </summary>
    [Serializable]
    public class Emitter {

        /// <summary>
        /// 发射端口。
        /// </summary>
        public EmitterPort[] emitterPorts;

        /// <summary>
        /// 子弹的类型（粒子/预制体）。
        /// </summary>
        public BulletType type;

        /// <summary>
        /// 粒子系统的预制体，只有在 type 为 Particle 时有效。
        /// </summary>
        public GameObject particleSystemPrefab;

        /// <summary>
        /// 子弹预制体，只有在 type 为 Prefab 时有效。
        /// </summary>
        public GameObject bulletPrefab;


        /// <summary>
        /// 子弹类型枚举。
        /// </summary>
        public enum BulletType {
            /// <summary>
            /// 粒子（性能开销小，但是只有圆形判定点）。
            /// </summary>
            Particle,

            /// <summary>
            /// 预制体（可高度自定义，但是性能开销较大）。
            /// </summary>
            Prefab,
        };
    }

}