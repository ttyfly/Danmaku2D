using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AngleRD.Danmaku2D.Runtime {

    [AddComponentMenu("Danmaku 2D/Prefab Bullet")]
    [DisallowMultipleComponent]
    public class PrefabBulletBehaviour : MonoBehaviour {

        public PrefabBulletGraph graph;
        public float duration;
        public bool playOnAwake;

        private float startTime;
        private bool isPlaying;
        private PrefabBullet bullet;
        private int[] emittedCount;
        private ParticleEmitterBehaviour[] emitterBehaviour;

        void Start() {
            bullet = graph.GetOutput(0);

            // 对发射器端口进行计数
            int emitterPortCount = 0;
            // 对粒子类型的子弹发射器进行计数
            int particleEmitterCount = 0;
            foreach (Emitter emitter in bullet.attachedEmitters) {
                emitterPortCount += emitter.emitterPorts.Length;
                if (emitter.type == Emitter.BulletType.Particle) {
                    particleEmitterCount++;
                }
            }

            emittedCount = new int[emitterPortCount]; // int 类型默认值即为 0
            emitterBehaviour = new ParticleEmitterBehaviour[particleEmitterCount];

            for (int i = 0; i < bullet.attachedEmitters.Length; i++) {
                Emitter emitter = bullet.attachedEmitters[i];
                if (emitter.type == Emitter.BulletType.Particle) {
                    GameObject psObject = Instantiate(emitter.particleSystemPrefab, transform);
                    psObject.transform.localPosition = Vector3.zero;
                    emitterBehaviour[i] = psObject.GetComponent<ParticleEmitterBehaviour>();
                    emitterBehaviour[i].emitter = emitter;
                }
            }

            if (playOnAwake) Play();
        }

        void Update() {
        }

        void FixedUpdate() {
            if (Time.time - startTime > duration) {
                Stop();
            }
            if (isPlaying) {
                bullet = graph.GetOutput((Time.time - startTime) / duration);
                transform.position += (Vector3)bullet.velocity * Time.fixedDeltaTime;
                transform.rotation = Quaternion.Euler(0, 0, bullet.rotation);

                for (int i = 0; i < bullet.attachedEmitters.Length; i++) {
                    Emitter emitter = bullet.attachedEmitters[i];
                    if (emitter.type == Emitter.BulletType.Prefab) {
                        foreach (EmitterPort port in emitter.emitterPorts) {
                            if (port.emitCount > emittedCount[i]) {
                                // 在一帧内发射子弹数如果大于1，则只发射一颗子弹
                                GameObject bulletObject = Instantiate(
                                    emitter.bulletPrefab,
                                    port.deltaPosition,
                                    Quaternion.Euler(0, 0, port.rotation),
                                    transform
                                );
                                PrefabBulletBehaviour bulletComponent;
                                if (bulletObject.TryGetComponent<PrefabBulletBehaviour>(out bulletComponent)) {
                                    bulletComponent.Play();
                                } else {
                                    throw new System.Exception("Danmaku 2D: 子弹预制件未添加子弹组件。");
                                }
                            }
                            emittedCount[i++] = port.emitCount;
                        }
                    } else if (emitter.type == Emitter.BulletType.Particle) {
                        emitterBehaviour[i].emitter = emitter;
                    } else {
                        Debug.LogError("Danmaku 2D: Unexpected Bullet Type.");
                    }
                }
            }
        }

        public void Play() {
            startTime = Time.time;
            isPlaying = true;
        }

        public void Stop() {
            isPlaying = false;
        }
    }

}
