using UnityEngine;

public class Level : MonoBehaviour {

    // Parameters
    [SerializeField] int breakableBlocks; // Serialized for debugging purposes

    // Cached Refereces
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableBlock()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if(breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
