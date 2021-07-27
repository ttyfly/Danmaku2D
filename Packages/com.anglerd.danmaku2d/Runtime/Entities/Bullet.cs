using System;
using UnityEngine;

namespace AngleRD.Danmaku2D.Runtime {

    /// <summary>
    /// 粒子类型的子弹。
    /// </summary>
    [Serializable]
    public struct ParticleBullet {

        /// <summary>
        /// 子弹速度。
        /// </summary>
        public Vector2 velocity;

        /// <summary>
        /// 子弹旋转角度。
        /// </summary>
        public float rotation;

        /// <summary>
        /// 自定义数据。
        /// </summary>
        public BulletCustomData customData;
    }

    /// <summary>
    /// 预制件类型的子弹。
    /// </summary>
    [Serializable]
    public struct PrefabBullet {

        /// <summary>
        /// 子弹速度。
        /// </summary>
        public Vector2 velocity;

        /// <summary>
        /// 子弹旋转角度。
        /// </summary>
        public float rotation;

        /// <summary>
        /// 子弹上的发射器。
        /// </summary>
        public Emitter[] attachedEmitters;
    }
}