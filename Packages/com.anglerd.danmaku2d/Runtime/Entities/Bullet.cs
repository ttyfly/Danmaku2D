using System;
using UnityEngine;

namespace AngleRD.Danmaku2D.Runtime {

    /// <summary>
    /// 子弹基类。
    /// </summary>
    [Serializable]
    public class BaseBullet {

        /// <summary>
        /// 子弹速度。
        /// </summary>
        public Vector2 velocity;

        /// <summary>
        /// 子弹旋转角度。
        /// </summary>
        public float rotation;
    }

    /// <summary>
    /// 粒子类型的子弹。
    /// </summary>
    [Serializable]
    public class ParticleBullet : BaseBullet {
        
    }

    /// <summary>
    /// 预制件类型的子弹。
    /// </summary>
    [Serializable]
    public class PrefabBullet : BaseBullet {

        /// <summary>
        /// 子弹上的发射器。
        /// </summary>
        public Emitter[] attachedEmitters;
    }
}