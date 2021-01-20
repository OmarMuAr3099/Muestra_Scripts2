using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrApuntar : MonoBehaviour
{
    [SerializeField] GameObject apuntar;
    static public bool finalFase = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(finalFase == true)
        {
            float velocitat = 3;
            if (apuntar)
            {
            Vector3 offset = apuntar.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, offset);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation * Quaternion.Euler(0, 0, 270), velocitat * Time.deltaTime);
            }
        }
    }
}
