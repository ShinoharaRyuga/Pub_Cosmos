using UnityEngine;

namespace Cosmos.InGame.Player
{
    /// <summary>
    /// プレイヤー（自機）のパラメータを管理するデータクラス
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
