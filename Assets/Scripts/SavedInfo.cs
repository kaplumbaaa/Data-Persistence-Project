using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SavedInfo : MonoBehaviour
{

    public static SavedInfo Instance;
    public string playerName;

    public string bestPlayerName;
    public int score;
    private void Awake() {
        if (Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
        //ResetScore();
    }

[System.Serializable]
class SaveData{
    public int highscore;
    public string bestPlayer;
}    

public void SaveHighscore(int gameScore){
    if (gameScore>score){
        score = gameScore;
        bestPlayerName = playerName;
        SaveData data = new SaveData();
        data.bestPlayer = playerName;
        data.highscore = score;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json",json);
    }

}

public void LoadHighScore(){
    string path = Application.persistentDataPath + "/savefile.json";
    if (File.Exists(path)){
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        bestPlayerName = data.bestPlayer;
        score = data.highscore;

    }
}

public void ResetScore(){
    SaveData data = new SaveData();
    data.bestPlayer = playerName;
    data.highscore = 0;
    string json = JsonUtility.ToJson(data);
    File.WriteAllText(Application.persistentDataPath + "/savefile.json",json);
}

}
