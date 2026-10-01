using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class updateUI : MonoBehaviour
{
	public GameObject pauseMenu;
	public GameObject pause;
	public GameObject levels;
	public GameObject text1;
	public GameObject text2;
	public GameObject text3;
	public GameObject instructions;
	public InputAction pauseAction;
	public bool visible;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseAction.Enable();
		pauseMenu.SetActive(true);
		levels.SetActive(false);
		visible = false;
		pauseMenu.SetActive(visible);
		text1.SetActive(true);
		text2.SetActive(true);
		text3.SetActive(true);
		instructions.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseAction.triggered){
			pause.SetActive(true);
			levels.SetActive(false);
			pauseMenu.SetActive(!pauseMenu.activeSelf);
		}
    }
}
