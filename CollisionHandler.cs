using UnityEngine;
using UnityEngine.SceneManagement; 

public class CollisionHandler : MonoBehaviour
{
    private const string OBSTACLE_TAG = "TempObstacle"; // Ensure this matches your Tag Manager exactly
    [SerializeField] float restartDelay = 1f; 

    // Used if the obstacle's collider has 'Is Trigger' UNCHECKED
    private void OnCollisionEnter(Collision collision)
    {
        CheckForObstacleHit(collision.gameObject);
    }

    // Used if the obstacle's collider has 'Is Trigger' CHECKED
    private void OnTriggerEnter(Collider other)
    {
        CheckForObstacleHit(other.gameObject);
    }

    void CheckForObstacleHit(GameObject collidedObject)
    {
        // This is the CRUCIAL check. It will only restart if the tag matches "TempObstacle"
        if (collidedObject.CompareTag(OBSTACLE_TAG)) 
        {
            StartCrashSequence();
        }
    }
    
    // ... rest of the code ...

    void StartCrashSequence()
    {
        Debug.Log("CRASH! Obstacle Hit Detected! Restarting game.");
        // Stop movement, if you have a CarControllers script
        // GetComponent<CarControllers>().enabled = false;
        Invoke("ReloadScene", restartDelay);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}