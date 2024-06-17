using UnityEngine;


namespace Cosmos.InGame.Player
{
    /// <summary>
    /// �v���C���[�̈ړ��������s���N���X
    /// </summary>
    public class PlayerMove : MonoBehaviour
    {
        private const string InputHorizontal = "Horizontal";
        private const string InputVertical = "Vertical";

        [SerializeField, Tooltip("�ړ��͈͂̐����{��"), Min(0)]
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
        /// �v���C���[�̓��͂��󂯎��ړ�������Ԃ�
        /// </summary>
        private Vector3 GetMoveDirection()
        {
            float horizontal = Input.GetAxisRaw(InputHorizontal);
            float vertical = Input.GetAxisRaw(InputVertical);

            return new Vector3(horizontal, vertical).normalized;
        }

        /// <summary>
        /// �v���C���[���J�����͈̔͊O�ɍs���Ȃ��悤�Ɉړ�����N�����v����
        /// </summary>
        /// <param name="movePosition">�ړ���</param>
        /// <returns>�N�����v��̈ړ���</returns>
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

