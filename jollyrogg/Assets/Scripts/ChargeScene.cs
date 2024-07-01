using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChargeScene : MonoBehaviour
{
    public float startTime;
    public float endTime;
    public string scene;

    // Update is called once per frame
    private void Update()
    {
        if (FindObjectOfType<PlayerController>() != null)
        {
            startTime = 0;
        }
        else
        {
            startTime += Time.deltaTime;
            if (startTime >= endTime)
            {
                SceneManager.LoadScene(scene);
                PointsCount.Instance.playerScoreNave = 0;
                PointsCount.Instance.playerHeartIU.sizeDelta = new Vector2(48, PointsCount.Instance.heartSize);
            }
        }
        
    }
}
