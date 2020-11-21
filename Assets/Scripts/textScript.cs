using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class textScript : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text ="Your gold: " + PlayerPrefs.GetInt("GoldAmount").ToString();
    }
}
