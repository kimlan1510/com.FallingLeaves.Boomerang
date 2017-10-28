using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace boomerang.motion
{
    public class Spin : MonoBehaviour
    {
        private Rigidbody g_rigid_body;
        public float g_spin;

        void Start ()
        {
            g_rigid_body = gameObject.GetComponent<Rigidbody> ();
            g_rigid_body.angularVelocity = new Vector3 (0f, 0f, g_spin);
        }
	
    }

}
