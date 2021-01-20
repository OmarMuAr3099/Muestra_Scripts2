using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ----------------------------------------------------------------------------------
/// DESCRIPCIÓ
///         Controla comportament Boss
/// AUTOR:  Javi Sánchez
/// VERSIÓ: 1.0
/// ----------------------------------------------------------------------------------
/// </summary>

public class ScrBoss : MonoBehaviour
{
    public float vel = -0.5f;
    Rigidbody2D rb;
    [SerializeField] GameObject explosio;
    Collider2D col;
    [SerializeField] Renderer r;

    Animator ani;

    bool up;
    bool down;
    float TimeRun = 4f;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        col.enabled = false;
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponentInChildren<Animator>();
        down = true;
        up = false;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(0, vel);
        Moviment();
    }
    void Update()
    {

        if (ScrControlGame.EsVisibleDesde(r, Camera.main))  // Només si el pop està a pantalla
        {
            col.enabled = true;
        }

        if (ScrCollision.vidaBoss > 75)
        {
            ScrNPCShot.cadenciaMax = 3;
        }
        if (ScrCollision.vidaBoss <= 75 && ScrCollision.vidaBoss > 30)
        {
            ScrNPCShot.cadenciaMax = 2;
        }
        if (ScrCollision.vidaBoss <= 30)
        {
            ScrNPCShot.cadenciaMax = 1;
            ScrApuntar.finalFase = true;
        }
    }

    void Destruccio() // indica com es destrueix l'objecte
    {
        if (explosio) Instantiate(explosio, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void Moviment()
    {
        if (up == true)
        {
            if (ScrCollision.vidaBoss > 75)
            {
                vel = 0.5f;
                TimeRun -= Time.deltaTime;
            }
            if (ScrCollision.vidaBoss <= 75 && ScrCollision.vidaBoss > 30)
            {
                vel = 1f;
                TimeRun -= Time.deltaTime;
            }
            if (ScrCollision.vidaBoss <= 30)
            {
                vel = 1.5f;
                TimeRun -= Time.deltaTime;
            }
        }
        if (down == true)
        {
            if (ScrCollision.vidaBoss > 75)
            {
                vel = -0.5f;
                TimeRun -= Time.deltaTime;
            }
            if (ScrCollision.vidaBoss <= 75 && ScrCollision.vidaBoss > 30)
            {
                vel = -1f;
                TimeRun -= Time.deltaTime;
            }
            if (ScrCollision.vidaBoss <= 30)
            {
                vel = -1.5f;
                TimeRun -= Time.deltaTime;
            }
        }
        if (TimeRun <= 0)
        {
            if (ScrCollision.vidaBoss > 75)
            {
                TimeRun = 4;
                up = !up;
                down = !down;
            }
            if (ScrCollision.vidaBoss <= 75 && ScrCollision.vidaBoss > 30)
            {
                TimeRun = 2;
                up = !up;
                down = !down;
            }
            if (ScrCollision.vidaBoss <= 30)
            {
                TimeRun = 1.5f;
                up = !up;
                down = !down;
            }
        }
    }

}


