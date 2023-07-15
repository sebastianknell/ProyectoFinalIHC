using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI finalPointsRef;
    public TextMeshProUGUI maxPointsRef;
    void Start()
    {
        if (maxPointsRef != null)
        {
            var maxScore = PlayerPrefs.GetInt("max_score");
            maxPointsRef.text = String.Format("Máxima puntuación: {0}", maxScore);
        }

        if (finalPointsRef != null)
        {
            var lastScore = PlayerPrefs.GetInt("last_score");
            maxPointsRef.text = String.Format("Puntos obtenidos: {0}", lastScore);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onJugarClicked()
    {
        SceneManager.LoadScene("FondoMarino");
    }

    public void onSalirClicked()
    {
        Application.Quit();
    }

    public void onInicioClicked()
    {
        SceneManager.LoadScene("StartMenuScene2");
    }
}
