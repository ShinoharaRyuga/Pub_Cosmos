using UnityEngine;

namespace Cosmos.InGame.Player
{
    /// <summary>
    /// �v���C���[�i���@�j�̃p�����[�^���Ǘ�����f�[�^�N���X
    /// </summary>
    [CreateAssetMenu(menuName = "Parameters/Player", fileName = "PlayerParameter")]
    public class PlayerParameterData : ScriptableObject
    {
        [SerializeField, Min(0)]
        private float _moveSpeed = 0f;
        [SerializeField, Min(0)]
        private float _shootingRate = 0f;

        public float MoveSpeed => _moveSpeed;

        public float ShootionRate => _shootingRate;
    }
}
