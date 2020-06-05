using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject panelPause;
    private void Start()
    {
        Pause();
    }

    public void Pause()
    {
        panelPause.SetActive(true);
        Time.timeScale = 0;
    }

    public void ReloadPauseGameDestroyObject()
    {
        SceneManager.LoadScene("SampleScene");

    }
   
    public void OffPause()
    {
        panelPause.SetActive(false);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

   
}
