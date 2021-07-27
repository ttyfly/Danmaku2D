using System;
using UnityEngine;

namespace AngleRD.Danmaku2D.Runtime {

    /// <summary>
    /// 发射端口类。
    /// </summary>
    [Serializable]
    public struct EmitterPort {

        /// <summary>
        /// 发射端口的相对位置。
        /// </summary>
        public Vector2 deltaPosition;

        /// <summary>
        /// 发射的方向。
        /// </summary>
        public float rotation;

        /// <summary>
        /// 发射子弹的数量，随时间增加。
        /// </summary>
        public int emitCount;

        /// <summary>
        /// 子弹的 duration 参数。
        /// </summary>
        public float duration;
    }

}