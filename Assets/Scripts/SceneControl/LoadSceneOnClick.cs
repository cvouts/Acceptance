using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{

    public LevelChanger levelChangerHandle;

    public void TriggerLevelLoad()
       
    {
        levelChangerHandle.FadeToNextLevel();
    }

    public void LoadLevelWithIndex(string levelName)

    {
        levelChangerHandle.FadeToLevel(levelName);
    }
}
