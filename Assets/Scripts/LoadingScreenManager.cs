using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenManager : MonoBehaviour
{
   [SerializeField] private Slider loadingSlider;

    private void Start()
    {
        string sceneName = FlowManager.Instance.GetSceneToLoad();

        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string scene)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(scene);
        
        while(!loadOperation.isDone)
        {
            float sliderProgress = Mathf.Clamp01(loadOperation.progress / 0.9f);
            loadingSlider.value = sliderProgress;
            yield return null;
        }
    }
}
