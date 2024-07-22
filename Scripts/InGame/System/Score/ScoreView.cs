using UnityEngine;
using TMPro;

namespace Cosmos.InGame.System
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _socreText;

        public void UpdateScoreText(string score)
        {
            _socreText.text = score;
        }
    }
}


