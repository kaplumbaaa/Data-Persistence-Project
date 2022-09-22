using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainUIHandler : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI menuHighscoreInfo;
    [SerializeField] TMP_InputField playerName;
    // Start is called before the first frame update
    void Start()
    {
        if (SavedInfo.Instance.bestPlayerName != null)
        {
            menuHighscoreInfo.text = "Best Score: " + SavedInfo.Instance.bestPlayerName + " : " + (SavedInfo.Instance.score).ToString();
        }
        else
        {
            menuHighscoreInfo.text = "Best Score: : 0";
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SaveName()
    {
        SavedInfo.Instance.playerName = playerName.text;

    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }


}


