using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class NextPage7 : MonoBehaviour
{
    // Start is called before the first frame update
    public int debug;
    //public Button StarGameButton;
    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
        myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/Resources/Scenes");
        scenePaths = myLoadedAssetBundle.GetAllScenePaths();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnClick(){
        SceneManager.LoadScene(scenePaths[0], LoadSceneMode.Single);
        //GameObject.Find("Canvas/Page7").SetActive(false);
        //GameObject.Find("Canvas/Page2").SetActive(true);
    }
}
