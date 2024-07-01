using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    GameObject sceneTransicion; 
    SceneTransicion sceneTransicionScript;


    void Start()
    {
        sceneTransicion = GameObject.Find("SceneTransicion");
        sceneTransicionScript = sceneTransicion.GetComponent<SceneTransicion>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        sceneTransicionScript.LoadNextLevel();
    }

}
