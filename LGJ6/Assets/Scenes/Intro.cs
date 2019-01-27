using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {
	void Start () {
        Invoke("NextScene", 5);
	}

	void NextScene () {
        SceneManager.LoadScene("Stachu");
	}
}
