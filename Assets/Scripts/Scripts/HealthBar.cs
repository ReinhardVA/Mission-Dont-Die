using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform bar;
    private void Start(){
        bar.localScale = new Vector3(1f, 1f);
    }
    public void SetSize(float sizeNormalized){
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }

}
