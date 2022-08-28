using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public string StageName;
    private bool FirstPush = false;

    private void Start()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void Update()
    {
        if (Input.GetKey("q"))
        {
            SceneManager.LoadScene("test");
        }
    }
    
    public void ChangeSceen()
    {
        // start�{�^����������
        if (!FirstPush)
        {
            // �Z�[�u�f�[�^�擾
            if (string.Compare(StageName, "Game") == 0) DataManager.instance.FirstSet();
            SceneManager.LoadScene(StageName);
            FirstPush = true;
        }
    }
    
    void OnSceneUnloaded(Scene scene)
    {
        Debug.Log(scene.name + "scene unloaded");
    }
}
