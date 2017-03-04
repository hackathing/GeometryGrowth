using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseKeyboardController : MonoBehaviour {

	public float speed = 1.0f;
	public float turnSpeed = 100.0f;

	void Start ()
	{

	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		if (Mathf.Abs(moveVertical) > 0.2f) {
			var positionDelta = transform.forward * Time.deltaTime * moveVertical * speed;
			transform.position += positionDelta;
		}

		if (Mathf.Abs(moveHorizontal) > 0.2f) {
			var rotationDelta = Time.deltaTime * moveHorizontal * turnSpeed;
			var eulerAngles = transform.rotation.eulerAngles;
			var newRotation = Quaternion.Euler(eulerAngles[0], eulerAngles[1] + rotationDelta, eulerAngles[2]);
			transform.rotation = newRotation;
		}
	}
}
