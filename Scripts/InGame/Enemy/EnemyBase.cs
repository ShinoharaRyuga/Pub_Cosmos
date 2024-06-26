using Cosmos.InGame.System;
using UnityEngine;

namespace Cosmos.InGame.Enemy
{
    public abstract class EnemyBase : MonoBehaviour, IScreenOut
    {
        [SerializeField, Min(0)]
        private float _moveSpeed = 1f;

        public float MoveSpeed => _moveSpeed;

        public GameObject SelfObject => gameObject;

        private void Update()
        {
            Move();
        }

        /// <summary>
        /// 移動処理
        /// </summary>
        public abstract void Move();

        /// <summary>
        /// 撃破処理
        /// </summary>
        public virtual void Destroy()
        {
            Destroy(this.gameObject);
        }
    }

}

