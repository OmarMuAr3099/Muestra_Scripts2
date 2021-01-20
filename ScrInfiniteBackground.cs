using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrInfiniteBackground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnBecameInvisible()
    {
        // la imagen mide 256 pixeles * escala 5.5 y hay 4
        transform.Translate(2.56f * 5.5f * 4, 0f, 0f);
    }
}
