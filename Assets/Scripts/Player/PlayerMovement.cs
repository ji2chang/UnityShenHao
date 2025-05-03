using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;
    private GameObject _mainCamera;
    
    [Header("Movement Settings")]
    public float speed = 6f;
    public float rotationSmoothTime = 0.1f;

    private float _gravity = -1f;
    
    private float _targetRot;
    private float _rotationVelocity;
    private Vector2 _moveInput;
    
    void Start()
    {
        if (_mainCamera == null)
        {
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        ApplyGravity();
        HandleMovement();
    }

    private void ApplyGravity()
    {
        Vector3 movement = new Vector3(0f, _gravity, 0f);
        _controller.Move(movement);
    }
    private void HandleMovement()
    {
        Vector3 movement = Vector3.zero;
        if (_moveInput != Vector2.zero)
        {
            // 计算输入方向
            Vector3 inputDir = new Vector3(_moveInput.x, 0f, _moveInput.y).normalized;
            
            // 计算目标旋转角度（相对于相机）
            _targetRot = Mathf.Atan2(inputDir.x, inputDir.z) * Mathf.Rad2Deg + 
                         _mainCamera.transform.eulerAngles.y;
            
            // 平滑旋转
            float currentRot = Mathf.SmoothDampAngle(
                transform.eulerAngles.y, 
                _targetRot, 
                ref _rotationVelocity, 
                rotationSmoothTime);
            
            transform.rotation = Quaternion.Euler(0f, currentRot, 0f);
            
            // 计算移动方向
            movement = Quaternion.Euler(0f, _targetRot, 0f) * Vector3.forward * 
                      speed * Time.deltaTime;
        }
        
        _controller.Move(movement);
    }

    void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }
}