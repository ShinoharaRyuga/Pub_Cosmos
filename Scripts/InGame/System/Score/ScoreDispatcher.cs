using UniRx;
using UnityEngine;

namespace Cosmos.InGame.System
{
    public class ScoreDispatcher : MonoBehaviour
    {
        [SerializeField]
        private ScoreView _socreView;

        private ScoreModel _scoreModel;
        private ScorePresenter _socrePresenter;
        private CompositeDisposable _compositeDisposable;

        private void Start()
        {
            Initialize();
            RegisterObserver();
        }

        public void AddScore(int addValue)
        {
            _socrePresenter.AddScore(addValue);
        }

        private void Initialize()
        {
            _compositeDisposable = new CompositeDisposable();
            _scoreModel = new ScoreModel();
            _socrePresenter = new ScorePresenter(_scoreModel, _socreView);
        }

        private void RegisterObserver()
        {
            _socrePresenter.RegisterObserver(_compositeDisposable);
        }
    }
}


