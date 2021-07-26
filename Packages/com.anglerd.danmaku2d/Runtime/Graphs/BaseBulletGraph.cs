using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using XNode;

namespace AngleRD.Danmaku2D.Runtime {
    public class BaseBulletGraph<T> : ProgressGraph<T> where T: BaseBullet {}
}