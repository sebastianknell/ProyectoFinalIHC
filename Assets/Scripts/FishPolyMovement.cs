using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPolyMovement : MonoBehaviour {
    // Start is called before the first frame update
    private System.Random random = new System.Random();
    // Speed of all fishes spawned
    public float speed = 10f;
    // Update direction every interval (seconds)
    public float interval = 50f, updateInterval = 50f;
    private float timer, updateTimer;
    private float forwardDirection, framedForwardDirection, upDirection, framedUpDirection;
	private bool updateDirection = false;

	// Start movement
    void Start() {
        timer = interval;
		updateTimer = updateInterval;

		// Start pointing to diferrent directions
		float startDirection = (float)random.NextDouble() * 360;
		transform.Rotate(Vector3.up, startDirection);
    }

    // Update is called once per frame
    void Update() {
        timer -= 1f;
		
		// Update direction if interval has ended and update interval has finished
		// Total time = interval + updateInterval
        if(timer <= 0f && !updateDirection) {
			// Get angle of changed forward direction [-25 to 25]
			forwardDirection = (float)random.NextDouble() * 50 - 25;
			// Get angle of changed upward direction [-15 to 15]
			upDirection = (float)random.NextDouble() * 30 - 15;
			// Reset timer and continue with movement updating
			timer = interval + updateInterval;
			updateDirection = true;
        }
		else {
			updateTimer -= 1f;
			UpdateForward();
			//UpdateUpward();
			if(updateTimer <= 0f) {
				updateDirection = false;
				updateTimer = updateInterval;
			}
		}

        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

	void UpdateForward() {
		// Divide changed directions into 10 frames
		framedForwardDirection = forwardDirection / updateInterval;
		transform.Rotate(Vector3.up, framedForwardDirection);
	}

	void UpdateUpward() {
		// Divide changed directions into 10 frames
		framedUpDirection = upDirection / updateInterval;
		transform.Rotate(Vector3.right, framedUpDirection);
	}
}
