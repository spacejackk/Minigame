using UnityEngine;

public class moveBullet : MonoBehaviour
{
	public Transform playerTrans;
	public float speed;
	private Vector3 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTrans = GameObject.Find("Shooter").transform;
    }

    // Update is called once per frame
    void Update()
    {
		if (transform.position == playerTrans.position){
			if (playerTrans.rotation == Quaternion.LookRotation(Vector3.right) * Quaternion.Euler(0, 0, 90)){
				direction = Vector3.right;
				transform.rotation = Quaternion.LookRotation(Vector3.up);
			}
			else if (playerTrans.rotation == Quaternion.LookRotation(Vector3.left) * Quaternion.Euler(0, 0, 90)){
				direction = Vector3.left;
				transform.rotation = Quaternion.LookRotation(Vector3.down);
			}
			else if (playerTrans.rotation == Quaternion.LookRotation(Vector3.up)){
				direction = Vector3.right;
				transform.rotation = Quaternion.LookRotation(Vector3.right) * Quaternion.Euler(0, 0, 90);
			}
			else if (playerTrans.rotation == Quaternion.LookRotation(Vector3.down)){
				direction = Vector3.left;
				transform.rotation = Quaternion.LookRotation(Vector3.left) * Quaternion.Euler(0, 0, 90);
			}
		}
        transform.Translate(direction * Time.deltaTime * speed);
		if (transform.position.z != 0.1f){
			transform.position = new Vector3(transform.position.x, transform.position.y, 0);
		}
    }
}
