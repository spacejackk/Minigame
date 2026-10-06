using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
	public InputAction moveAction;
	public InputAction fireAction;
	public Vector2 moveInput;
	public GameObject projectilePrefab;
	private bool time = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable();
		if (gameObject.name.Contains("Shooter")){
			fireAction.Enable();
		}
    }

    // Update is called once per frame
    void Update()
    {
        //player input
        moveInput = moveAction.ReadValue<Vector2>();
		if (time == false && (moveInput.x != 0 || moveInput.y != 0)){
			time = true;
			Invoke("move", 0.1f);
		}
		if (moveInput.x > 0){
			transform.rotation = Quaternion.LookRotation(Vector3.right) * Quaternion.Euler(0, 0, 90);
		}
		else if (moveInput.x < 0){
			transform.rotation = Quaternion.LookRotation(Vector3.left) * Quaternion.Euler(0, 0, 90);
		}
		else if (moveInput.y > 0){
			transform.rotation = Quaternion.LookRotation(Vector3.up);
		}
		else if (moveInput.y < 0){
			transform.rotation = Quaternion.LookRotation(Vector3.down);
		}
		//bounds
		if (transform.position.z != 0){
			transform.position = new Vector3(transform.position.x, transform.position.y, 0);
		}
		if (transform.position.x < -8){
			transform.position = new Vector3(-8, transform.position.y, 0);
		}
		else if (transform.position.x > 8){
			transform.position = new Vector3(8, transform.position.y, 0);
		}
		if (transform.position.y < -5){
			transform.position = new Vector3(transform.position.x, -5, 0);
		}
		else if (transform.position.y > 5){
			transform.position = new Vector3(transform.position.x, 5, 0);
		}
		//firing bullets
		if (fireAction.triggered){
			Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
		}
    }
	
	void move(){
		if (gameObject.name.Contains("Shooter")){
			if (moveInput.x > 0 && detectCollisions.move[0] == true){
				transform.position = new Vector3(transform.position.x + 1, transform.position.y, 0);
			}
			else if (moveInput.x < 0 && detectCollisions.move[1] == true){
				transform.position = new Vector3(transform.position.x - 1, transform.position.y, 0);
			}
			else if (moveInput.y > 0 && detectCollisions.move[2] == true){
				transform.position = new Vector3(transform.position.x, transform.position.y + 1, 0);
			}
			else if (moveInput.y < 0 && detectCollisions.move[3] == true){
				transform.position = new Vector3(transform.position.x, transform.position.y - 1, 0);
			}
		}
		else if (gameObject.name.Contains("Escort")){
			if (moveInput.x > 0 && detectCollisions.move[4] == true){
				transform.position = new Vector3(transform.position.x + 1, transform.position.y, 0);
			}
			else if (moveInput.x < 0 && detectCollisions.move[5] == true){
				transform.position = new Vector3(transform.position.x - 1, transform.position.y, 0);
			}
			else if (moveInput.y > 0 && detectCollisions.move[6] == true){
				transform.position = new Vector3(transform.position.x, transform.position.y + 1, 0);
			}
			else if (moveInput.y < 0 && detectCollisions.move[7] == true){
				transform.position = new Vector3(transform.position.x, transform.position.y - 1, 0);
			}
		}
		time = false;
	}
}
