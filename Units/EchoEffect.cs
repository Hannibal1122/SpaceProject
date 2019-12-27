using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEffect : MonoBehaviour
{
    public float time;
    public float startTime;
    public GameObject echo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time <= 0)
        {
            GameObject instance = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
            Destroy(instance, 2f);
            time = startTime;
        }
        else time -= Time.deltaTime;
    }
}
