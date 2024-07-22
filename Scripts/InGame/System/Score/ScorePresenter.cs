using UniRx;

namespace Cosmos.InGame.System
{
    public class ScorePresenter
    {
        private readonly ScoreModel _scoreModel;
        private readonly ScoreView _scoreView;

        public ScorePresenter(ScoreModel scoreModel, ScoreView scoreView)
        {
            _scoreModel = scoreModel;
            _scoreView = scoreView;
        }

        public void RegisterObserver(CompositeDisposable compositeDisposable)
        {
            _scoreModel.Score
                .Subscribe(score => _scoreView.UpdateScoreText(score.ToString()))
                .AddTo(compositeDisposable);
        }

        public void AddScore(int addValue)
        {
            _scoreModel.AddScore(addValue);
        }
    }

}

