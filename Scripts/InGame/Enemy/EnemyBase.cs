using UnityEngine;

namespace Cosmos.InGame.Enemy
{
    public abstract class EnemyBase : MonoBehaviour
    {
        [SerializeField, Min(0)]
        private float _moveSpeed = 1f;

        /// <summary>カメラ外に移動時のみ削除を行う為の変数 </summary>
        private bool _inCamera = false;

        public float MoveSpeed => _moveSpeed;

        private void Update()
        {
            Move();

            //if (CheckScreenOut() && _inCamera)
            //{
            //    Destroy(gameObject);
            //}
            //else
            //{
            //    _inCamera = true;
            //}
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

        /// <summary>
        /// カメラの範囲外に出たかどうか判定する
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

