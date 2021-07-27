using UnityEngine;
using XNode;

namespace AngleRD.Danmaku2D.Runtime {

    [CreateAssetMenu(menuName = "Danmaku 2D/Particle Bullet Graph", fileName = "NewParticleBullet")]
    public class ParticleBulletGraph : ProgressGraph<ParticleBullet> {

        public CustomDataNode customDataNode;
        public bool hasCustomData = true;

        public EmitCountNode emitCountNode;
        public bool hasEmitCountNode = true;

        public void SetCustomData(BulletCustomData customData) {
            if (hasCustomData && customDataNode == null) {
                int nodeCount = 0;
                foreach (Node node in nodes) {
                    if (node is CustomDataNode) {
                        customDataNode = node as CustomDataNode;
                        nodeCount++;
                    }
                }
                if (nodeCount == 0) {
                    hasCustomData = false;
                } else if (nodeCount > 1) {
                    throw new System.Exception("Danmaku 2D: ParticleBulletGraph 中应仅有一个 Custom Data 节点");
                }
            }
            if (hasCustomData) customDataNode.SetInput(customData);
        }
        
        public void SetEmitCount(int emitCount) {
            if (hasEmitCountNode && emitCountNode == null) {
                int nodeCount = 0;
                foreach (Node node in nodes) {
                    if (node is EmitCountNode) {
                        emitCountNode = node as EmitCountNode;
                        nodeCount++;
                    }
                }
                if (nodeCount == 0) {
                    hasEmitCountNode = false;
                } else if (nodeCount > 1) {
                    throw new System.Exception("Danmaku 2D: ParticleBulletGraph 中应仅有一个 Custom Data 节点");
                }
            }
            if (hasEmitCountNode) emitCountNode.SetInput(emitCount);
        }
    }

}