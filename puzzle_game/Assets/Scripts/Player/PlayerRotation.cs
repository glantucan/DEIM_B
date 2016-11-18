using UnityEngine;
using System.Collections;

public class PlayerRotation : MonoBehaviour {


	private void Update () {
		// ROTATION:
		// -------------------------------------------------------------------------------------------------------------
		// Create the ray starting at the camera with the direction corresponding to the 2D position
		// of the mouse pointer on the screen.
		Ray mouseRay = Camera.main.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
		// Create a plane, parallel to the ground and at the height of the player gameobject 
		// to intersect the camera ray. This way we avoid inconsitencies produced 
		// by different game object heights in the scene.
		Plane viewPlane = new Plane(Vector3.up, transform.position); 	// 1st paramenter is the vector defining orientation of 
																// the plane. 2nd is just a point the plane must include
        // Define a float to hold the distance to the intersection point
        float rayDistance;
        // Cast the ray from the plane and check if there is an intersection
        if (viewPlane.Raycast(mouseRay, out rayDistance)) {
        	// Get the intersection point between the ray and the plane
            Vector3 intersectionPoint = mouseRay.GetPoint(rayDistance);
            // Draw a line in the editor so we cans see the ray and check 
            // whether it's all right
            Debug.DrawLine(mouseRay.origin, intersectionPoint, Color.green);
            // Finally rotate the player so it looks to the intersection point
            //rotator.rotate(intersectionPoint);
            this.transform.LookAt(intersectionPoint);
        }
	}

}
