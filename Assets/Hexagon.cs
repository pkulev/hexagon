using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour {

    public Rigidbody2D rb;
    public float shrinkSpeed = 3f;

    private GameController gameController;

	// Use this for initialization
	void Start () {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        if (gameController == null) {
            Debug.Log("GameController is not found.");
        }

        rb.rotation = Random.Range(0f, 360f);
        //transform.rotation = 
        transform.localScale = Vector3.one * 12f;
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;

        if (transform.localScale.x <= .05f)
        {
            Destroy(gameObject);
            gameController.IncScore();

        }
	}
}
