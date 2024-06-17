using UnityEngine;
using Cosmos.InGame.Bullet;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;

namespace Cosmos.InGame.Player
{
    public class PlayerShooter : MonoBehaviour
    {
        private const string SpaceButton = "Jump";

        [SerializeField]
        private BulletType _curretBulletType = BulletType.Nomal;
        [SerializeField]
        private BulletDataScriptableObject _bulletData;
        [SerializeField]
        private Transform _fireBulletPosition;

        private BulletBase _currentBulletPrefab;

        private bool _isFire = true;

        private void Start()
        {
            GetBulletPrefab();
        }


        private void Update()
        {
            if (Input.GetButtonDown(SpaceButton))
            {
                FireBullet();
            }
        }

        /// <summary>
        /// ’e‚ð”­ŽË‚·‚é
        /// </summary>
        private void FireBullet()
        {
            if (!_currentBulletPrefab || !_isFire) { return; }

            BulletBase bullet = Instantiate(_currentBulletPrefab, _fireBulletPosition.position, Quaternion.identity);
            WaitFireRate();
        }

        private async void WaitFireRate()
        {
            CancellationToken token = this.GetCancellationTokenOnDestroy();

            _isFire = false;
            await UniTask.Delay(TimeSpan.FromSeconds(_currentBulletPrefab.NextFireTime), cancellationToken: token);
            _isFire = true;
        }

        private void GetBulletPrefab()
        {
            BulletData bulletData = _bulletData.GetBulletData(_curretBulletType);

            if (bulletData == null) { return; }

            _currentBulletPrefab = bulletData.BulletPrefab;
        }
    }
}

