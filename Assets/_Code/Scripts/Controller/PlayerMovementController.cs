using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerBall;
    private Rigidbody rb;
    [SerializeField]
    private float jumpForce;

    
    private void Start()
    {
       rb = playerBall.GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Surface"))
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);
             
        }
    }

}
