using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace boomerang.motion
{
    public class BoomerangFly : MonoBehaviour
    {
        private Rigidbody g_rigid_body;
        public float g_fly_speed;
        public float g_spin;

	    // Use this for initialization
	    void Start ()
        {
            g_rigid_body = gameObject.GetComponent<Rigidbody> ();
            g_rigid_body.velocity = transform.forward * g_fly_speed;
            g_rigid_body.angularVelocity = new Vector3 (0f, 0f, g_spin);

	    }
	
	    // Update is called once per frame
	    void Update ()
        {
		
	    }
    }

}
