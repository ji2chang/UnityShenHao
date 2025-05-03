using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))] // 确保对象有PlayerInput组件
public class PlayerMovement : MonoBehaviour
{

    private CharacterController _controller;
    private GameObject _mainCamera;

    void Start()
    {
        if ( _mainCamera == null)
        {
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }
        _controller = GetComponent<CharacterController>();
    }

    public float speed = 6f;
    //目标旋转角度
    float _targetRot = 0f;

    void Update()
    {
        if (_move != Vector2.zero)
        {
            Vector3 inputDir = new Vector3(_move.x, 0f, _move.y).normalized;
            _targetRot = Mathf.Atan2(inputDir.x,inputDir.z) * Mathf.Rad2Deg +
                        _mainCamera.transform.eulerAngles.y;
            //转起来
            transform.rotation = Quaternion.Euler(0f, _targetRot, 0f);
            Vector3 targetDir = Quaternion.Euler(0f, _targetRot, 0f) * Vector3.forward;
            //动起来
            _controller.Move(targetDir.normalized * speed * Time.deltaTime);
        }
    }

    Vector2 _move;
    void OnMove(InputValue value)
    {
        _move = value.Get<Vector2>();
    }
}