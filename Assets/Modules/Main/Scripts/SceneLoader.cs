using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Modules.Main.Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        private void Start()
        {
            LoadScene("GameScene");
        }

        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadSceneCoroutine(sceneName));
        }
        
        public IEnumerator LoadSceneCoroutine(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            var loadedScene = SceneManager.GetSceneByName(sceneName);
            SceneManager.SetActiveScene(loadedScene);
        }
    }
}
