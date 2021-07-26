using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using XNode;

namespace AngleRD.Danmaku2D.Runtime {

    [CreateNodeMenu("")]
    public class OutputNode<T> : Node {

        [Output] [HideInInspector] public T output;
        protected virtual void Process() {}

        public override object GetValue(NodePort port) {
            Process();
            return output;
        }
    }
}