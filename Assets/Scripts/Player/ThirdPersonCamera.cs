using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("Cinemachine")]
    [Tooltip("跟随目标")]
    public GameObject CameraTarget;
    [Tooltip("上移动最大角度")]
    public float TopClamp = 70.0f;
    [Tooltip("下移动最大角度")]
    public float BottomClamp = -30.0f;
    [Tooltip("旋转平滑时间")]
    public float RotationSmoothTime = 0.1f;
    [Tooltip("鼠标控制器")]
    public MouseController mouseController;
    [Tooltip("最大横向旋转速度")]
    public float MaxHSpeed = 360f;
    [Tooltip("最大竖向旋转速度")]
    public float MaxVSpeed = 180f;

    private const float _threshold = 0.01f;
    private float _cinemachineTargetYaw;
    private float _cinemachineTargetPitch;
    

    private void Start()
    {
        if (CameraTarget == null)
        {
            CameraTarget = GameObject.FindGameObjectWithTag("MainCamera");
        }
        // 初始化时使用当前旋转角度
        _cinemachineTargetYaw = CameraTarget.transform.rotation.eulerAngles.y;
    }

    private void LateUpdate()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        Vector2 _look = mouseController.GetMouseDelta();
        
        if (_look.sqrMagnitude >= _threshold)
        {
            float deltaHSpeed = Time.deltaTime * MaxHSpeed;
            float deltaVSpeed = Time.deltaTime * MaxVSpeed;
            _look.x = Mathf.Clamp(_look.x,-deltaHSpeed,deltaHSpeed);
            _look.y = Mathf.Clamp(_look.y,-deltaVSpeed,deltaVSpeed);
            // 计算目标角度
            _cinemachineTargetYaw += _look.x;
            _cinemachineTargetPitch -= _look.y;
        }

        // 限制角度范围
        _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
        _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

        // 应用旋转
        CameraTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch, _cinemachineTargetYaw, 0.0f);
    }

    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }
}