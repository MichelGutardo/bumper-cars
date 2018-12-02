using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWeapon : MonoBehaviour {

    float loop = 0.0f;
    public Transform parent;

	void Update () {
        transform.position.Set(parent.position.x, transform.position.y, parent.position.z);

        if(loop >= 360)
        {
            loop = 0.0f;
        }
        else
        {
            loop += 1;
        }

        transform.Rotate(0, loop, 0);
	}

}
