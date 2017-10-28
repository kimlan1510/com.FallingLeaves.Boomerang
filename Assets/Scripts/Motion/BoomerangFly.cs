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
        public float g_curve_radius;
        private Vector3 g_curve_center;
        private float g_curve_center_x;
        private float g_curve_center_y;
        public GameObject g_gameobject;

	    // Use this for initialization
	    void Start ()
        {
            g_rigid_body = gameObject.GetComponent<Rigidbody> ();
            g_rigid_body.velocity = transform.forward * g_fly_speed;
            g_rigid_body.angularVelocity = new Vector3 (0f, 0f, g_spin );
            Vector3 vertical_vector = new Vector3 (0, 1, 0);
            float beta = Vector3.Angle (transform.forward, vertical_vector);
            Debug.Log (transform.forward);

            if (beta > 90 && beta != 180)
            {
                Debug.Log (beta);
                beta = 180 - beta;
                float alpha = 90 - beta;
                //x coordinate of curve center
                g_curve_center_x = g_curve_radius * Mathf.Sin (alpha * Mathf.Deg2Rad) + transform.position.x;
                if (transform.forward.x < 0)
                {
                    g_curve_center_y = transform.position.y - g_curve_radius * Mathf.Cos (alpha * Mathf.Deg2Rad);
                }
                else if (transform.forward.x > 0)
                {
                    g_curve_center_y = transform.position.y + g_curve_radius * Mathf.Cos (alpha * Mathf.Deg2Rad);
                }
            }
            else if (beta < 90 && beta != 0)
            {
                Debug.Log (beta);
                float alpha = 90 - beta;
                g_curve_center_x = transform.position.x - g_curve_radius * Mathf.Sin (alpha * Mathf.Deg2Rad);
                if (transform.forward.x < 0)
                {
                    g_curve_center_y = transform.position.y - g_curve_radius * Mathf.Cos (alpha * Mathf.Deg2Rad);
                }
                else if (transform.forward.x > 0)
                {
                    g_curve_center_y = transform.position.y + g_curve_radius * Mathf.Cos (alpha * Mathf.Deg2Rad);
                }
            }
            else if (beta == 0)
            {
                Debug.Log (beta);
                float alpha = 90 - beta;
                g_curve_center_y = transform.position.y;
                g_curve_center_x = transform.position.x - g_curve_radius * Mathf.Sin (alpha * Mathf.Deg2Rad);
               
            }
            else if (beta == 90)
            {
                Debug.Log (beta);
                float alpha = 90 - beta;
                g_curve_center_x = transform.position.x;
                if (transform.forward.x < 0)
                {
                    g_curve_center_y = transform.position.y - g_curve_radius * Mathf.Cos (alpha * Mathf.Deg2Rad);
                }
                else if (transform.forward.y > 0)
                {
                    g_curve_center_y = transform.position.y + g_curve_radius * Mathf.Cos (alpha * Mathf.Deg2Rad);
                }
            }
            else if (beta == 180)
            {
                float alpha = 90f;
                g_curve_center_y = transform.position.y;
                g_curve_center_x = transform.position.x + g_curve_radius * Mathf.Sin (alpha * Mathf.Deg2Rad);
            }

            g_curve_center = new Vector3 (g_curve_center_x, g_curve_center_y, transform.position.z);

            Instantiate (g_gameobject, g_curve_center, Quaternion.identity);

            Debug.Log (g_curve_center);

	    }
	
	    // Update is called once per frame
	    void Update ()
        {
            //Debug.Log (g_rigid_body.velocity);
	    }
    }

}
