using UnityEngine;

public class Paddle : MonoBehaviour {

    // Configuration Parameters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float paddleMin = 1f;
    [SerializeField] float paddleMax = 15f;

    // Cached References
    [SerializeField] GameStatus status;
    [SerializeField] Ball ball;

    // Use this for initialization
    void Start () {
        status = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(GetXPos(), paddleMin, paddleMax);
        transform.position = paddlePosition;
	}

    private float GetXPos()
    {
        if (status.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        } else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
