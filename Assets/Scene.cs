using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public GameObject fadePanel;
    public float fadeDuration = 1.5f;
    public string ingameSceneName = "Ingame";

    private bool isTransitioning = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isTransitioning)
        {
            Debug.Log("F key pressed");
            StartCoroutine(TransitionToIngame());
            
        }
    }

    private IEnumerator TransitionToIngame()
    {
        isTransitioning = true;
        fadePanel.SetActive(true);
        float timer = 0f;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            fadePanel.GetComponent<CanvasGroup>().alpha = alpha;
            timer += Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(ingameSceneName);
    }
}
