using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public float timeTillReturn;
    public Transform player;
    public int timesTouchedPlayer = 0;
    public int damage = 3;
    public EnemyMelee TakeHit;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeTillReturn = timeTillReturn - Time.deltaTime;
        if (timeTillReturn <= 0)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, force * Time.deltaTime);
        }
        if (timesTouchedPlayer >= 3)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            timeTillReturn = 0;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            timesTouchedPlayer = timesTouchedPlayer + 1;
        }
        if (collision.gameObject.CompareTag("EnemyMelee"))
        {
            collision.gameObject.GetComponent<EnemyMelee>().TakeHit(damage);
        }
        if (collision.gameObject.CompareTag("EnemyFlying"))
        {
            collision.gameObject.GetComponent<EnemyFlyingRanged>().TakeHit(damage);
        }
        if (collision.gameObject.CompareTag("EnemyRanged"))
        {
            collision.gameObject.GetComponent<RangedEnemy>().TakeHit(damage);
        }
    }
}
