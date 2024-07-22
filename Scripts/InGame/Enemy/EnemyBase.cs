using Cosmos.InGame.System;
using System;
using UniRx;
using UnityEngine;

namespace Cosmos.InGame.Enemy
{
    public abstract class EnemyBase : MonoBehaviour, IRangeOut
    {
        [SerializeField, Min(0)]
        private float _moveSpeed = 1f;
        [SerializeField, Min(0)]
        private int _addScoreValue = 0;

        private Subject<int> _addScore = new Subject<int>();

        public float MoveSpeed => _moveSpeed;
        public GameObject SelfObject => gameObject;
        public IObservable<int> AddScore => _addScore;

        public void Awake()
        {
            RangeOutChecker.Instance.AddCheckObject(this);
        }

        private void Update()
        {
            Move();
        }

        /// <summary>
        /// à⁄ìÆèàóù
        /// </summary>
        public abstract void Move();

        /// <summary>
        /// åÇîjèàóù
        /// </summary>
        public virtual void Destroy()
        {
            _addScore.OnNext(_addScoreValue);
            RangeOutChecker.Instance.RemoveCheckObject(this);
            Destroy(this.gameObject);
        }
    }

}

