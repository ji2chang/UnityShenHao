using UnityEngine;
using UnityEngine.InputSystem;
public class MouseController : MonoBehaviour
{
    private Vector2 mouseDelta = new Vector2(0.0f,0.0f);

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 GetMouseDelta()
    {
        return mouseDelta;
    }

    public void OnLook(InputValue value)
    {
        mouseDelta = value.Get<Vector2>();
        Debug.Log(mouseDelta);
    }
}
