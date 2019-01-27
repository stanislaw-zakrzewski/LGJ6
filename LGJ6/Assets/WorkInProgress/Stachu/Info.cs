using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour {
    public Image imageToChangeVisibility;
    private bool visibility = false;

	void Start () {
        imageToChangeVisibility.GetComponent<Image>().enabled = false;
        gameObject.GetComponent<Button>().onClick.AddListener(() => ChangeVisibility());
	}
	
	void ChangeVisibility()
    {
        visibility = !visibility;
        imageToChangeVisibility.GetComponent<Image>().enabled = visibility;
    }
}
