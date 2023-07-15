using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI tiempoRef;
    public TextMeshProUGUI puntajeRef;
    private FaunaSpawner _faunaSpawner;

    private float totalTime = 180;
    private float currentTime;
    private int totalPoints = 0;
    private int pointsIncrease = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        currentTime = totalTime;
        tiempoRef.text = FormatTime(currentTime);
        puntajeRef.text = String.Format("{0} puntos", totalPoints);
        _faunaSpawner = FindObjectOfType<FaunaSpawner>();
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdatePoints()
    {
        Debug.Log("updating points");
        totalPoints += 10;
        pointsIncrease += 10;
        puntajeRef.text = String.Format("{0} puntos", totalPoints);
        if (pointsIncrease >= 50)
        {
            _faunaSpawner.SpawnObjects();
            pointsIncrease = 0;
        }
    }
    
    private IEnumerator Countdown()
    {
        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            currentTime -= 1;

            // Update UI or perform any other actions based on the current time
            Debug.Log("Current Time: " + FormatTime(currentTime));
            tiempoRef.text = FormatTime(currentTime);
        }

        // Time's up, perform final actions
        Debug.Log("Time's up!");
        SceneManager.LoadScene("FinalMenuScene");
    }
    
    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    private void OnDisable()
    {
        var maxScore = PlayerPrefs.GetInt("max_score");
        if (totalPoints > maxScore)
        {
            PlayerPrefs.SetInt("max_score", totalPoints);
        }
        PlayerPrefs.SetInt("last_score", totalPoints);
    }
}
