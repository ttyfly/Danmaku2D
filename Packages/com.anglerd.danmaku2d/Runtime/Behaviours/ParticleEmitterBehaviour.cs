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

        void Start() {
            emittedCount = new int[emitter.emitterPorts.Length]; // int 类型默认值即为 0
            particleSystem = GetComponent<ParticleSystem>();
            particles = new ParticleSystem.Particle[particleSystem.main.maxParticles];
        }

        void Update() {
            
        }

        void FixedUpdate() {
            for (int i = 0; i < emitter.emitterPorts.Length; i++) {
                if (emittedCount[i] < emitter.emitterPorts[i].emitCount) {
                    ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
                    emitParams.position = transform.position + transform.rotation * (Vector3)emitter.emitterPorts[i].deltaPosition;
                    emitParams.rotation = emitter.emitterPorts[i].rotation;
                    emitParams.velocity = Quaternion.Euler(0, 0, emitter.emitterPorts[i].rotation + transform.parent.eulerAngles.z) * Vector3.right;
                    emitParams.startLifetime = emitter.emitterPorts[i].duration;
                    particleSystem.Emit(emitParams, 1);
                    emittedCount[i] = emitter.emitterPorts[i].emitCount;
                }
            }

            particleSystem.GetCustomParticleData(customData, ParticleSystemCustomData.Custom1);
            int len = particleSystem.GetParticles(particles);
            // 将粒子初速度存入 customData 中，用于确定运动方向
            for (int i = 0; i < customData.Count; i++) {
                if (customData[i] == Vector4.zero) {
                    customData[i] = particles[i].velocity;
                }
            }
            for (int i = 0; i < len; i++) {
                ParticleBullet bullet = graph.GetOutput(1 - particles[i].remainingLifetime / particles[i].startLifetime);
                particles[i].velocity = Quaternion.FromToRotation(Vector3.right.normalized, customData[i]) * (Vector3)bullet.velocity * particles[i].startLifetime;
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
