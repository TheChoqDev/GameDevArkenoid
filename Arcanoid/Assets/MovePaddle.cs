using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour
{

    public float Speed;
	
	// Update is called once per frame
	void Update () {
	    float v = Input.GetAxisRaw("Horizontal");
	    GetComponent<Rigidbody2D>().velocity = new Vector2(v, 0) * Speed;
    }
}
