using UnityEngine;

public class updateLevel : MonoBehaviour
{
	public int level;
	public GameObject blockPrefab;
	public GameObject wallPrefab;
	public GameObject shieldPrefab;
	[SerializeField] private updateUI ui;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		level = 1;
        update();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void update(){
		foreach (GameObject block in GameObject.FindGameObjectsWithTag("Block")){
			Destroy(block);
		}
		if (level < 10){
			ui.pauseText.GetComponent<TMPro.TextMeshProUGUI>().text = "Paused";
			ui.text1.SetActive(false);
			ui.text2.SetActive(false);
			ui.text3.SetActive(false);
			ui.instructions.SetActive(false);
			ui.buttonText.GetComponent<TMPro.TextMeshProUGUI>().text = "Restart Level";
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
			GameObject.Find("Escort").transform.position = new Vector3(0, -2, 0);
			GameObject.Find("Shooter").transform.position = new Vector3(0, -4, 0);
			GameObject.Find("Win").transform.position = new Vector3(0, 2, 0);
			Instantiate(blockPrefab, new Vector3(0, 1, 0), blockPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(2, 1, 0), blockPrefab.transform.rotation);
			Instantiate(wallPrefab, new Vector3(1, 2, 0), wallPrefab.transform.rotation);
			Instantiate(wallPrefab, new Vector3(-1, 2, 0), wallPrefab.transform.rotation);
			Instantiate(wallPrefab, new Vector3(0, 3, 0), wallPrefab.transform.rotation);
			for (int i = -9; i < 7; i++){
				Instantiate(shieldPrefab, new Vector3(i, -3, 0), shieldPrefab.transform.rotation);
			}
			for (int i = -2; i < 6; i++){
				Instantiate(shieldPrefab, new Vector3(6, i, 0), shieldPrefab.transform.rotation);
			}
		}
		else if (level == 5){
			GameObject.Find("Escort").transform.position = new Vector3(0, -2, 0);
			GameObject.Find("Shooter").transform.position = new Vector3(0, -4, 0);
			GameObject.Find("Win").transform.position = new Vector3(0, 2, 0);
			Instantiate(blockPrefab, new Vector3(0, 1, 0), blockPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(1, 2, 0), blockPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(-1, 2, 0), blockPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(-1, 0, 0), blockPrefab.transform.rotation);
			Instantiate(wallPrefab, new Vector3(0, 3, 0), wallPrefab.transform.rotation);
			Instantiate(wallPrefab, new Vector3(1, 3, 0), wallPrefab.transform.rotation);
			Instantiate(wallPrefab, new Vector3(1, 1, 0), wallPrefab.transform.rotation);
			Instantiate(wallPrefab, new Vector3(1, 0, 0), wallPrefab.transform.rotation);
			for (int i = -6; i < 7; i++){
				Instantiate(shieldPrefab, new Vector3(i, -3, 0), shieldPrefab.transform.rotation);
			}
			for (int i = -2; i < 6; i++){
				Instantiate(shieldPrefab, new Vector3(6, i, 0), shieldPrefab.transform.rotation);
			}
			for (int i = -2; i < 6; i++){
				Instantiate(shieldPrefab, new Vector3(-6, i, 0), shieldPrefab.transform.rotation);
			}
		}
		else if (level == 6){
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
			for (int i = -9; i < 7; i++){
				Instantiate(shieldPrefab, new Vector3(i, -3, 0), shieldPrefab.transform.rotation);
			}
			for (int i = -2; i < 6; i++){
				Instantiate(shieldPrefab, new Vector3(6, i, 0), shieldPrefab.transform.rotation);
			}
		}
		else if (level == 7){
			GameObject.Find("Escort").transform.position = new Vector3(0, -2, 0);
			GameObject.Find("Shooter").transform.position = new Vector3(0, -4, 0);
			GameObject.Find("Win").transform.position = new Vector3(0, 2, 0);
			Instantiate(blockPrefab, new Vector3(0, 1, 0), blockPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(-1, 2, 0), blockPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(0, 3, 0), blockPrefab.transform.rotation);
			Instantiate(wallPrefab, new Vector3(1, 1, 0), wallPrefab.transform.rotation);
			Instantiate(wallPrefab, new Vector3(-1, 3, 0), wallPrefab.transform.rotation);
			Instantiate(shieldPrefab, new Vector3(1, 2, 0), shieldPrefab.transform.rotation);
			for (int i = -9; i < 7; i++){
				Instantiate(shieldPrefab, new Vector3(i, -3, 0), shieldPrefab.transform.rotation);
			}
			for (int i = -2; i < 6; i++){
				Instantiate(shieldPrefab, new Vector3(6, i, 0), shieldPrefab.transform.rotation);
			}
		}
		else if (level == 8){
			GameObject.Find("Escort").transform.position = new Vector3(0, -2, 0);
			GameObject.Find("Shooter").transform.position = new Vector3(0, -4, 0);
			GameObject.Find("Win").transform.position = new Vector3(0, 2, 0);
			Instantiate(blockPrefab, new Vector3(0, 3, 0), blockPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(-1, 3, 0), blockPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(-1, 0, 0), blockPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(0, 0, 0), blockPrefab.transform.rotation);
			Instantiate(wallPrefab, new Vector3(1, 2, 0), wallPrefab.transform.rotation);
			Instantiate(shieldPrefab, new Vector3(-1, 2, 0), shieldPrefab.transform.rotation);
			Instantiate(shieldPrefab, new Vector3(0, 1, 0), shieldPrefab.transform.rotation);
			for (int i = -9; i < 7; i++){
				Instantiate(shieldPrefab, new Vector3(i, -3, 0), shieldPrefab.transform.rotation);
			}
			for (int i = -2; i < 6; i++){
				Instantiate(shieldPrefab, new Vector3(6, i, 0), shieldPrefab.transform.rotation);
			}
		}
		else if (level == 9){
			GameObject.Find("Escort").transform.position = new Vector3(0, -2, 0);
			GameObject.Find("Shooter").transform.position = new Vector3(0, -4, 0);
			GameObject.Find("Win").transform.position = new Vector3(0, 2, 0);
			Instantiate(blockPrefab, new Vector3(-1, 2, 0), blockPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(0, 1, 0), blockPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(-2, 1, 0), blockPrefab.transform.rotation);
			Instantiate(blockPrefab, new Vector3(-2, 0, 0), blockPrefab.transform.rotation);
			Instantiate(wallPrefab, new Vector3(0, 3, 0), wallPrefab.transform.rotation);
			Instantiate(wallPrefab, new Vector3(1, 2, 0), wallPrefab.transform.rotation);
			Instantiate(wallPrefab, new Vector3(-1, 3, 0), wallPrefab.transform.rotation);
			Instantiate(shieldPrefab, new Vector3(-1, 1, 0), shieldPrefab.transform.rotation);
			for (int i = -6; i < 10; i++){
				Instantiate(shieldPrefab, new Vector3(i, -3, 0), shieldPrefab.transform.rotation);
			}
			for (int i = -2; i < 6; i++){
				Instantiate(shieldPrefab, new Vector3(-6, i, 0), shieldPrefab.transform.rotation);
			}
		}
		else if (level == 10){
			ui.text1.SetActive(false);
			ui.text2.SetActive(false);
			ui.text3.SetActive(false);
			ui.instructions.SetActive(false);
			ui.pauseMenu.SetActive(true);
			ui.pause.SetActive(true);
			ui.pauseText.SetActive(true);
			ui.pauseText.GetComponent<TMPro.TextMeshProUGUI>().text = "YOU WIN!";
			ui.levels.SetActive(false);
			ui.buttonText.GetComponent<TMPro.TextMeshProUGUI>().text = "Restart Game";
		}
	}
}
