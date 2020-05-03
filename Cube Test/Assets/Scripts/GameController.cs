using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject cube;
    [SerializeField] int largeCubeSize = 3;
    Color[] cubeColors = { Color.red, Color.blue, Color.green, };
    List<GameObject> allCubes = new List<GameObject>();
    GameObject selectedObject = null;
    


    void Start()
    {
        CreateLargeCube();
    }

    public void ClickACube(Cube cubeClicked)
    {
        Debug.Log("A Cube has been clicked.");
        if (cubeClicked.isSelected == false && selectedObject == null)
        {
            //Select First Cube
            cubeClicked.isSelected = true;
            selectedObject = cubeClicked.gameObject;
            cubeClicked.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }

        else if (cubeClicked.isSelected == true)
        {
            //Unselect Cube
            UnselectCube(cubeClicked);
        }
        
        else
        {
            // Swap the location of this cube and the selectedObject.
            Debug.Log("Swapping Cube Positions.");
            Vector3 cubeAPosition = selectedObject.transform.position;
            Vector3 cubeBPosition = cubeClicked.gameObject.transform.position;
            selectedObject.transform.position = cubeBPosition;
            cubeClicked.gameObject.transform.position = cubeAPosition;

            UnselectCube(cubeClicked);
            UnselectCube(selectedObject.GetComponent<Cube>());

            //selectedObject.GetComponent<Cube>().isSelected = false;
            selectedObject = null;
        }
    }

    void UnselectCube (Cube cube)
    {
        cube.isSelected = false;
        if(selectedObject == cube.gameObject)
        {
            selectedObject = null;
        }
        cube.GetComponent<MeshRenderer>().material.color = cube.initialColor;
    }

    void CreateLargeCube()
    {
        for(int x=0;x<largeCubeSize;x++)
        {
            for (int y = 0; y < largeCubeSize; y++)
            {
                for (int z = 0; z < largeCubeSize; z++)
                {
                    Vector3 spawnPosition = new Vector3(x, y, z);
                    GameObject newCube = Instantiate(cube);
                    newCube.transform.position = spawnPosition;
                    Color newColor = cubeColors[Random.Range(0, cubeColors.Length)];
                    newCube.GetComponent<MeshRenderer>().material.color = newColor;
                    newCube.GetComponent<Cube>().initialColor = newColor;
                    allCubes.Add(newCube);
                }
            }
        }
    }
}
