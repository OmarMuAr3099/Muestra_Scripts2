using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ----------------------------------------------------------------------------------
/// DESCRIPCIÓ
///         Script associat a l'enemic.
///         
/// AUTOR:  Omar muñoz
/// VERSIÓ: 1.0
/// ----------------------------------------------------------------------------------
/// </summary>

public class ScrEnemigo : MonoBehaviour
{
    
    Vector2 moviment = new Vector2();


    public float velocidad = 0;
    public float multiplicadorVel = 1;
    
    GameObject player;
    
    [SerializeField] GameObject explosio;

    Rigidbody2D rb;

    private void Awake()
    {
        
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moviment.y = Random.Range(-3f, 3f);
        player = GameObject.FindGameObjectWithTag("Player");
        if (ScrControlGame.round == 1) multiplicadorVel = 1;
        if (ScrControlGame.round == 2) multiplicadorVel = 1.5f;
        if (ScrControlGame.round == 3) multiplicadorVel = 2;


    }

    void FixedUpdate()
    {
        
        rb.velocity = moviment;

        moviment.y = (player.transform.position.y - transform.position.y) / 5;
        moviment.x = (player.transform.position.x - transform.position.x)*(velocidad*multiplicadorVel);

        if(moviment.x<0) transform.localScale = new Vector3(-1, 1, 1);
        else transform.localScale = new Vector3(1, 1, 1);
    }

        
    void Destruccio()
    {
        Instantiate(explosio, transform.position, transform.rotation);
        
       
        Destroy(gameObject);

       

    }

}
