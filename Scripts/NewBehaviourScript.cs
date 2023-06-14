using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject EscMenu;//≤Àµ•¡–±Ì

    [SerializeField] private bool menuKeys = true;
    [SerializeField] private AudioSource bgmSound;//±≥æ∞“Ù¿÷

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (menuKeys)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                EscMenu.SetActive(true);
                menuKeys = false;
                Time.timeScale = 0;// ±º‰‘›Õ£
                bgmSound.Pause();//“Ù¿÷‘›Õ£
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscMenu.SetActive(false);
            menuKeys = true;
            Time.timeScale = 1;// ±º‰ª÷∏¥
            bgmSound.Play();//“Ù¿÷≤•∑≈


        }
    }
    public void Return() {
        EscMenu.SetActive(false);
        menuKeys = true;
        Time.timeScale = 1;// ±º‰ª÷∏¥
        bgmSound.Play();//“Ù¿÷≤•∑≈
    }

    public void Restart() {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Exit() {
        Application.Quit();
    }
}
