using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    void onEnable()
    {
        SceneManager.LoadScene("SampleScene",LoadSceneMode.Single);
        
    }


}
