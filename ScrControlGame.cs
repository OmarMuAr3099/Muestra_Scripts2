using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ----------------------------------------------------------------------------------
/// DESCRIPCIÓ: Script associat per als controls generals del joc
/// AUTOR:  Lau
/// VERSIÓ: 1.0
/// APUNT: no sé perquè eñs PecesRestantes no funciona bé.
/// ----------------------------------------------------------------------------------
/// </summary>
/// 

public class ScrControlGame : MonoBehaviour
{
    public Transform[] spawns;
    public GameObject[] enemigos;
    int randomSpawnPoint, randomEnemy;
    public bool spawnAllowed;
    public float velSpawn=2;
    public static int round = 1;
    public static float roundTime = 0;
    float waitTime;
    [SerializeField]

    public GameObject Tiempo;
    public GameObject Ronda;
    public GameObject Perdiste;

    public GameObject So;
    [SerializeField] GameObject vida1, vida2, vida3;

    GameObject[] Enemigos;
    

    float canvasTime;

    public static int PecesRestantes = 0; //peces que hay en la escena

    private void Awake()
    {

        PecesRestantes = 0;
    }

    // Start is called before the first frame update
    void Start()
    {

        round = 1;
        ScrCollision.vidaPlayer = 10;
        roundTime = 0;
        spawnAllowed = true;
        InvokeRepeating("SpawnEnemigo", 0f, velSpawn);
        Tiempo.SetActive(true);
        vida1.SetActive(true);
        vida2.SetActive(false);
        vida3.SetActive(false);
        Perdiste.SetActive(false);
        So.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (ScrCollision.vidaPlayer <= 0)
        {
            Perdiste.SetActive(true);
            So.SetActive(false);
        }
        if (round == 1)
        {
            roundTime += Time.deltaTime;
            Enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
            PecesRestantes = Enemigos.Length;
            Ronda.SetActive(true);
            canvasTime += Time.deltaTime;
            if(canvasTime>=2) Ronda.SetActive(false);


        }


            if (roundTime >= 60)
        {
            spawnAllowed = false;

            if (Enemigos.Length == 0)
            {
                waitTime += Time.deltaTime;
                Tiempo.SetActive(false);
            }

            if (waitTime >= 10) 
            {
                round++;
                spawnAllowed = true;
                roundTime = 0;
                waitTime = 0;
                canvasTime = 0;
            }
        }
        if (round == 2)
        {
            Tiempo.SetActive(true);
            vida2.SetActive(true);
            roundTime += Time.deltaTime;
            velSpawn = 1;
            Enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
            PecesRestantes = Enemigos.Length;
            Ronda.SetActive(true);
            canvasTime += Time.deltaTime;
            if (canvasTime >= 2) Ronda.SetActive(false);

            if (roundTime >= 60)
            {
                spawnAllowed = false;
                

                if (Enemigos.Length == 0)
                {

                    waitTime += Time.deltaTime;
                    Tiempo.SetActive(false);
                }
                if (waitTime >= 10)
                {
                    round++;
                    spawnAllowed = true;
                    roundTime = 0;
                    waitTime = 0;
                    canvasTime = 0;
                }
            }
        }
        if (round == 3)
        {
            Tiempo.SetActive(true);
            vida3.SetActive(false);
            roundTime += Time.deltaTime;
            velSpawn = 0.5f;
            Enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
            PecesRestantes = Enemigos.Length;
            Ronda.SetActive(true);
            canvasTime += Time.deltaTime;
            if (canvasTime >= 2) Ronda.SetActive(false);

            if (roundTime >= 60)
            {
                spawnAllowed = false;
                


                if (Enemigos.Length == 0)
                {
                    waitTime += Time.deltaTime;
                    Tiempo.SetActive(false);
                }
                if (waitTime >= 10)
                {
                    roundTime = 0;
                    SceneManager.LoadScene("Boss");
                }
            }
        }
    }
    
    void SpawnEnemigo()
    {
        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawns.Length);
            randomEnemy = Random.Range(0, enemigos.Length);
            Instantiate(enemigos[randomEnemy], spawns[randomSpawnPoint].position, Quaternion.identity);
        }
    }

    static public bool EsVisibleDesde(Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }

}
