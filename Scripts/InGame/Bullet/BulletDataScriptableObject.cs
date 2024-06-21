using UnityEngine;
using System;


namespace Cosmos.InGame.Bullet
{
    [CreateAssetMenu(menuName = "BulletData", fileName = "BulletData")]
    public class BulletDataScriptableObject : ScriptableObject
    {
        [SerializeField]
        private BulletData[] _bulletData;

        public BulletData GetBulletData(BulletType type)
        {
            foreach (BulletData b in _bulletData)
            {
                if (b.BulletType == type)
                {
                    return b;
                }
            }

            Debug.LogError("ƒf[ƒ^‚ª‘¶Ý‚µ‚Ü‚¹‚ñ null‚ð•Ô‚µ‚Ü‚·");
            return null;
        }
    }

    [Serializable]
    public class BulletData
    {
        [SerializeField]
        private BulletType _bulletType;
        [SerializeField]
        private BulletBase _bulletPrefab;

        public BulletType BulletType => _bulletType;

        public BulletBase BulletPrefab => _bulletPrefab;
    }
}


