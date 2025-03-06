using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour{
    public static CameraShake Instance {get; private set;}
    private CinemachineCamera cinemachineCamera;
    private float startingIntesity;
    private float shakeTimer;
    private float shakeTimerTotal;
    private void Awake(){
        Instance = this;
        cinemachineCamera = GetComponent<CinemachineCamera>();
    }

    private void Update(){
        if(shakeTimer > 0){
            shakeTimer -= Time.deltaTime;
            if(shakeTimer <= 0f ){
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachineCamera.GetComponent<CinemachineBasicMultiChannelPerlin>();
                cinemachineBasicMultiChannelPerlin.AmplitudeGain =  Mathf.Lerp(startingIntesity, 0f, 1 - shakeTimer/shakeTimerTotal);

            }
        }
    }
    public void ShakeCamera(float intensity, float time){
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachineCamera.GetComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.AmplitudeGain = intensity;
        startingIntesity = intensity;
        shakeTimerTotal = time;
        shakeTimer = time;
    }
}
