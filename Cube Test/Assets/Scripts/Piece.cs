using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    float timeSinceLastMove = 0f;
    public float timeBetweenMoves = 1.0f;
    bool grounded = false;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastMove += Time.deltaTime;

        if(timeSinceLastMove >= timeBetweenMoves)
        {
            MovePieceDownward();
            timeSinceLastMove = 0;
        }
    }

    void MovePieceDownward()
    {
        if(!grounded)
        {
            Debug.Log("Moving Downward...");
            float newY = this.transform.position.y - 1;
            Vector3 newPosition = new Vector3(this.transform.position.x, newY, this.transform.position.z);
            this.transform.position = newPosition;
        }
        
    }
}
