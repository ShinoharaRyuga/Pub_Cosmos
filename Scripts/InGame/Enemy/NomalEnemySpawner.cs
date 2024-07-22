using Cosmos.InGame.System;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UniRx;
using Random = UnityEngine.Random;


namespace Cosmos.InGame.Enemy
{
    public class NomalEnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private NomalEnemy _nomalEnemyPrefab;
        [SerializeField, Min(0)]
        private float _minWaitTime = 0f;
        [SerializeField, Min(0)]
        private float _maxWaitTime = 0f;
        [SerializeField]
        private Vector2 _centerOffset = Vector2.zero;
        [SerializeField]
        private float _spawnRangeXSize = 1f;
        [SerializeField]
        private ScoreDispatcher _scoreDispatcher;

        public Vector2 CenterOffset => _centerOffset;

        public Vector2 SpawnRangeSize => new Vector2(_spawnRangeXSize, 1);

        private void Start()
        {
            EnemySpawn();
        }


        private async void EnemySpawn()
        {
            bool isSpawn = true;

            while (isSpawn)
            {
                Vector2 spawnPosition = new Vector2(Random.Range(-_spawnRangeXSize / 2, _spawnRangeXSize / 2), _centerOffset.y);
                NomalEnemy nomalEnemy = Instantiate(_nomalEnemyPrefab, spawnPosition, Quaternion.identity);

                nomalEnemy.AddScore
                    .Subscribe(score => _scoreDispatcher.AddScore(score))
                    .AddTo(nomalEnemy);

                CancellationToken token = this.GetCancellationTokenOnDestroy();
                float waitTime = Random.Range(_minWaitTime, _maxWaitTime);

                await UniTask.Delay(TimeSpan.FromSeconds(waitTime), cancellationToken: token);
            }
        }
    }
}


