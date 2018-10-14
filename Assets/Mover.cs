using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mover : MonoBehaviour {

    public float moveSpeed = 600f;

    private GameController gameController;
    private float movement = 0f;

    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        if (gameController == null)
        {
            Debug.Log("GameController not found.");
        }
    }

    void Update () {
        movement = Input.GetAxisRaw("Horizontal");
	}

    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, movement * -moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.SaveScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
