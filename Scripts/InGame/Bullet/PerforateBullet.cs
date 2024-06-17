using UnityEngine;

namespace Cosmos.InGame.Bullet
{
    public class PerforateBullet : BulletBase
    {
        public override void Move()
        {
            transform.position = transform.position + (Vector3.up * Time.deltaTime * MoveSpeed);
        }
    }

}

