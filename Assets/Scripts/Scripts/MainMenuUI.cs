using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Image tutorialImage;
    [SerializeField] private TextMeshProUGUI tutorialText;
    private void Awake(){
        tutorialImage.enabled = false;
        tutorialText.enabled = false;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            tutorialImage.enabled = false;
            tutorialText.enabled = false;
        }
    }
    public void LoadGameScene(){
        Loader.Load(Loader.Scene.GameScene);
    }
    public void OpenTutorialImage(){
        tutorialImage.enabled = true;
        tutorialText.enabled = true;
    }
    
}
