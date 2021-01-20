using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// ----------------------------------------------------------------------------------
/// DESCRIPCIÓ: Script para controlar UI
/// AUTOR:  Lau
/// VERSIÓ: 1.0
/// ----------------------------------------------------------------------------------
/// </summary>

public class ScrUIBOSS : MonoBehaviour
{

    public Text tiempo;
    public Text ronda;
    public Image CorazonesVida;
    public Image VidaBoss;
    public GameObject Ronda;
    public GameObject Perdiste;
    float canvasTime;
    public static float roundTime = 0;
    public static float finalTime = 5;
    public GameObject So;


    // Start is called before the first frame update
    void Start()
    {
        roundTime = 0;
        ScrCollision.vidaBoss = 100;
        ScrCollision.vidaPlayer = 10;
        Ronda.SetActive(true);
        Perdiste.SetActive(false);
        So.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        roundTime += Time.deltaTime;
        tiempo.text = roundTime.ToString("0.0"); 
        ronda.text = "Ronda Final" ;
        CorazonesVida.fillAmount = (ScrCollision.vidaPlayer / 10); 
        VidaBoss.fillAmount = (ScrCollision.vidaBoss / 100); 
        canvasTime += Time.deltaTime;
        if (canvasTime >= 2) Ronda.SetActive(false);
        if (ScrCollision.vidaPlayer <= 0)
        {
            Perdiste.SetActive(true);
            So.SetActive(false);
        }
        if (ScrCollision.vidaBoss <= 0)
        {
           
           SceneManager.LoadScene("Winner");
        }
    }

}
