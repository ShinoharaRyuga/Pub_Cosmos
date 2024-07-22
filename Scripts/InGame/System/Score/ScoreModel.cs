using UniRx;
using System;

namespace Cosmos.InGame.System
{
    public class ScoreModel
    {
        public IReadOnlyReactiveProperty<int> Score => _score;
        private ReactiveProperty<int> _score = new ReactiveProperty<int>();

        public void AddScore(int addValue)
        {
            _score.Value += addValue;
        }
    }
}

