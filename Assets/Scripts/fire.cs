using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class fire : MonoBehaviour
{
    public GameObject blast;
    public GameObject firePlace;
    public TextMeshProUGUI bullets;
    public TextMeshProUGUI score;
    public TextMeshProUGUI congratulations;
    public AudioClip gunShot;

    public int usedBullets;
    public int maxBullets;
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject gun;

    public buttonsScript other;
    private void Awake()    
    {
        pauseMenuUI.SetActive(false);
        score.text = "0";
        PlayerPrefs.SetInt("Score", 0);
    }

    private void Start()
    {
        this.gameObject.AddComponent<AudioSource>();
        this.GetComponent<AudioSource>().clip = gunShot;
    }
    // Update is called once per frame
    void Update()
    {
        int scorePct = PlayerPrefs.GetInt("Score", 0);
        score.text = scorePct + " Points";
        bullets.text = usedBullets + " / " + maxBullets; 
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(usedBullets <= maxBullets)
            {
                this.GetComponent<AudioSource>().Play();
                Instantiate(blast, firePlace.transform.position, firePlace.transform.rotation);
                usedBullets++;

            }
            
        }
        if(usedBullets > maxBullets)
        {
            EndGame();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("MainMenu");
        }
        
    }
    void EndGame()
    {
        int scorePct = PlayerPrefs.GetInt("Score", 0);
        gameIsPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gun.SetActive(false);
        if(scorePct == 100)
        {
            int cash, myCash;
            congratulations.text = "You scored an ACE!";
            cash = PlayerPrefs.GetInt("Prize", 0);
            myCash = PlayerPrefs.GetInt("GoldAmount", 0);
            PlayerPrefs.SetInt("GoldAmount", myCash + (cash * 2));

        }
        else
        {
            congratulations.text = "You lost";
        }
        
    }
}
