using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ----------------------------------------------------------------------------------
/// DESCRIPCIÓ: Script para controlar UI
/// AUTOR:  Lau
/// VERSIÓ: 1.0
/// ----------------------------------------------------------------------------------
/// </summary>

public class ScrUI : MonoBehaviour
{
    
    public Text tiempo;
    public Text ronda;
    public Image CorazonesVida;
    public Text peces;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo.text = ScrControlGame.roundTime.ToString("0.0");
        ronda.text = "Ronda: " + ScrControlGame.round;
        CorazonesVida.fillAmount = (ScrCollision.vidaPlayer / 10); 
        peces.text = " " + ScrControlGame.PecesRestantes; 
    }
    
}
