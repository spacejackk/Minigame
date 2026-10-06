using UnityEngine;
using System.Collections;

public class detectCollisions : MonoBehaviour
{
	public static bool[] move;
	[SerializeField] private moveBullet bullet;
	[SerializeField] private updateUI ui;
	[SerializeField] private updateLevel levels;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        move = new bool[]{true, true, true, true, true, true, true, true};
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void OnClick(GameObject button){
		if (button.name.Contains("Restart")){
			ui.pauseMenu.SetActive(false);
			if (levels.level >= 10){
				levels.level = 1;
			}
			levels.update();
		}
		else if (button.name.Contains("Select")){
			ui.pause.SetActive(false);
			ui.levels.SetActive(true);
		}
		else if (button.name.Contains("Back")){
			ui.pause.SetActive(true);
			ui.levels.SetActive(false);
		}
		else if (button.name.Contains("Level")){
			ui.pause.SetActive(true);
			ui.levels.SetActive(false);
			ui.pauseMenu.SetActive(false);
			if (button.name.Contains("Level 1")){
				levels.level = 1;
			}
			else if (button.name.Contains("Level 2")){
				levels.level = 2;
			}
			else if (button.name.Contains("Level 3")){
				levels.level = 3;
			}
			else if (button.name.Contains("Level 4")){
				levels.level = 4;
			}
			else if (button.name.Contains("Level 5")){
				levels.level = 5;
			}
			else if (button.name.Contains("Level 6")){
				levels.level = 6;
			}
			else if (button.name.Contains("Level 7")){
				levels.level = 7;
			}
			else if (button.name.Contains("Level 8")){
				levels.level = 8;
			}
			else if (button.name.Contains("Level 9")){
				levels.level = 9;
			}
			levels.update();
		}
	}
	
	void OnTriggerEnter(Collider other){
		Vector3 direction = (other.transform.position - transform.position).normalized;
		if (gameObject.name.Contains("Block") && other.gameObject.name.Contains("Bullet")){
			bool go = true;
			if (direction.x < 0){
				foreach (GameObject block in GameObject.FindGameObjectsWithTag("Block")){
					if (block.transform.position.y == transform.position.y && block.transform.position.x == transform.position.x + 1){
						go = false;
					}
				}
				foreach (GameObject block in GameObject.FindGameObjectsWithTag("Player")){
					if (block.transform.position.y == transform.position.y && block.transform.position.x == transform.position.x + 1){
						go = false;
					}
				}
				if (go == true){
					transform.position = new Vector3(transform.position.x + 1, transform.position.y, 0);
				}
			}
			else if (direction. x > 0){
				foreach (GameObject block in GameObject.FindGameObjectsWithTag("Block")){
					if (block.transform.position.y == transform.position.y && block.transform.position.x == transform.position.x - 1){
						go = false;
					}
				}
				foreach (GameObject block in GameObject.FindGameObjectsWithTag("Player")){
					if (block.transform.position.y == transform.position.y && block.transform.position.x == transform.position.x - 1){
						go = false;
					}
				}
				if (go == true){
					transform.position = new Vector3(transform.position.x - 1, transform.position.y, 0);
				}
			}
			else if (direction.y < 0){
				foreach (GameObject block in GameObject.FindGameObjectsWithTag("Block")){
					if (block.transform.position.x == transform.position.x && block.transform.position.y == transform.position.y + 1){
						go = false;
					}
				}
				foreach (GameObject block in GameObject.FindGameObjectsWithTag("Player")){
					if (block.transform.position.x == transform.position.x && block.transform.position.y == transform.position.y + 1){
						go = false;
					}
				}
				if (go == true){
					transform.position = new Vector3(transform.position.x, transform.position.y + 1, 0);
				}
			}
			else if (direction. y > 0){
				foreach (GameObject block in GameObject.FindGameObjectsWithTag("Block")){
					if (block.transform.position.x == transform.position.x && block.transform.position.y == transform.position.y - 1){
						go = false;
					}
				}
				foreach (GameObject block in GameObject.FindGameObjectsWithTag("Player")){
					if (block.transform.position.x == transform.position.x && block.transform.position.y == transform.position.y - 1){
						go = false;
					}
				}
				if (go == true){
					transform.position = new Vector3(transform.position.x, transform.position.y - 1, 0);
				}
			}
			Destroy(other.gameObject);
		}
		else if (gameObject.name.Contains("Wall") && other.gameObject.name.Contains("Bullet")){
			Destroy(other.gameObject);
		}
		else if (gameObject.name.Contains("Win") && other.gameObject.name.Contains("Escort")){
			foreach (GameObject block in GameObject.FindGameObjectsWithTag("Block")){
				Destroy(block);
			}
			levels.level++;
			for (int i = 0; i < 8; i++){
				move[i] = true;
			}
			levels.update();
		}
	}
	
	void OnTriggerStay(Collider other){
		Vector3 direction = (other.transform.position - transform.position).normalized;
		if ((gameObject.name.Contains("Block") || gameObject.name.Contains("Wall") || gameObject.name.Contains("Shield")) && other.gameObject.name.Contains("Shooter")){
			//right
			if (direction.x < 0){
				move[0] = false;
			}
			//left
			else if (direction. x > 0){
				move[1] = false;
			}
			//up
			else if (direction.y < 0){
				move[2] = false;
			}
			//down
			else if (direction. y > 0){
				move[3] = false;
			}
		}
		else if ((gameObject.name.Contains("Block") || gameObject.name.Contains("Wall") || gameObject.name.Contains("Shield")) && other.gameObject.name.Contains("Escort")){
			//right
			if (direction.x < 0){
				move[4] = false;
			}
			//left
			else if (direction. x > 0){
				move[5] = false;
			}
			//up
			else if (direction.y < 0){
				move[6] = false;
			}
			//down
			else if (direction. y > 0){
				move[7] = false;
			}
		}
	}
	
	void OnTriggerExit(Collider other){
		Vector3 direction = (other.transform.position - transform.position).normalized;
		if ((gameObject.name.Contains("Block") || gameObject.name.Contains("Wall") || gameObject.name.Contains("Shield")) && other.gameObject.name.Contains("Shooter")){
			for (int i = 0; i < 4; i++){
				move[i] = true;
			}
		}
		else if ((gameObject.name.Contains("Block") || gameObject.name.Contains("Wall") || gameObject.name.Contains("Shield")) && other.gameObject.name.Contains("Escort")){
			for (int i = 4; i < 8; i++){
				move[i] = true;
			}
		}
	}
}
