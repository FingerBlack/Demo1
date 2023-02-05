using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class NextPage6 : MonoBehaviour
{
    // Start is called before the first frame update
    public int debug;
    //public Button StarGameButton;
    public AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;
    void Start()
    {
        //myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/Resources/Scenes");
        
        //scenePaths = myLoadedAssetBundle.GetAllScenePaths();
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnClick(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
