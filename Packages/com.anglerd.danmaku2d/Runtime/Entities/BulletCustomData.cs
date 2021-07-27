using System;
using UnityEngine;

namespace AngleRD.Danmaku2D.Runtime {

    /// <summary>
    /// 自定义数据，用于在子弹粒子的不同帧之间传递数据。
    /// </summary>
    [Serializable]
    public struct BulletCustomData {

        public Vector2 vector1;
        public Vector2 vector2;
        public float float1;
        public float float2;
        public float float3;
        public float float4;
    }

}