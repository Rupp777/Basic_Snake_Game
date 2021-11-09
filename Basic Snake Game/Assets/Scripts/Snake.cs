using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    private Vector2 _direction;
    private List<Transform> _segments;

    public Transform segmentPrefab;

    //float xvalue;
    //float yvalue;

    void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        //xvalue = Input.GetAxis("Horizontal");
        //yvalue = Input.GetAxis("Vertical");
        //Vector3 position = transform.position;
        //position.x = xvalue * Time.deltaTime * 5;
        //position.y = yvalue * Time.deltaTime * 5;
        //transform.Translate(position.x, position.y , 0);
        if(Input.GetKeyDown(KeyCode.W))
        {
            _direction = Vector2.up;
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _direction = Vector2.right;
        }

    }

    private void FixedUpdate()
    {
        for(int i = _segments.Count - 1 ; i > 0 ; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x, Mathf.Round(this.transform.position.y) + _direction.y, 0f);
    }

    private void Grow()
    {
        Transform segments = Instantiate(this.segmentPrefab);
        segments.position = _segments[_segments.Count - 1].position;

        _segments.Add(segments);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Food")
        {
            Grow();
        }

        if(collision.tag == "Walls")
        {
            SceneManager.LoadScene(0);
        }
    }
}
