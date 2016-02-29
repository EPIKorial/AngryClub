using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using CodingClubAPI;

public class PlayerController : MonoBehaviour
{
    public GameObject joint;
    private bool follow;
    private bool drawLine;
    private bool played;

    private Vector2 oldPos;
    private RaycastHit2D hit;

    void Start()
    {
        oldPos = transform.position;
        drawLine = true;
        played = false;
        follow = false;
    }

    void Update()
    {
        if (drawLine)
            CodingClub.Render_line(this.gameObject, joint.gameObject);

        CodingClub.Level_Reload("enemy");

        hit = CodingClub.Mouse_pos();

        if (hit.collider != null && hit.transform.gameObject == this.gameObject && !played)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                follow = true;

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                played = true;
                follow = false;
                drawLine = false;
                CodingClub.Shot(this.gameObject, joint.gameObject);
                CodingClub.Hide_line(this.gameObject);
            }
        }


        if (Input.GetKey(KeyCode.Mouse0) && follow)
            CodingClub.Follow_mouse(this.gameObject);

        if (CodingClub.is_moving(played, this.gameObject))
        {
            CodingClub.restart_player(this.gameObject, oldPos);
            drawLine = true;
            played = false;
        }
    }
}