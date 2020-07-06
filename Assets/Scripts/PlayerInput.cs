using UnityEngine;
using System.Collections;

[RequireComponent (typeof (MovementController))]
public class PlayerInput : MonoBehaviour {

    MovementController controller;

	void Start () {
		controller = GetComponent<MovementController> ();
	}

	void Update () {
		Vector2 directionalInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		controller.SetDirectionalInput (directionalInput);

        if(Input.GetButtonDown("Jump"))
        {
            controller.OnJumpInputDown();
        }

        if (Input.GetButtonUp("Jump"))
        {
            controller.OnJumpInputUp();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            GetComponent<AttackManager>().attacks[0].attack();
        }
    }
}
