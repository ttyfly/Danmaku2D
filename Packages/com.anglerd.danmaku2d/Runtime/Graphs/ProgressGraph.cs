using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using XNode;

namespace AngleRD.Danmaku2D.Runtime {

    public class ProgressGraph<T> : NodeGraph {

        public OutputNode<T> outputNode;

        public T GetOutput(float progress) {

            int outputNodeCount = 0;

            if (outputNode == null) {
                foreach (Node node in nodes) {
                    if (node is OutputNode<T>) {
                        outputNode = node as OutputNode<T>;
                        outputNodeCount++;
                    }
                }
                if (outputNodeCount != 1) {
                    throw new System.Exception("Danmaku 2D: Progress Graph 中需有且仅有一个正确类型的输出节点");
                }
            }

            foreach (Node node in nodes) {
                if (node is ProgressNode pNode) {
                    pNode.progress = progress;
                }
            }

            return (T)outputNode.GetOutputPort("output").GetOutputValue();
        }
    }
}