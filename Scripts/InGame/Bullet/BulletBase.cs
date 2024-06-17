using UnityEngine;
using Cosmos.InGame.Enemy;

namespace Cosmos.InGame.Bullet
{
    public abstract class BulletBase : MonoBehaviour
    {
        [SerializeField, Min(0)]
        private float _moveSpeed = 1f;
        [SerializeField, Min(0), Tooltip("���̒e�𔭎ˏo����܂ł̑ҋ@����")]
        private float _nextFireTime = 1f;
        [SerializeField, Tooltip("�G���ђʂ��邩")]
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
                if (!_isPerforate)  //�e���폜���邩�ǂ���
                {
                    Destroy(gameObject);
                }

                enemy.Destroy();
            }
        }

        /// <summary>
        /// �ړ�����
        /// </summary>
        public abstract void Move();

        /// <summary>
        /// �e���J�����͈̔͊O�ɏo�����ǂ������肷��
        /// </summary>
        /// <returns></returns>
        private bool CheckScreenOut()
        {
            Vector3 viewPosition = Camera.main.WorldToViewportPoint(transform.position);

            bool xCheck = viewPosition.x < -0.0f || viewPosition.x > 1.0f; //x�����J�����͈̔͊O���`�F�b�N
            bool yCheck = viewPosition.y < -0.0f || viewPosition.y > 1.0f; //y�����J�����͈̔͊O���`�F�b�N

            if (xCheck || yCheck)  //�J�����͈̔͊O
            {
                return true;
            }

            return false;
        }
    }
}


