using XNode;

namespace AngleRD.Danmaku2D.Runtime {

    public class ProgressGraph<T> : NodeGraph {

        public OutputNode<T> outputNode;
        public ProgressNode progressNode;
        public bool hasInput = true;

        public T GetOutput(float progress) {
            if (hasInput && progressNode == null) {
                int progressNodeCount = 0;
                foreach (Node node in nodes) {
                    if (node is ProgressNode) {
                        progressNode = node as ProgressNode;
                        progressNodeCount++;
                    }
                }
                if (progressNodeCount == 0) {
                    hasInput = false;
                } else if (progressNodeCount > 1) {
                    throw new System.Exception("Danmaku 2D: Progress Graph 中应仅有一个 Progress 节点");
                }
            }

            if (outputNode == null) {
                int outputNodeCount = 0;
                foreach (Node node in nodes) {
                    if (node is OutputNode<T>) {
                        outputNode = node as OutputNode<T>;
                        outputNodeCount++;
                    }
                }
                if (outputNodeCount != 1) {
                    throw new System.Exception("Danmaku 2D: Progress Graph 中应有且仅有一个正确类型的输出节点");
                }
            }

            if (hasInput) progressNode.SetInput(progress);

            return (T)outputNode.GetOutputPort("output").GetOutputValue();
        }
    }
}