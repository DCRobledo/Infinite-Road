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
    public GameObject[] warnings = new GameObject[3];

    public int livesLeft = 3;

    void Start()
    {
        livesLeft = 3;

        foreach (GameObject item in warnings)
        item.SetActive(false);
    }

    public void UpdateLives(){
        if(livesLeft <= 2)
            warnings[0].SetActive(true);
        if(livesLeft <= 1)
            warnings[1].SetActive(true);
        if (livesLeft == 0)
            warnings[2].SetActive(true);
        if (livesLeft < 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

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
}
