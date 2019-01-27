using UnityEngine;
using UnityEngine.UI;

public class DistanceScript : MonoBehaviour
{
    public Text text;    

    void Update()
    {
        text.text = PlayerPrefs.GetFloat("traveledDistance").ToString("F2") + "m";
    }
}
