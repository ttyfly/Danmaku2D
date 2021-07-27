using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using UnityEngine.ParticleSystemJobs;

namespace AngleRD.Danmaku2D.Runtime {

    [AddComponentMenu("Danmaku 2D/Particle Emitter")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ParticleSystem))]
    public class ParticleEmitterBehaviour : MonoBehaviour {

        public ParticleBulletGraph graph;

        [HideInInspector]
        public Emitter emitter;

        private int[] emittedCount;
        private new ParticleSystem particleSystem;

        private ParticleSystem.Particle[] particles;
        // private UpdateParticlesJob job = new UpdateParticlesJob();
        private List<Vector4> customData = new List<Vector4>();
        private BulletCustomData[] bulletCustomData;
        private int bulletCustomDataLength;

        void Start() {
            emittedCount = new int[emitter.emitterPorts.Length]; // int 类型默认值即为 0
            particleSystem = GetComponent<ParticleSystem>();
            particles = new ParticleSystem.Particle[particleSystem.main.maxParticles];
            bulletCustomData = new BulletCustomData[particleSystem.main.maxParticles];
        }

        void Update() {
            
        }

        void FixedUpdate() {
            for (int i = 0; i < emitter.emitterPorts.Length; i++) {
                if (emittedCount[i] < emitter.emitterPorts[i].emitCount) {
                    int bulletsToEmit = emitter.emitterPorts[i].emitCount - emittedCount[i];
                    for (int j = 0; j < bulletsToEmit; j++) {
                        ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
                        emitParams.position = transform.position + transform.rotation * (Vector3)emitter.emitterPorts[i].deltaPosition;
                        emitParams.rotation = emitter.emitterPorts[i].rotation;
                        // 将后续所需数据暂存在粒子速度中
                        emitParams.velocity = new Vector3 {
                            x = 0,
                            y = emittedCount[i] + 1, // 子弹计数
                            z = emitter.emitterPorts[i].rotation + transform.parent.eulerAngles.z, // 粒子运动方向
                        };
                        emitParams.startLifetime = emitter.emitterPorts[i].duration;
                        particleSystem.Emit(emitParams, 1);
                        emittedCount[i]++;
                    }
                }
            }

            particleSystem.GetCustomParticleData(customData, ParticleSystemCustomData.Custom1);
            int len = particleSystem.GetParticles(particles);
            // 将暂存在粒子速度中的数据转移到粒子的 customData 中
            for (int i = 0; i < customData.Count; i++) {
                if (customData[i] == Vector4.zero) {
                    customData[i] = new Vector4 {
                        w = bulletCustomDataLength++, // 为粒子分配一个 bulletCustomData 项
                        x = 0,
                        y = particles[i].velocity.y, // 子弹计数
                        z = particles[i].velocity.z, // 粒子运动方向
                    };
                }
            }
            for (int i = 0; i < len; i++) {
                graph.SetCustomData(bulletCustomData[(int)customData[i].w]);
                graph.SetEmitCount((int)customData[i].y);
                ParticleBullet bullet = graph.GetOutput(1 - particles[i].remainingLifetime / particles[i].startLifetime);
                bulletCustomData[(int)customData[i].w] = bullet.customData;
                particles[i].velocity = Quaternion.Euler(0, 0, customData[i].z) * (Vector3)bullet.velocity * particles[i].startLifetime;
                particles[i].rotation = bullet.rotation;
            }
            particleSystem.SetParticles(particles, len);
            particleSystem.SetCustomParticleData(customData, ParticleSystemCustomData.Custom1);
        }

        // void OnParticleUpdateJobScheduled() {
        //     job.Schedule(particleSystem);
        // }

        // struct UpdateParticlesJob : IJobParticleSystem {

        //     private int uniqueID;

        //     public void Execute(ParticleSystemJobData particles) {
        //         var aliveTimePercent = particles.aliveTimePercent;

        //         var velocitiesX = particles.velocities.x;
        //         var velocitiesY = particles.velocities.y;

        //         var rotations = particles.rotations.z;

        //         var customData1 = particles.customData1;

        //         for (int i = 0; i < particles.count; i++) {
        //             if (customData1[i].x == 0.0f) {
        //                 customData1[i].Set(++uniqueID, 0, 0, 0);
        //             }

        //             ParticleBullet bullet = graph.GetOutput(aliveTimePercent[i] / 100);
        //             velocitiesX[i] = bullet.velocity.x;
        //             velocitiesY[i] = bullet.velocity.y;
        //             rotations[i] = bullet.rotation;
        //         }
        //     }
        // }
    }

}
