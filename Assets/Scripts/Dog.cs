using UnityEngine;

public class Dog : MonoBehaviour
{

    public GameObject food;

    private void Start()
    {
        InvokeRepeating("MakeFood", 0f, 0.2f);
    }

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float x = mousePos.x;

        if(x > 8.5f)
        {
            x = 8.5f;
        }
        if(x < -8.5f)
        {
            x = -8.5f;
        }

        transform.position = new Vector3(x, transform.position.y, 0);
    }

    void MakeFood()
    {
        float x = transform.position.x;
        float y = transform.position.y + 2.0f;
        Instantiate(food, new Vector3(x,y,0), Quaternion.identity);
    }
}
