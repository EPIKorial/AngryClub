using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "wall")
        {
            GameObject.Find("PlayerBird").GetComponent<PlayerController>()._score += 100;
            Destroy(this.gameObject);
        }
    }
}
