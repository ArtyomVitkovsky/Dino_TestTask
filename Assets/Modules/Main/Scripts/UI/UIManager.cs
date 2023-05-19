using Modules.HitMasterGame.Scripts.UI;
using UnityEngine;

namespace Modules.Main.Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private LoadingScreen loadingScreen;
        
        [Header("Game")]
        [SerializeField] private GameScreen gameScreen;

        public GameScreen GameScreen => gameScreen;

        public void ShowLoadingScreen()
        {
            gameScreen.gameObject.SetActive(false);
            loadingScreen.gameObject.SetActive(true);
        }
        
        public void ShowGameScreen()
        {
            gameScreen.gameObject.SetActive(true);
            loadingScreen.gameObject.SetActive(false);
        }
    }
}