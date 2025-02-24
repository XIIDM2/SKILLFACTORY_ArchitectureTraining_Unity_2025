using CodeBase.GamePlay.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CodeBase.Configs
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/Enemy")]
    public partial class EnemyConfig : ScriptableObject
    {
        public EnemyID enemyID; 
        public float AttackDamage;
        public float AttackCooldown;
        public float AttackRadius;
        public float MovementSpeed;
        public float StopDistance;
        public float MaxHealth;

        public GameObject EnemyPrefab;
    }

}