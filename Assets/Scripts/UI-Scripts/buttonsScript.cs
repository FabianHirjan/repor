using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonsScript : MonoBehaviour
{
    public InputField input;
    public int prize;
    public Button startButton;
    // Start is called before the first frame update
    private void Awake()
    {
        int gotMoney = PlayerPrefs.GetInt("gotMoney", 0);
        if(gotMoney == 0)
        {
            PlayerPrefs.SetInt("GoldAmount", 999);
            PlayerPrefs.SetInt("gotMoney", 1);
        }
    }
    void Start()
    {
        input.characterValidation = InputField.CharacterValidation.Integer;
        Button btn = startButton.GetComponent<Button>();
        btn.onClick.AddListener(onBtnPress);
    }
    public void onBtnPress()
    {
        if (input.text != "")
        {
            prize = int.Parse(input.text);
            int valueToCompare;
            valueToCompare = PlayerPrefs.GetInt("GoldAmount", 0);
            if (valueToCompare > prize)
            {
                PlayerPrefs.SetInt("Prize", prize);
                int newMoney;
                newMoney = PlayerPrefs.GetInt("GoldAmount", 0);
                PlayerPrefs.SetInt("GoldAmount", newMoney - prize);
                ChangeScene("SampleScene");
            }
            else
            {
                input.placeholder.GetComponent<Text>().text = "Enter a smaller amount";
            }

        }

    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
