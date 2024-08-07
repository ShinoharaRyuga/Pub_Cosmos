using UnityEngine;
using Cosmos.InGame.Enemy;
using Cosmos.InGame.System;

namespace Cosmos.InGame.Bullet
{
    public abstract class BulletBase : MonoBehaviour, IRangeOut
    {
        [SerializeField, Min(0)]
        private float _moveSpeed = 1f;
        [SerializeField, Min(0), Tooltip("次の弾を発射出来るまでの待機時間")]
        private float _nextFireTime = 1f;
        [SerializeField, Tooltip("敵を貫通するか")]
        private bool _isPerforate = false;

        public float MoveSpeed => _moveSpeed;

        public float NextFireTime => _nextFireTime;

        public GameObject SelfObject => transform.gameObject;

        public void Awake()
        {
            RangeOutChecker.Instance.AddCheckObject(this);
        }

        private void Update()
        {
            Move();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out EnemyBase enemy))
            {
                if (!_isPerforate)  //弾を削除するかどうか
                {
                    RangeOutChecker.Instance.RemoveCheckObject(this);
                    Destroy(gameObject);
                }

                enemy.Destroy();
            }
        }

        /// <summary>
        /// 移動処理
        /// </summary>
        public abstract void Move();
    }
}


