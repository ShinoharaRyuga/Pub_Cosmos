using UnityEngine;

namespace Cosmos.InGame.Enemy
{
    [RequireComponent(typeof(NomalEnemySpawner))]
    public class DrawNomalEnemySpawnRange : MonoBehaviour
    {
        [SerializeField]
        private Color _gizmoColor;
        [SerializeField]
        private NomalEnemySpawner _nomalEnemySpawner;


        private void OnDrawGizmos()
        {
            if (!_nomalEnemySpawner) { return; }

            Gizmos.color = _gizmoColor;
            Gizmos.DrawWireCube(GetCenterPosition(), _nomalEnemySpawner.SpawnRangeSize);
        }

        private Vector2 GetCenterPosition()
        {
            Vector2 center = new Vector2(
                transform.position.x + _nomalEnemySpawner.CenterOffset.x,
                transform.position.y + _nomalEnemySpawner.CenterOffset.y);

            return center;
        }
    }
}

