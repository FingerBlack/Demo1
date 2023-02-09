using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class NextPage8 : MonoBehaviour
{
    // Start is called before the first frame update
    public int debug;
    //public Button StarGameButton;
    public AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
        //myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/Scenes");
        //scenePaths = myLoadedAssetBundle.GetAllScenePaths();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnClick(){
        debug=1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //GameObject.Find("Canvas/Page7").SetActive(false);
        //GameObject.Find("Canvas/Page2").SetActive(true);
    }
}
