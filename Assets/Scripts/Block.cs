using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip breakingSound;
    [SerializeField] int health;

    // Cached Reference
    Level level;
    GameStatus status;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        if(tag == "Breakable")
        {
            level.CountBreakableBlock();
        }

        status = FindObjectOfType<GameStatus>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            Hit();
        }
    }

    private void Hit()
    {
        health -= 100;

        if (health == 0)
        {
            AudioSource.PlayClipAtPoint(breakingSound, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y));
            Destroy(gameObject);
            level.BlockDestroyed();
            status.AddToScore();
        }

    }
}
