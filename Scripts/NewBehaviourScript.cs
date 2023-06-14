using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject EscMenu;//�˵��б�

    [SerializeField] private bool menuKeys = true;
    [SerializeField] private AudioSource bgmSound;//��������

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
                Time.timeScale = 0;//ʱ����ͣ
                bgmSound.Pause();//������ͣ
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscMenu.SetActive(false);
            menuKeys = true;
            Time.timeScale = 1;//ʱ��ָ�
            bgmSound.Play();//���ֲ���


        }
    }
    public void Return() {
        EscMenu.SetActive(false);
        menuKeys = true;
        Time.timeScale = 1;//ʱ��ָ�
        bgmSound.Play();//���ֲ���
    }

    public void Restart() {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Exit() {
        Application.Quit();
    }
}
