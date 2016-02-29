using UnityEngine;
using System.Collections;
using CodingClubAPI;

public class DestuManager : MonoBehaviour {

    public float seuilDegats;
    public int points;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "ground")
        {
            CodingClub.Destroy_on_collision(this.gameObject, coll, seuilDegats, points);
        }
    }
}
