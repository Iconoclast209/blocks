using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    GameController gc;

    private void Start()
    {
        gc =  FindObjectOfType<GameController>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                gc.ClickACube(hit.transform.gameObject.GetComponent<Cube>());
            }
        }
    }
}
