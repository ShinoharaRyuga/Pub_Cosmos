using UnityEngine;


namespace Cosmos.InGame.Player
{
    /// <summary>
    /// プレイヤーの移動処理を行うクラス
    /// </summary>
    public class PlayerMove : MonoBehaviour
    {
        private const string InputHorizontal = "Horizontal";
        private const string InputVertical = "Vertical";

        [SerializeField, Tooltip("移動範囲の制限倍率"), Min(0)]
        private float _moveRangeOffset = 0f;

        private bool _isMove = true;

        public bool IsMove { get; set; }

        public float MoveRangeOffset => _moveRangeOffset;

        private void Update()
        {
            if (!_isMove) { return; }

            Move();
        }


        private void Move()
        {
            Vector3 moveDir = GetMoveDirection();
            Vector3 movePos = transform.position + (moveDir * Time.deltaTime * PlayerManager.Instance.Parameter.MoveSpeed);

            transform.position = MovePositionClamp(movePos);
        }

        /// <summary>
        /// プレイヤーの入力を受け取り移動方向を返す
        /// </summary>
        private Vector3 GetMoveDirection()
        {
            float horizontal = Input.GetAxisRaw(InputHorizontal);
            float vertical = Input.GetAxisRaw(InputVertical);

            return new Vector3(horizontal, vertical).normalized;
        }

        /// <summary>
        /// プレイヤーをカメラの範囲外に行かないように移動先をクランプする
        /// </summary>
        /// <param name="movePosition">移動先</param>
        /// <returns>クランプ後の移動先</returns>
        private Vector2 MovePositionClamp(Vector2 movePosition)
        {
            Camera camera = Camera.main;
            Vector2 min = camera.ViewportToWorldPoint(Vector2.zero);
            Vector2 mix = camera.ViewportToWorldPoint(Vector2.one);

            float x = Mathf.Clamp(movePosition.x, min.x * _moveRangeOffset, mix.x * _moveRangeOffset);
            float y = Mathf.Clamp(movePosition.y, min.y * _moveRangeOffset, mix.y * _moveRangeOffset);

            return new Vector2(x, y);
        }
    }
}

