using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingEffect : MonoBehaviour
{
    //public static FallingEffect instance;
    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }
    //}
    private void Start()
    {
       // ShowEffect();
    }
    //public void ShowEffect()
    //{
    //    Transform[] childs = transform.parent.GetComponentsInChildren<Transform>();
    //    foreach (var child in childs)
    //    {
    //        Rigidbody rb = child.GetComponent<Rigidbody>();
    //        if (rb != null)
    //        {
    //            rb.AddTorque(new Vector3(-0.5f, 0, -0.5f));
    //            Vector3 force = child.transform.TransformDirection(new Vector3(-1, -1, 0)) * 100f;
    //            rb.isKinematic = false;
    //            rb.AddForce(force, ForceMode.Force);

    //        }
    //    }
    //}

}
