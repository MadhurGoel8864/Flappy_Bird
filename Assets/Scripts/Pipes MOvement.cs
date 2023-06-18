using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesMOvement : MonoBehaviour
{
    public float speed = 2f;
    private float leftEdge;
    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x -1    ;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime; 

        if(transform.position.x < leftEdge)
        {
            //Invoke(nameof(dest_obj), 1f);
            Destroy(gameObject);    
        }
    }
}
