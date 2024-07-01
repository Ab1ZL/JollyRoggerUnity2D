using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyExplosion;
    public float speed;
    [SerializeField] private GameObject enemyBulletPrefab;
    [SerializeField] private Transform shootOrigin;
    public int puntos;
    public AudioSource enemyAudioShoot;
    public AudioSource enemyAudioExplosion;

    public float livingTime = 0.2f;
    public SpriteRenderer myRenderer;
    public Collider2D myCollider;

    private void Start()
    {
        InvokeRepeating("DoShoot", 1f, 3f);
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * -1, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            /*FindObjectOfType<PlayerController>().AddPoints(puntos);*/
            PointsCount.Instance.AddPoints(puntos);
            Instantiate(enemyExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject, livingTime);
            Destroy(collision.gameObject);
            enemyAudioExplosion.Play();
            if (myRenderer != null & myCollider != null)
            {
                myRenderer.enabled = false;
                myCollider.enabled = false;
            }
        }
    }

    /*private void DoShoot()
    {
        Instantiate(enemyBulletPrefab, shootOrigin.position, Quaternion.identity);
    }*/

    private void DoShoot()
    {
        if (enemyBulletPrefab !=null)
        {
            enemyAudioShoot.Play();
            Instantiate(enemyBulletPrefab, shootOrigin.position, Quaternion.identity);
        }
    }

}
