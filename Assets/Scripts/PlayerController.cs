using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor.Experimental.Build.AssetBundle;

public class PlayerController : MonoBehaviour
{
    // Public variable to adjust player speed in Inspector
    public float Speed = 5.0f;
    public int score = 0;
    public int health = 5;

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        GetComponent<Rigidbody>().linearVelocity = movement * Speed;
    }

    // Check if the collided object is tagged as "Pickup".
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            // Increment score.
            score++;

            // Log the updated score to the console
            Debug.Log("Score: " + score);

            // Disable or destroy the coin object
            // You can choose either option based on your requirements
            // For example, to disable the coin:
            other.gameObject.SetActive(false);
            // Or to destroy the coin:
            // Destroy(other.gameObject);
        }
        // Check if the collided object is tagged as "Trap".
        else if (other.CompareTag("Trap"))
        {
            // Decrement health.
            health--;

            // Log the updated health to the console.
            Debug.Log("Health: " + health);
            // Also we can add logic here to handle player death if health reaches 0.
        }
        // Check if the collided object is tagged as "Goal".
        else if (other.CompareTag("Goal"))
        {
            // Display "You win!" message to the console.
            Debug.Log("You win!");
        }
        // Check if the collided object is tagged as "Teleporter".
        else if (other.CompareTag("Teleporter"))
        {
            GameObject[] teleporters = GameObject.FindGameObjectsWithTag("Teleporter");

            // Shuffle the teleporters array
            for (int i = 0; i < teleporters.Length; i++)
            {
                GameObject temp = teleporters[i];
                int randomIndex = Random.Range(i, teleporters.Length);
                teleporters[i] = teleporters[randomIndex];
                teleporters[randomIndex] = temp;
            }
            // Find the other Teleporter by checking which one the player collided with a Tag.
            foreach (GameObject teleporter in teleporters)
            {
                if (teleporter != other.gameObject)
                {
                    // Teleport the player to the position of the other Teleporter.
                    transform.position = teleporter.transform.position;
                    break;
                }
            }
        }
    }

    // Update is called once per frame.
    private void Update()
    {
        // Check if health equals 0.
        if (health == 0)
        {
            // Log "Game Over!" message to the console.
            Debug.Log("Game Over!");

            // Reload the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            // Reset player's health and score.
            health = 5;
            score = 0;
        }
    }
}
