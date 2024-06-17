using UnityEngine;
using Cosmos.InGame.Enemy;

namespace Cosmos.InGame.Bullet
{
    public abstract class BulletBase : MonoBehaviour
    {
        [SerializeField, Min(0)]
        private float _moveSpeed = 1f;
        [SerializeField, Min(0), Tooltip("次の弾を発射出来るまでの待機時間")]
        private float _nextFireTime = 1f;
        [SerializeField, Tooltip("敵を貫通するか")]
        private bool _isPerforate = false;

        public float MoveSpeed => _moveSpeed;

        public float NextFireTime => _nextFireTime;

        private void Update()
        {
            Move();

            if (CheckScreenOut())
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out EnemyBase enemy))
            {
                if (!_isPerforate)  //弾を削除するかどうか
                {
                    Destroy(gameObject);
                }

                enemy.Destroy();
            }
        }

        /// <summary>
        /// 移動処理
        /// </summary>
        public abstract void Move();

        /// <summary>
        /// 弾がカメラの範囲外に出たかどうか判定する
        /// </summary>
        /// <returns></returns>
        private bool CheckScreenOut()
        {
            Vector3 viewPosition = Camera.main.WorldToViewportPoint(transform.position);

            bool xCheck = viewPosition.x < -0.0f || viewPosition.x > 1.0f; //x軸がカメラの範囲外かチェック
            bool yCheck = viewPosition.y < -0.0f || viewPosition.y > 1.0f; //y軸がカメラの範囲外かチェック

            if (xCheck || yCheck)  //カメラの範囲外
            {
                return true;
            }

            return false;
        }
    }
}


