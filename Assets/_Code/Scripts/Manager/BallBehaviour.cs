using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject splashImage;
    private GameObject splashEffect;
    public bool isFallingState;
    public int scoreStreak;
    private int score;
    [SerializeField]
    TrailRenderer playerTrail;
    [SerializeField]
    private Material ballMaterial;
    [SerializeField]
    private GameObject surface;
    public static bool isGameOver;
    public TextMeshProUGUI scoreText;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Surface"))
        {
            surface = collision.collider.gameObject;
            ContactPoint contact = collision.contacts[0];
            Vector3 collisionPosition = contact.point;
            ShowSplashEffect(collisionPosition, collision.gameObject);
            if (isFallingState && scoreStreak >= 3)
            {
                Debug.Log("outttt ");
                FallEffect();
            }
            scoreStreak = 0;
            isFallingState = false;
            CheckFallingStreak();
            }
        else if (collision.gameObject.CompareTag("Hurdle"))
        {
            DetectHurdle();
        }
        else if(collision.gameObject.CompareTag("Complete"))
        {
            DetectCompletePlatform();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Score"))
        {
            score++;
            scoreStreak++;
            isFallingState = true;
            CheckFallingStreak();
            scoreText.text = "Score :" + score;
        }
    }
    private void ShowSplashEffect(Vector3 splashPosition, GameObject surface)
    {
        Quaternion rotation = Quaternion.Euler(90f, 0f, 0f);
        splashPosition.y += 0.05f;
        splashEffect = Instantiate(splashImage, splashPosition, rotation, surface.transform);  
    }
    private void CheckFallingStreak()
    {
        if (isFallingState && scoreStreak >= 3)
        {
            playerTrail.startColor = new Color(1, 0.1367925f, 0.2069422f);
            playerTrail.endColor = Color.white;
            ballMaterial.color = Color.red;
        }
        else
        {
            playerTrail.startColor = new Color(0.3066038f, 0.6845727f,1f);
            playerTrail.endColor = Color.white;
            ballMaterial.color = new Color(0f, 0.4935527f, 1f, 1f);
        }
    }
    private void FallEffect()
    {
        surface.transform.parent.parent = null;
        foreach (Transform child in surface.transform.parent)
        {
            Debug.Log("child are" + child.name);
            Rigidbody rb = child.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Collider surfaceCollider = surface.GetComponent<Collider>();
                surfaceCollider.enabled = false;
                Vector3 force = child.transform.TransformDirection(new Vector3(-1, 0f, 0)) * 200f;
                rb.isKinematic = false;
                rb.AddForce(force, ForceMode.Force);
                child.Rotate(transform.forward * -25f);
               // Invoke("DestroySurface", 1.5f);
            }
        }
       
        isFallingState = false;
    }
    private void DestroySurface()
    {
        Destroy(surface.transform.parent.gameObject);
    }
    private void DetectHurdle()
    {
     Debug.Log("surface = " + surface.tag);
     isGameOver = true;
     UIManager.instance.OnLevelFail();
        
    }
    private void DetectCompletePlatform()
    {
        isGameOver = true;
        UIManager.instance.OnLevelComplete();
    }
}
