using UnityEngine;

public class destroyOutOfBounds : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //bounds
		if (transform.position.x > 10){
			Destroy(gameObject);
		}
		else if (transform.position.x < -10){
			Destroy(gameObject);
		}
        if (transform.position.y > 6){
			Destroy(gameObject);
		}
		else if (transform.position.y < -6){
			Destroy(gameObject);
		}
    }
}
