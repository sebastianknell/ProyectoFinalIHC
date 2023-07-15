using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI tiempoRef;
    public TextMeshProUGUI puntajeRef;

    private float totalTime = 300;
    private float currentTime;
    private int totalPoints = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        currentTime = totalTime;
        tiempoRef.text = FormatTime(currentTime);
        puntajeRef.text = String.Format("{0} puntos", totalPoints);
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
        puntajeRef.text = String.Format("{0} puntos", totalPoints);
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
    }
    
    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
