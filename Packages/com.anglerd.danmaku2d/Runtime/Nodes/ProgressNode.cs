namespace AngleRD.Danmaku2D.Runtime {

    [CreateNodeMenu("Danmaku 2D/Input/Progress")]
    public class ProgressNode : ProcessingNode<float> {

        public float progress;

        protected override void Process() {
            output = progress;
        }
    }

}