using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrOpciones : MonoBehaviour
{
    public static AudioSource a;

    void Start()
    {
        a = GetComponent<AudioSource>();
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }

       
}
