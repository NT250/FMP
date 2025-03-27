using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D BulletRB;
    // Start is called before the first frame update
    void Start()
    {
        BulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        BulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject,2);
    }
}
