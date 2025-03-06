using Unity.Cinemachine;
using UnityEngine;

public class CameraDisplacement : MonoBehaviour{
    [SerializeField] private Transform playerPosition;
    [SerializeField] private CinemachineCamera cinemachineCamera;
    private float displacementSpeed = 0.02f;
    private CinemachineOrbitalFollow orbitalFollow;
    private void Start(){
        orbitalFollow = cinemachineCamera.GetComponent<CinemachineOrbitalFollow>();
    }

    private void Update(){
        Vector3 mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float horizontalDisplacement = (mousePosition.x - 0.5f) * displacementSpeed;
        float verticalDisplacement = (mousePosition.y - 0.5f) * displacementSpeed;

        orbitalFollow.RadialAxis.Value += horizontalDisplacement;
        orbitalFollow.VerticalAxis.Value += verticalDisplacement;
    }
}
