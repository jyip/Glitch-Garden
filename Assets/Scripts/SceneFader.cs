using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneFader : MonoBehaviour {

    public float fadeDuration;
    private Image fadePanel;

	// Use this for initialization
	void Start () {
        fadePanel = GetComponent<Image>();
        fadePanel.CrossFadeAlpha(0, fadeDuration, false);
        Invoke("RemoveSceneFader", fadeDuration);
	}

    void RemoveSceneFader() {
        Destroy(gameObject);
    }
}
