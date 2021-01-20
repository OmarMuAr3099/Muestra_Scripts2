using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrIntro : MonoBehaviour
{
   public void Enter()
    {
        SceneManager.LoadScene("Menu");
    }

}
