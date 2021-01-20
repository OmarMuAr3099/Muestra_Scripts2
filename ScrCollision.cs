using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ----------------------------------------------------------------------------------
/// DESCRIPCIÓ
///         Script associat a Player i NPCs. Detecta col·lisions amb objectes 
///         enemics, mira el mal que fan, disminueixen la vida restant, i si 
///         arriba a 0, es destrueixen. També s'encarrega d'eliminar els trets
/// AUTOR:  Omar Muñoz
/// VERSIÓ: 1.0
/// ----------------------------------------------------------------------------------
/// </summary>

public class ScrCollision : MonoBehaviour
{
    [SerializeField]
    public float vitality = 2f; // Vida que té el gameobject
    
    public static float vidaPlayer = 10f;

    public static float vidaBoss = 100f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // print(transform.name + " vs " + collision.name);
        ScrDamage scrD = collision.GetComponent<ScrDamage>(); // intentem llegir script ScrDamage    
        if (scrD) // si en té, és un objecte que treu vida. Calculem
        {
            if (tag == "Player")   // soc el player 
                vidaPlayer -= scrD.damagePlayer;
            if (tag == "Boss")   // soc el player 
                vidaBoss -= scrD.damageNPC;
            else vitality -= scrD.damageNPC; // soc un NPC
            if (collision.tag == "Shot") collision.SendMessage("Destruccio", SendMessageOptions.DontRequireReceiver);
            // si no em queda vida, m'autodestrueixo 
            
            if (vitality <= 0) SendMessage("Destruccio", SendMessageOptions.DontRequireReceiver);

            if (vidaBoss <= 0) SendMessage("Destruccio", SendMessageOptions.DontRequireReceiver);

            if (vidaPlayer <= 0) SendMessage("Muerte", SendMessageOptions.DontRequireReceiver);
        }

    }
}
