using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text score;
    public int _score;

    public Material mat;
    private LineRenderer lineRenderer;

    public GameObject bird;
    public GameObject joint;
    private bool follow;
    private bool drawLine;
    private bool played;

    public float force;
    public Rigidbody2D rb2D;

    private Vector2 oldPos;

    void Start()
    {
        oldPos = transform.position;
        rb2D = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.material = mat;
        lineRenderer.SetWidth(0.05f, 0.05f);
        drawLine = true;
        played = false;
    }

    void Update()
    {
        score.text = _score.ToString();
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (lineRenderer && drawLine)
        {
            lineRenderer.SetPosition(0, bird.transform.position);
            lineRenderer.SetPosition(1, joint.transform.position);
        }

        if (hit.collider != null && hit.transform.gameObject == bird && !played)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                follow = true;
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                played = true;
                follow = false;
                drawLine = false;
                rb2D.velocity = new Vector3(0, 0, 0);
                GetComponent<Rigidbody2D>().isKinematic = false;
                var heading = transform.position - joint.transform.position;
                rb2D.AddForce(-(heading * force), ForceMode2D.Impulse);
                lineRenderer.SetPosition(0, bird.transform.position);
                lineRenderer.SetPosition(1, bird.transform.position);
            }
        }


        if (Input.GetKey(KeyCode.Mouse0) && follow)
        {
             bird.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -1);
        }

        if (played && rb2D.velocity == new Vector2(0, 0))
        {
            StartCoroutine(ReCharge());
        }

        if (!GameObject.FindGameObjectWithTag("enemy"))
            StartCoroutine(Reload());
    }

    IEnumerator ReCharge()
    {
        yield return new WaitForSeconds(0.1f);
        transform.position = new Vector3(oldPos.x, oldPos.y, -1);
        GetComponent<Rigidbody2D>().isKinematic = true;
        drawLine = true;
        played = false;
    }

    IEnumerator Reload()
    { 
        yield return new WaitForSeconds(2);
        Application.LoadLevel(0);
    }
}