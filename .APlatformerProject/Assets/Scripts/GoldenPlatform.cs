using UnityEngine;

public class GoldenPlatform : MonoBehaviour
{
    private bool isActive = false;
    private bool isRising = false;
    public float riseSpeed = 2f;
    public Transform stopPoint;
    private bool hasPlayerTouched = false;

    private void Update()
    {
        
        if (isRising && transform.position.y < stopPoint.position.y)
        {
            transform.position += Vector3.up * riseSpeed * Time.deltaTime;
        }
        
        else if (transform.position.y >= stopPoint.position.y)
        {
            isRising = false;
        }
    }

    public void ActivatePlatform()
    {
        isActive = true;
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player") && !hasPlayerTouched)
        {
            hasPlayerTouched = true;
            isRising = true;

            
            collision.transform.SetParent(transform);

            
            FollowCam cam = Camera.main.GetComponent<FollowCam>();
            cam.enabled = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}


