using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void Opciones()
    {
        SceneManager.LoadScene("Opciones");
    }

    public void Controles()
    {
        SceneManager.LoadScene("Controles");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
