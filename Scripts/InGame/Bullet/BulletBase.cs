using UnityEngine;
using Cosmos.InGame.Enemy;
using Cosmos.InGame.System;

namespace Cosmos.InGame.Bullet
{
    public abstract class BulletBase : MonoBehaviour, IRangeOut
    {
        [SerializeField, Min(0)]
        private float _moveSpeed = 1f;
        [SerializeField, Min(0), Tooltip("Ÿ‚Ì’e‚ğ”­Ëo—ˆ‚é‚Ü‚Å‚Ì‘Ò‹@ŠÔ")]
        private float _nextFireTime = 1f;
        [SerializeField, Tooltip("“G‚ğŠÑ’Ê‚·‚é‚©")]
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
                if (!_isPerforate)  //’e‚ğíœ‚·‚é‚©‚Ç‚¤‚©
                {
                    RangeOutChecker.Instance.RemoveCheckObject(this);
                    Destroy(gameObject);
                }

                enemy.Destroy();
            }
        }

        /// <summary>
        /// ˆÚ“®ˆ—
        /// </summary>
        public abstract void Move();
    }
}


