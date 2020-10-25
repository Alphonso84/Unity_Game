using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    bool _userIsDragging = false;

    Vector3 _initialPosition;

    private void Awake()
    {
        _initialPosition = transform.position;

    }

    private void Update()
    {
        if (_userIsDragging) 
        {

        }
        else if (transform.position.y > 10 || transform.position.y < -3.7)
        {
            
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);

        }
    }

    private void OnMouseDown()
    {
        _userIsDragging = true;
        // GetComponent<SpriteRenderer>().color = Color.blue;
    }

    private void OnMouseUp() 
    {
        // GetComponent<SpriteRenderer>().color = Color.white;
        _userIsDragging = false;
        Vector2 directionToInitialPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * 100);
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
        // GetComponent<Rigidbody2D>().gravityScale = 0;
    }

}
