using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class LevelChanger : MonoBehaviour {

    public Animator animator;
    [SerializeField] public string levelToLoad;

    public void FadeToNextLevel() 
    {
        FadeToLevel(levelToLoad);
    }

    public void FadeToLevel(string level)
    {
        levelToLoad = level;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete() 
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
