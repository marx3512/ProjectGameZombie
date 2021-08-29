using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
	[SerializeField] private Transform cam;
	private float turnSmoothTime = 0.15f;
	float turnSmoothVelocity;
	
	public float speed = 0f;

	void Update()
	{
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 move = new Vector3(x, 0, z).normalized;

		if( move.magnitude >= 0.1f)
		{
			float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
			float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
			transform.rotation = Quaternion.Euler(0f, angle, 0f);

			Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
			characterController.Move(moveDir * speed * Time.deltaTime);
		}
	}
}
