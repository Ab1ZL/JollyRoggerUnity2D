using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsCount : MonoBehaviour
{

    public int playerScoreNave;
    public static PointsCount Instance;
    public RectTransform playerHeartIU;
    public SpriteRenderer playerRenderer;
    public float heartSize = 16f;
    public TextMeshProUGUI textEnemyCount;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    public void AddPoints(int shipPoints)
    {
        playerScoreNave += shipPoints; 
    }

    private void Update()
    {
        textEnemyCount.text = playerScoreNave.ToString();
    }
}
