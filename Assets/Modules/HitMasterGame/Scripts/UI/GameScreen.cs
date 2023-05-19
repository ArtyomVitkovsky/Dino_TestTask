using Modules.HitMasterGame.Scripts.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.HitMasterGame.Scripts.UI
{
    public class GameScreen : MonoBehaviour
    {
        [SerializeField] private Button startButton;

        public Button StartButton => startButton;

        private void Start()
        {
            startButton.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            GameSettings.IS_PAUSED = false;
            gameObject.SetActive(false);
        }
    }
}