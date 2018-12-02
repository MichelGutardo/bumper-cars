using System.Collections;
using UnityEngine;

public class PlayerController_test : MonoBehaviour {

    private float Horizontal  ;
    private float Vertical ;
    private Vector3 v3;
    private Rigidbody rb ;
    /* private Rigidbody rigid_body;
	public float speed = 25.0F;
	public float rotationSpeed = 100.0F; */

    // Use this for initialization
    void Start () {
        rb = this.GetComponent<Rigidbody>() ;
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        v3 = this.transform.position;
//		rigid_body = this.transform.Find("Bottom").gameObject.GetComponent<Rigidbody>();

    }

	// Update is called once per frame
	void Update () {

        switch (Input.inputString.ToLower())
        {
            case "w":
                v3.Set(rb.velocity.x, 0, 10);
                rb.velocity = v3;
                break;
            case "s":
                v3.Set(rb.velocity.x, 0, -10);
                rb.velocity = v3;
                break;
            case "a":
                v3.Set(-10, 0, rb.velocity.z);
                rb.velocity = v3;
                break;
            case "d":
                v3.Set(10, 0, rb.velocity.z);
                rb.velocity = v3;
                break;
        }
/*
	float translation = Input.GetAxis("Vertical") * speed;
	float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
	translation *= Time.deltaTime;
	rotation *= Time.deltaTime;
	Quaternion turn = Quaternion.Euler(0f,rotation,0f);
	rigid_body.MovePosition(rigid_body.position = this.transform.forward * translation);
	rigid_body.MoveRotation(rigid_body.rotation * turn);
*/
    }

}
