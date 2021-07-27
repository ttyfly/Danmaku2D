using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using XNode;

namespace AngleRD.Danmaku2D.Runtime {

    [CreateNodeMenu("")]
    public class InputNode<T> : Node {

        [Output(typeConstraint = TypeConstraint.Inherited)] public T output;

        protected T input;

        public override object GetValue(NodePort port) {
            return input;
        }

        public void SetInput(T inputValue) {
            input = inputValue;
        }
    }
}