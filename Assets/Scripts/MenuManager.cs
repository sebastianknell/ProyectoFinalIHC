using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
