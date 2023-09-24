using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Button2Script : MonoBehaviour
{
    private Button button;
    public Button1Script button1Script;
    private List<GameObject> cubes ; // Reference to the list of cubes created by Button1Script.

    private bool cubesMoving = false; // Flag to track if cubes are currently moving.

    // Function to be called when Button2 is clicked. 

    private void Start()
    {
        // Get a reference to the Button component on this GameObject.
        button = GetComponent<Button>();
    }

    public void OnButton2Click()
    {
        // Get a reference to the Button component on this GameObject.
        // Check if the cubes list is assigned and not empty.
        cubes = button1Script.cubes;
        if (cubes == null || cubes.Count == 0)
        {
            Debug.LogError(cubes);
            return; // Exit the function to prevent errors.
        }

        // Toggle the cubes' movement on/off.
        cubesMoving = !cubesMoving;

        if (cubesMoving)
        {
            // Start or continue moving the cubes in random directions.
            StartCoroutine(MoveCubes());
        }
        else
        {
            // Stop the cubes' movement.
            foreach (GameObject cube in cubes)
            {
                Rigidbody2D cubeRigidbody = cube.GetComponent<Rigidbody2D>();
                cubeRigidbody.velocity = Vector2.zero;
            }
        }

        // Update the button text based on whether cubes are moving or not.

        // Disable the button while cubes are moving.
        button.interactable = !cubesMoving;
    }

    // Coroutine to continuously move cubes in random directions.
    private IEnumerator MoveCubes()
    {
        while (cubesMoving)
        {
            foreach (GameObject cube in cubes)
            {
                Rigidbody2D cubeRigidbody = cube.GetComponent<Rigidbody2D>();
                cubeRigidbody.transform.rotation = Quaternion.identity;
                cubeRigidbody.velocity = Random.insideUnitCircle.normalized * 10;
            }
            yield return null;
        }
    }
}
