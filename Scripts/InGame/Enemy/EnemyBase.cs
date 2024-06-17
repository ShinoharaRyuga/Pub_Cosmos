using UnityEngine;

namespace Cosmos.InGame.Enemy
{
    public abstract class EnemyBase : MonoBehaviour
    {
        [SerializeField, Min(0)]
        private float _moveSpeed = 1f;

        /// <summary>�J�����O�Ɉړ����̂ݍ폜���s���ׂ̕ϐ� </summary>
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
        /// �ړ�����
        /// </summary>
        public abstract void Move();

        /// <summary>
        /// ���j����
        /// </summary>
        public virtual void Destroy()
        {
            Destroy(this.gameObject);
        }

        /// <summary>
        /// �J�����͈̔͊O�ɏo�����ǂ������肷��
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

