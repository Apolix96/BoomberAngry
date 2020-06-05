using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject panelPause;

   public void Pause()
   {
        panelPause.SetActive(true);
        Time.timeScale = 0;
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
