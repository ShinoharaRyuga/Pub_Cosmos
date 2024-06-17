using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cosmos.Utility;

namespace Cosmos.InGame.Player
{
    /// <summary>
    /// �v���C���[�֘A�̃N���X���܂Ƃ߂�}�l�[�W���[�N���X
    /// </summary>
    [RequireComponent(typeof(PlayerMove), typeof(PlayerShooter))]
    public class PlayerManager : SingletonMonoBehaviour<PlayerManager>
    {
        protected override bool IsDontDestroyOnLoad => false;

        [SerializeField]
        private PlayerParameterData _parameter;

        public PlayerParameterData Parameter => _parameter;
    }
}


