using UnityEngine;
using System.Collections;

public class detectCollisions : MonoBehaviour
{
	public static bool[] move;
	public int level;
	public GameObject blockPrefab;
	public GameObject wallPrefab;
	public GameObject shieldPrefab;
	[SerializeField] private moveBullet bullet;
	[SerializeField] private updateUI ui;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        move = new bool[]{true, true, true, true, true, true, true, true};
		level = 1;
		if (gameObject.name.Contains("Win")){
			updateLevel();
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void OnClick(GameObject button){
		if (button.name.Contains("Restart")){
			ui.pauseMenu.SetActive(false);
			updateLevel();
		}
		else if (button.name.Contains("Level Select")){
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
				level = 1;
			}
			else if (button.name.Contains("Level 2")){
				level = 2;
			}
			else if (button.name.Contains("Level 3")){
				level = 3;
			}
			else if (button.name.Contains("Level 4")){
				level = 4;
			}
			else if (button.name.Contains("Level 5")){
				level = 5;
			}
			else if (button.name.Contains("Level 6")){
				level = 6;
			}
			else if (button.name.Contains("Level 7")){
				level = 7;
			}
		}
		updateLevel();
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
			level++;
			for (int i = 0; i < 8; i++){
				move[i] = true;
			}
			updateLevel();
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
	
	void updateLevel(){
		foreach (GameObject block in GameObject.FindGameObjectsWithTag("Block")){
			Destroy(block);
		}
		if (level == 1){
			ui.text1.SetActive(true);
			ui.text2.SetActive(true);
			ui.text3.SetActive(true);
			ui.instructions.SetActive(true);
			ui.instructions.GetComponent<TMPro.TextMeshProUGUI>().text = "Use the red circle to make a path for the blue circle to reach the goal";
			ui.instructions.GetComponent<RectTransform>().sizeDelta = new Vector2(600, 50);
			ui.instructions.transform.position = new Vector3(23, 50, 0);
			GameObject.Find("Escort").transform.position = new Vector3(0, -2, 0);
			GameObject.Find("Shooter").transform.position = new Vector3(0, 0, 0);
			GameObject.Find("Win").transform.position = new Vector3(0, 3, 0);
			Instantiate(blockPrefab, new Vector3(0, 2, 0), blockPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(1, 3, 0), blockPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(-1, 3, 0), blockPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(0, 4, 0), blockPrefab.transform.rotation);
		}
		else if (level == 2){
			ui.text1.SetActive(false);
			ui.text2.SetActive(false);
			ui.text3.SetActive(false);
			ui.instructions.SetActive(true);
			ui.instructions.GetComponent<TMPro.TextMeshProUGUI>().text = "You can only move the light gray blocks";
			ui.instructions.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 50);
			ui.instructions.transform.position = new Vector3(23, 50, 0);
			GameObject.Find("Escort").transform.position = new Vector3(0, -2, 0);
			GameObject.Find("Shooter").transform.position = new Vector3(0, 0, 0);
			GameObject.Find("Win").transform.position = new Vector3(0, 3, 0);
			Instantiate(blockPrefab, new Vector3(0, 2, 0), blockPrefab.transform.rotation);
			Instantiate(wallPrefab, new Vector3(1, 3, 0), wallPrefab.transform.rotation);
			Instantiate(wallPrefab, new Vector3(-1, 3, 0), wallPrefab.transform.rotation);
			Instantiate(wallPrefab, new Vector3(0, 4, 0), wallPrefab.transform.rotation);
		}
		else if (level == 3){
			ui.text1.SetActive(false);
			ui.text2.SetActive(false);
			ui.text3.SetActive(false);
			ui.instructions.SetActive(true);
			ui.instructions.GetComponent<TMPro.TextMeshProUGUI>().text = "You can't move through the light blue blocks, but you can shoot through them";
			ui.instructions.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 50);
			ui.instructions.transform.position = new Vector3(23, 435, 0);
			GameObject.Find("Escort").transform.position = new Vector3(0, -2, 0);
			GameObject.Find("Shooter").transform.position = new Vector3(0, -4, 0);
			GameObject.Find("Win").transform.position = new Vector3(0, 2, 0);
			Instantiate(wallPrefab, new Vector3(0, 1, 0), wallPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(1, 2, 0), blockPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(-1, 2, 0), blockPrefab.transform.rotation);
			Instantiate(wallPrefab, new Vector3(0, 3, 0), wallPrefab.transform.rotation);
			for (int i = -9; i < 10; i++){
				Instantiate(shieldPrefab, new Vector3(i, -3, 0), shieldPrefab.transform.rotation);
			}
		}
		else if (level == 4){
			ui.text1.SetActive(false);
			ui.text2.SetActive(false);
			ui.text3.SetActive(false);
			ui.instructions.SetActive(false);
			GameObject.Find("Escort").transform.position = new Vector3(0, -2, 0);
			GameObject.Find("Shooter").transform.position = new Vector3(0, -4, 0);
			GameObject.Find("Win").transform.position = new Vector3(0, 2, 0);
			Instantiate(blockPrefab, new Vector3(0, 1, 0), blockPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(2, 1, 0), blockPrefab.transform.rotation);
			Instantiate(wallPrefab, new Vector3(1, 2, 0), wallPrefab.transform.rotation);
			Instantiate(wallPrefab, new Vector3(-1, 2, 0), wallPrefab.transform.rotation);
			Instantiate(wallPrefab, new Vector3(0, 3, 0), wallPrefab.transform.rotation);
			for (int i = -9; i < 8; i++){
				Instantiate(shieldPrefab, new Vector3(i, -3, 0), shieldPrefab.transform.rotation);
			}
			for (int i = -2; i < 6; i++){
				Instantiate(shieldPrefab, new Vector3(7, i, 0), shieldPrefab.transform.rotation);
			}
		}
		else if (level == 5){
			ui.text1.SetActive(false);
			ui.text2.SetActive(false);
			ui.text3.SetActive(false);
			ui.instructions.SetActive(false);
			GameObject.Find("Escort").transform.position = new Vector3(0, -2, 0);
			GameObject.Find("Shooter").transform.position = new Vector3(0, -4, 0);
			GameObject.Find("Win").transform.position = new Vector3(0, 2, 0);
			Instantiate(wallPrefab, new Vector3(0, 1, 0), wallPrefab.transform.rotation);
			Instantiate(wallPrefab, new Vector3(-1, 2, 0), wallPrefab.transform.rotation);
			Instantiate(wallPrefab, new Vector3(0, 3, 0), wallPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(1, 2, 0), blockPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(2, 2, 0), blockPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(1, 0, 0), blockPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(2, 0, 0), blockPrefab.transform.rotation);
			for (int i = -9; i < 8; i++){
				Instantiate(shieldPrefab, new Vector3(i, -3, 0), shieldPrefab.transform.rotation);
			}
			for (int i = -2; i < 6; i++){
				Instantiate(shieldPrefab, new Vector3(7, i, 0), shieldPrefab.transform.rotation);
			}
		}
		else if (level == 6){
			ui.text1.SetActive(false);
			ui.text2.SetActive(false);
			ui.text3.SetActive(false);
			ui.instructions.SetActive(false);
			GameObject.Find("Escort").transform.position = new Vector3(0, -2, 0);
			GameObject.Find("Shooter").transform.position = new Vector3(0, -4, 0);
			GameObject.Find("Win").transform.position = new Vector3(0, 2, 0);
			Instantiate(blockPrefab, new Vector3(0, 1, 0), blockPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(1, 2, 0), blockPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(-1, 2, 0), blockPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(-1, 4, 0), blockPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(-1, 0, 0), blockPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(2, 1, 0), blockPrefab.transform.rotation);
			Instantiate(wallPrefab, new Vector3(0, 3, 0), wallPrefab.transform.rotation);
			Instantiate(wallPrefab, new Vector3(1, 3, 0), wallPrefab.transform.rotation);
			Instantiate(wallPrefab, new Vector3(1, 1, 0), wallPrefab.transform.rotation);
			Instantiate(wallPrefab, new Vector3(1, 0, 0), wallPrefab.transform.rotation);
			for (int i = -7; i < 8; i++){
				Instantiate(shieldPrefab, new Vector3(i, -3, 0), shieldPrefab.transform.rotation);
			}
			for (int i = -2; i < 6; i++){
				Instantiate(shieldPrefab, new Vector3(7, i, 0), shieldPrefab.transform.rotation);
			}
			for (int i = -2; i < 6; i++){
				Instantiate(shieldPrefab, new Vector3(-7, i, 0), shieldPrefab.transform.rotation);
			}
		}
		else if (level == 7){
			ui.text1.SetActive(false);
			ui.text2.SetActive(false);
			ui.text3.SetActive(false);
			ui.instructions.SetActive(false);
			GameObject.Find("Escort").transform.position = new Vector3(0, -2, 0);
			GameObject.Find("Shooter").transform.position = new Vector3(0, -4, 0);
			GameObject.Find("Win").transform.position = new Vector3(0, 2, 0);
			Instantiate(blockPrefab, new Vector3(0, 1, 0), blockPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(-1, 2, 0), blockPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(0, 3, 0), blockPrefab.transform.rotation);
			Instantiate(wallPrefab, new Vector3(1, 1, 0), wallPrefab.transform.rotation);
			Instantiate(wallPrefab, new Vector3(-1, 3, 0), wallPrefab.transform.rotation);
			Instantiate(shieldPrefab, new Vector3(1, 2, 0), shieldPrefab.transform.rotation);
			for (int i = -9; i < 8; i++){
				Instantiate(shieldPrefab, new Vector3(i, -3, 0), shieldPrefab.transform.rotation);
			}
			for (int i = -2; i < 6; i++){
				Instantiate(shieldPrefab, new Vector3(7, i, 0), shieldPrefab.transform.rotation);
			}
		}
	}
}
