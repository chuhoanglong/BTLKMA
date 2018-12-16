using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVaCham : MonoBehaviour {

	// Use this for initialization
    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Da co va cham");
        }
    }
}
