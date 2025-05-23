using UnityEngine;

public class Cat : MonoBehaviour
{

    public RectTransform front;

    float full = 5.0f;
    float energy = 0.0f;

    public GameObject fullCat;
    public GameObject hungryCat;

    public int type;

    float speed = 0.05f;

    bool isFull = false;

    private void Start()
    {
        float x = Random.Range(-9.0f, 9.0f);
        float y = 30f;
        transform.position = new Vector3(x, y, 0);

        if(type == 1)
        {
            speed = 0.05f;
            full = 5f;
        } else if(type == 2)
        {
            speed = 0.02f;
            full = 10f;
        }
        else if(type == 3)
        {
            speed = 0.1f;
            full = 2f;

        }

    }

    // Update is called once per frame
    void Update()
    {
        if(energy < full)
        {
            transform.position += Vector3.down * speed;

            if(transform.position.y < -16.0f)
            {
                GameManager.instance.GameOver();
            }
        }
        else
        {
            if (transform.position.x > 0)
            {
                transform.position += Vector3.right *speed;
            }
            else
            {
                transform.position += Vector3.left * speed;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Food"))
        {
            if(energy < full)
            {
                energy += 1.0f;
                front.localScale = new Vector3(energy / full, 1.0f, 1.0f);
                Destroy(collision.gameObject);
                if(energy == full)
                {
                    if(!isFull)
                    {
                        isFull = true;
                        hungryCat.SetActive(false);
                        fullCat.SetActive(true);
                        Destroy(gameObject, 5f);
                        GameManager.instance.AddScore();
                    }
                 
                }
            }

        }
    }

}
