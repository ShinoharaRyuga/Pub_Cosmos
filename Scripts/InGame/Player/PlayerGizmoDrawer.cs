using UnityEngine;

namespace Cosmos.InGame.Player
{
    /// <summary>
    /// �v���C���[�֘A�̃M�Y����`�悷��N���X
    /// </summary>
    public class PlayerGizmoDrawer : MonoBehaviour
    {
        [SerializeField]
        private bool _isGizomDraw = false;
        [SerializeField]
        private Color _gizomColor = Color.white;

        [SerializeField]
        private bool _isDrawPlayerMoveRange = false;
        [SerializeField]
        private PlayerMove _playerMove;

        private void OnDrawGizmos()
        {
            if (!_isGizomDraw) { return; }

            Gizmos.color = _gizomColor;
            DrawPlayerMoveRange();
        }

        /// <summary>
        /// �v���C���[���ړ��o����͈͂�`�悷��
        /// </summary>
        private void DrawPlayerMoveRange()
        {
            if (!_isDrawPlayerMoveRange || !_playerMove) { return; }

            Camera camera = Camera.main;
            float width = camera.orthographicSize * Camera.main.aspect * 2;
            float height = camera.orthographicSize * 2;

            Vector2 size = new Vector2(width, height) * _playerMove.MoveRangeOffset;

            Gizmos.DrawWireCube(camera.transform.position, size);
        }

    }
}


