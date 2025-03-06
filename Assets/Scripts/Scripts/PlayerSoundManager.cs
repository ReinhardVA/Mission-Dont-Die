using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    public static PlayerSoundManager Instance {get; private set;}
    [SerializeField] private AudioSource fireSound;
    [SerializeField] private AudioSource hurtSound;
    [SerializeField] private AudioSource buffSound;

    private void Awake(){
        Instance = this;
    }
    public void PlayFireSound(){
        fireSound.Play();
    }
    public void PlayHurtSound(){
        hurtSound.Play();
    }
    public void PlayerBuffSound(){
        buffSound.Play();
    }
}
