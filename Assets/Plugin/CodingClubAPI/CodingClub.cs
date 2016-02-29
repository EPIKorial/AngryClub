using UnityEngine;
using System.Collections;

namespace CodingClubAPI
{
    public class CodingClub : MonoBehaviour
    {
        static public void Destroy_on_collision(GameObject _this, Collision2D coll, float seuilDegats, int points)
        {
            if (coll.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude > seuilDegats)
                Destroy(_this);
        }

        static public void Render_line(GameObject _this, GameObject joint)
        {
                _this.GetComponent<LineRenderer>().enabled = true;
                _this.GetComponent<LineRenderer>().SetWidth(0.05f, 0.05f);
                _this.GetComponent<LineRenderer>().SetPosition(0, _this.transform.position);
                _this.GetComponent<LineRenderer>().SetPosition(1, joint.transform.position);
        }

        static public void Hide_line(GameObject _this)
        {
              _this.GetComponent<LineRenderer>().enabled = false;
        }

        static public void Shot(GameObject _this, GameObject joint)
        {
            _this.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            _this.GetComponent<Rigidbody2D>().isKinematic = false;
            var heading = _this.transform.position - joint.transform.position;
            _this.GetComponent<Rigidbody2D>().AddForce(-(heading * 5), ForceMode2D.Impulse);
        }

        static public void Follow_mouse(GameObject _this)
        {
            _this.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -1);
        }
       
        static public void Level_Reload(string _tag)
        {
            if (!GameObject.FindGameObjectWithTag(_tag))
                Application.LoadLevel(0);
        }

        static public RaycastHit2D Mouse_pos()
        {
            return Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        }

        static public bool is_moving(bool played, GameObject _this)
        {
            if (played && _this.GetComponent<Rigidbody2D>().velocity == new Vector2(0, 0))
                return true;
            else
                return false;
        }

        static public void restart_player(GameObject _this, Vector2 oldPos)
        {
            _this.transform.position = new Vector3(oldPos.x, oldPos.y, -1);
            _this.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }
}
