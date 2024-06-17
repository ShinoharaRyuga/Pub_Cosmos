using UnityEngine;

namespace Cosmos.InGame.Enemy
{
    public class NomalEnemy : EnemyBase
    {
        public override void Move()
        {
            transform.position = transform.position + (Vector3.down * Time.deltaTime * MoveSpeed);
        }
    }

}

