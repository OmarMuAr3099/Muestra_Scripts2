using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ----------------------------------------------------------------------------------
/// DESCRIPCIÓ
///         Script utilitzat per controlar el player
/// AUTOR:  Omar Muñoz
/// VERSIÓ: 1.0
/// ----------------------------------------------------------------------------------
/// </summary>
/// 
public class ScrPlayer : MonoBehaviour
{
    [SerializeField]
    float velocitat = 1f;              

    [SerializeField] float cadencia = 1f; 
    float crono = 0f;	  

    float timePowerUp = 0;

    Animator Anim;

    float vida = ScrCollision.vidaPlayer;

    [SerializeField]
    Transform[] canons;

    [SerializeField]
    GameObject beam;

    Vector2 movi = new Vector2();   
    Rigidbody2D rb;

    [SerializeField]
    AudioSource soM;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        Anim = GetComponent<Animator>();
        Time.timeScale = 1;
        
        soM = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        movi.x = Input.GetAxis("Horizontal") * velocitat;  
        movi.y = Input.GetAxis("Vertical") * velocitat;
        if (rb.velocity.x != 0) Anim.SetBool("swim", true);
        if (rb.velocity.x == 0) Anim.SetBool("swim", false);
        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
           
        }
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            
        }

        if (Input.GetKeyDown(KeyCode.Space) && crono > cadencia) Dispara();
       
        if (Input.GetKeyDown(KeyCode.Space)) crono = cadencia;
        crono += Time.deltaTime;
        
        if (timePowerUp < 0) SetExtraMissils(false);
        timePowerUp -= Time.deltaTime;

    }

    void FixedUpdate()
    {
        rb.velocity = movi;   
    }

    void Dispara()
    {


        foreach (Transform Beam in canons)
            if (Beam.gameObject.activeSelf)
            {
                GameObject bala = Instantiate(beam, Beam.position, Beam.rotation);
                if (transform.localScale == new Vector3(-1, 1, 1))
                {
                    bala.GetComponent<ScrShot>().velocity = -5;
                }
                if (transform.localScale == new Vector3(1, 1, 1))
                {
                    bala.GetComponent<ScrShot>().velocity = 5;
                }
            }
        crono = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "vida")
        {
            ScrCollision.vidaPlayer= ScrCollision.vidaPlayer+ 5;
            if (ScrCollision.vidaPlayer > 10) ScrCollision.vidaPlayer = 10;
            Destroy(collision.gameObject);
        }

        if (collision.tag == "powerUp")
        {
            SetExtraMissils(true);
            timePowerUp = 10;
            Destroy(collision.gameObject);
           
        }
        
    
    }

    void SetExtraMissils(bool estat)
    {
        canons[1].gameObject.SetActive(estat);
        canons[2].gameObject.SetActive(estat);

    }

    void Muerte()
    {
        if (soM) AudioSource.PlayClipAtPoint(soM.clip, Camera.main.transform.position);

        Anim.SetBool("death", true);
    }

    void ParaTiempo()
    {
        Time.timeScale = 0;
    }
}
