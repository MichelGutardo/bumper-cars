using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	static public Transform player;
	public bool locked;
	public float top_height = 23;

	public bool back;
	public float back_distance = 10;
	public float back_height = 5;
	public float camera_speed = 10;
	public float rotation_speed = 10;
	public Vector3 look_offset = new Vector3(0,1,0);

	void LateUpdate()
	{
		if(player)
		{
			if(back)
			{
				this.lowView();
			}
			else
			{
				this.highView();
			}
		}
	}

	private void highView()
	{
		if(locked){

			this.transform.position = new Vector3(player.transform.position.x,top_height,player.transform.position.z);

		}else{

			this.transform.position = new Vector3(-8,top_height,-4);

			transform.LookAt(player);
		}
	}

	private void lowView()
	{

		Vector3 look_position = player.position + look_offset;

		Vector3 relative_position = look_position - transform.position;

		Quaternion rotation = Quaternion.LookRotation(relative_position);

		transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation,Time.deltaTime * rotation_speed * 0.1f);

		Vector3 target_position = player.transform.position + player.transform.up * back_height - player.transform.forward * back_distance;

		this.transform.position = Vector3.Lerp(this.transform.position, target_position,Time.deltaTime * camera_speed * 0.1f);
	}
}
