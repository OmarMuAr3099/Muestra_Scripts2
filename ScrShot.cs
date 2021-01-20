using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrShot : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public float velocity = 5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * Time.deltaTime, 0, 0);
    }
    void OnBecameInvisible()
    {
        Destruccio();
    }
  
    void Destruccio() 
    {
        Destroy(gameObject);
    }

}
