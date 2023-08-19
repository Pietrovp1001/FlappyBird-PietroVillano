using UnityEngine;
using TMPro;

namespace FlappyBird
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI score;

        public void UpdateScore()
        {
            if (score != null)
                score.text = GameManager.Instance.scoreCount.ToString();
        }
    }
}