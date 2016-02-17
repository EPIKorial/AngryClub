using UnityEngine;
using System.Collections;

public class DestuManager : MonoBehaviour {

    public float seuilDegats;
    public int points;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "ground")
        {
            //Debug.Log(this.gameObject.name + "got hit by " + coll.gameObject.name + " and the force was : " + coll.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude.ToString() + " / " + seuilDegats.ToString());
            if (coll.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude > seuilDegats)
            {
                GameObject.Find("PlayerBird").GetComponent<PlayerController>()._score += points;
                Destroy(this.gameObject);
            }
        }
    }
}
