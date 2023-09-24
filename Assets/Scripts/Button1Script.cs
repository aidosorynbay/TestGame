using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Button1Script : MonoBehaviour
{
    public GameObject cubePrefab; // Reference to the cube prefab.
    public List<GameObject> cubes = new List<GameObject>();
    private Button button;
    public Transform cubeSpawnPoint; // Transform of the point where cubes will spawn.

    private int cubeCount = 0; // To keep track of the cube numbers.

    private void Start()
    {
        // Get a reference to the Button component on this GameObject.
        button = GetComponent<Button>();
    }

    // Function to be called when Button1 is clicked.
    public void OnButton1Click()
    {
        // Check if the cubePrefab and cubeSpawnPoint are assigned.
        if (cubePrefab == null || cubeSpawnPoint == null)
        {
            Debug.LogError("Cube prefab or spawn point is not assigned!");
            return; // Exit the function to prevent errors.
        }

        // Generate a random number of cubes (up to a maximum of 10) with different colors.
        int numberOfCubes = Random.Range(1, 11); // 1 to 10 cubes.

        for (int i = 0; i < numberOfCubes; i++)
        {
            // Increment cubeCount before assigning it to the cube.
            cubeCount++;
    
            // Instantiate a cube prefab.
            GameObject cube = Instantiate(cubePrefab, GetRandomSpawnPosition(), Quaternion.identity);

            // Assign a random color to the cube.
            cube.GetComponent<Renderer>().material.color = Random.ColorHSV();

            // Display the incremented cubeCount on the cube.
            TextMeshPro textMeshPro = cube.transform.Find("Number").GetComponent<TextMeshPro>();
            textMeshPro.text = cubeCount.ToString();

            // Add the cube to the cubes list.
            cubes.Add(cube);
        }

        button.interactable = false;
    }

    // Function to get a random spawn position around the spawn point.
    private Vector3 GetRandomSpawnPosition()
    {
        float spawnRadius = 1.0f; // Adjust the radius as needed.
        Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
        return cubeSpawnPoint.position + new Vector3(randomOffset.x, randomOffset.y, 0);
    }
}
