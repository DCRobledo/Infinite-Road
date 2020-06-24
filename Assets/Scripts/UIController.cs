using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour
{
    public float counter = 0f;

    public GameObject timer;
    public GameObject deathPanel;

    public GameObject[] warnings = new GameObject[3];

    public int livesLeft = 3;

    public Text statsText;

    void Start()
    {
        livesLeft = 3;

        foreach (GameObject item in warnings)
        item.SetActive(false);

        deathPanel.SetActive(false);

    }

    public void UpdateLives(){
        if(livesLeft <= 2)
            warnings[0].SetActive(true);

        if(livesLeft <= 1)
            warnings[1].SetActive(true);

        if (livesLeft == 0)
            warnings[2].SetActive(true);

        if (livesLeft < 0 || Input.GetKeyDown(KeyCode.Q))
            DeathPanel();
    }

    public void DeathPanel() {
        GameObject.FindGameObjectWithTag("Car").transform.GetComponent<AudioSource>().Stop();

        GameObject.FindGameObjectWithTag("Car").transform.GetComponent<CarController>().canMove = false;
        
        deathPanel.SetActive(true);

        string minutes = Mathf.Floor(counter/60f).ToString("00");
        string seconds = (counter%60).ToString("00");

        int carY = Mathf.RoundToInt(GameObject.FindGameObjectWithTag("Car").transform.position.y);

        statsText.text = "Distance travelled: " + carY + " m\n"
                         +"Time Taken: " + minutes + " min " + seconds + " s\n"
                         +"Score: " + carY*6;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLives();
        UpdateTime();
    }

    private void UpdateTime()
    {
        counter += Time.deltaTime;

        string minutes = Mathf.Floor(counter / 60f).ToString("00");
        string seconds = (counter % 60f).ToString("00");

        timer.GetComponent<Text>().text = minutes + ":" + seconds;
    }

    public void retryButtonPress() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void exitButtonPressed() {
        Application.Quit();
    }
}
