using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    public float speed;
    public Transform shootOrigin;
    public GameObject playerBullet;
    public float xMin, xMax, yMin, yMax;
    public GameObject playerExplosion;
    public int life = 3;
    /*public int playerScoreNave;*/
    public AudioSource playerAudioShoot;
    public AudioSource playerAudioHit;
    public AudioSource playerAudioExplosion;


    private SpriteRenderer myRenderer;

    private void Awake()
    {
        myRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAudioShoot.Play();
            Instantiate(playerBullet, shootOrigin.transform.position, Quaternion.identity);
        }

        float x = Mathf.Clamp(transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = new Vector3(x, y, -5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBullet" || collision.tag == "Enemy")
        {
            StartCoroutine("VisualFeedback");
            life = life - 1;
            playerAudioHit.Play();
            PointsCount.Instance.playerHeartIU.sizeDelta = new Vector2(PointsCount.Instance.heartSize * life, PointsCount.Instance.heartSize);
            if (life == 0)
            {
                Instantiate(playerExplosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
                playerAudioExplosion.Play();
            }
            /*Instantiate(playerExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);*/
        }
    }

    private IEnumerator VisualFeedback()
    {
        myRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        myRenderer.color = Color.white;
    }

    /*public void AddPoints(int shipPoints)
    {
        playerScoreNave += shipPoints;
    }*/
}
