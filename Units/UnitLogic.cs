using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitLogic : MonoBehaviour
{
    public GameObject shield;
    public GameObject bullet;
    
    private Rigidbody2D rb;
    private float maxSpeed = 5;
    private float rotationSpeed = 3;
    private Vector3 offset;

    float ShotLostTime = 0;
    float speed = 0;
    float RADIAN = Mathf.PI / 180;
    float speedBullet = 20;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        offset = transform.position - shield.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.W)) speed = maxSpeed/*  * Time.deltaTime */;
        else speed = 0;
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(0, 0, rotationSpeed);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(0, 0, -rotationSpeed);

        if(Input.GetKey(KeyCode.Space) && Time.time > (ShotLostTime + 0.1))
        {
            GameObject instance = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
            instance.GetComponent<Rigidbody2D>().velocity = new Vector2(speedBullet * Mathf.Sin(-transform.eulerAngles.z * RADIAN), speedBullet * Mathf.Cos(-transform.eulerAngles.z * RADIAN));
            instance.GetComponent<Transform>().Rotate(0, 0, transform.eulerAngles.z);
            Destroy(instance, 2f);

            ShotLostTime = Time.time;
        }

        Vector2 movement = new Vector2(speed * Mathf.Sin(-transform.eulerAngles.z * RADIAN), speed * Mathf.Cos(-transform.eulerAngles.z * RADIAN));
        rb.velocity = movement;

        shield.transform.position = transform.position + offset;
    }
}
