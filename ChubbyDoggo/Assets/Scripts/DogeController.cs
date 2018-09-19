using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogeController : MonoBehaviour {

    public Camera cam;
    public new Rigidbody2D rigidbody2D;
    public new Renderer renderer;
    private float maxWidth;

    // Use this for initialization
    void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        renderer = GetComponent<Renderer>();

        if (cam == null) {
            cam = Camera.main;
        }
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float dogeWidth = renderer.bounds.extents.x;
        maxWidth = targetWidth.x - dogeWidth;
    }
	
	// Update is called once per physics timestep
	public void FixedUpdate () {
        Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPosition = new Vector3(rawPosition.x, 0.0f, 0.0f);
        float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
        targetPosition = new Vector3(targetWidth, targetPosition.y, targetPosition.z);
        rigidbody2D.MovePosition(targetPosition);
	}
}
