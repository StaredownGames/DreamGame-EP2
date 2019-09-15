using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Camera cam;
    public float speed = 1.25f;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //MOVEMENT
        float axisH = Input.GetAxis("Horizontal");
        float axisV = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(axisV,-axisH,0) * speed * Time.deltaTime);

        //FACE THE MOUSE POINTER

        //convert the mouse position to world coordinates.
        Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        //what direction we want to look at.
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;

        //get the distance from player to mousePosition.
        float playerToMouseDistance = Vector2.Distance(mousePosition,(Vector2)transform.position);

        if (playerToMouseDistance >= .25f)
        {
            transform.right = direction;

        }

     }
}