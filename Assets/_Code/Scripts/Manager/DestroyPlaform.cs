using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlaform : MonoBehaviour
{
    [SerializeField]
    private Material newMaterial;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //FallingEffect.instance.ShowEffect();
            //StartCoroutine(DestroyPlatform());
            ShowEffect();
        }
    }
  
    public void ShowEffect()
    {
        transform.parent.parent = null;
        foreach (Transform child in transform.parent)
        {
            Debug.Log("child are" + child.name);
            Rigidbody rb = child.GetComponent<Rigidbody>();
            if (rb != null)
            {
                MeshRenderer childMaterial = child.GetComponent<MeshRenderer>();
                childMaterial.material = newMaterial;
                Collider childCollider = child.GetComponent<Collider>();
                childCollider.enabled = false;
                Vector3 force = child.transform.TransformDirection(new Vector3(-1, -1f, 0)) * 150f;
                rb.isKinematic = false;
                rb.AddForce(force, ForceMode.Force);
                child.Rotate(transform.forward*-25f);
                transform.gameObject.SetActive(false);
                Invoke("DestroyPlatform", 2f);
            }
        }
    }
    private void DestroyPlatform()
    {
        Destroy(transform.parent.gameObject);
    }
    
}
