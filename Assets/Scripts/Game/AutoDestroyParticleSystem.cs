using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyParticleSystem : MonoBehaviour
{
    private List<ParticleSystem> childParticleSystems;
    private bool systemsInitialized = false;

    void Start()
    {
        // 获取所有子对象中的粒子系统
        childParticleSystems = new List<ParticleSystem>(GetComponentsInChildren<ParticleSystem>());

        if (childParticleSystems.Count == 0)
        {
            Debug.LogWarning("No particle systems found in children.", this);
            enabled = false; // 禁用脚本
            return;
        }

        // 确保所有粒子系统都在播放
        foreach (var ps in childParticleSystems)
        {
            // 确保每个粒子系统都设置了回调
            var main = ps.main;
            main.stopAction = ParticleSystemStopAction.None; // 重置以防冲突
        }

        systemsInitialized = true;
    }

    void Update()
    {
        if (!systemsInitialized) return;

        bool allFinished = true;
        int activeSystems = 0;

        foreach (var ps in childParticleSystems)
        {
            if (!ps) continue; // 跳过被销毁的粒子系统

            // 如果粒子系统仍处于活动状态
            if (ps.IsAlive() || ps.isPlaying)
            {
                activeSystems++;
                allFinished = false;

                // 我们可以跳出循环优化性能，但保留完整计数
                // 所以不break
            }
        }

        // 如果所有粒子系统都已完成，销毁父物体
        if (allFinished || activeSystems == 0)
        {
            Destroy(gameObject);
        }
    }

    // 在编辑器可视化检测的粒子系统数量
    void OnDrawGizmosSelected()
    {
        if (Application.isPlaying && systemsInitialized)
        {
            Gizmos.color = Color.cyan;
            int activeCount = 0;
            foreach (var ps in childParticleSystems)
            {
                if (ps && (ps.IsAlive() || ps.isPlaying)) activeCount++;
            }
            Gizmos.DrawIcon(transform.position, $"Particles {activeCount}/{childParticleSystems.Count}", true);
        }
    }
}
