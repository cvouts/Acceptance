using UnityEngine;

public class PortalTrigger : MonoBehaviour
{
    public LevelChanger levelChangerHandle;
    private Collider2D portal;

    private void Awake()
    {
        portal = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            levelChangerHandle.FadeToNextLevel();
        }
    }
}
