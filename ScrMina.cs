using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrMina : MonoBehaviour
{
    [SerializeField] GameObject explosio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(explosio, transform.position, transform.rotation);

            
            Destroy(gameObject);
        }

    }
}
