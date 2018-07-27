using UnityEngine;

public class Platform : MonoBehaviour {

    public float speed;
    public int direction;
    private float cameraWidth;


    private void Start()
    {
        cameraWidth = Mathf.FloorToInt(Camera.main.aspect * Camera.main.orthographicSize);
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
        CheckOOB();
    }

    private void CheckOOB()
    {
        if (direction == -1)
        {
            if (transform.position.x < -cameraWidth - GetComponent<SpriteRenderer>().bounds.size.x)
            {
                Destroy(gameObject);
            }
        }
        else if (direction == 1)
        {
            if (transform.position.x > cameraWidth + GetComponent<SpriteRenderer>().bounds.size.x)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Movement()
    {
        Vector2 velocity = Vector2.zero;
        velocity.x = speed * direction * Time.deltaTime;
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

}
