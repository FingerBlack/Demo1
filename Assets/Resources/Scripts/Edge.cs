using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    // Start is called before the first frame update
    public float possibility;
    public float guidline;
    public GameObject start;
    public GameObject end;
    // public int TimeCount;
    public int TimePierod;
    public SpriteRenderer Sprite;
    public UnityEngine.Rendering.Universal.Light2D Light2D;
    public float HP;
    public Color col;
    public float TimeCount;
    void Start()
    {
        possibility=1f;
        HP=255f;
        guidline=0;
        TimePierod=30;
        Sprite=gameObject.GetComponent<SpriteRenderer>();
        col=GetComponent<SpriteRenderer>().color;
        TimeCount=0;
        
    }

    // Update is called once per frame 
    
    void Update()
    {       
        //Sprite.color=new Color(1f-(guidline)/10f,1f-(guidline)/10f,1f-(guidline)/10f,255f);
        
        TimeCount+=Time.deltaTime;
        if(TimeCount>0.5f){
            TimeCount=0;
            if(guidline>0.05f)
                guidline-=0.05f;
        }

        Light2D=transform.GetChild(1).GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        Light2D.intensity = guidline/5f;
        GetComponent<SpriteRenderer>().color=new Color(col.r+(255f-HP)/300f,col.g,col.b,1f);
        if(HP<255f){
            HP+=0.1f;
        }

        // TimeCount++;
        // if(TimeCount>TimePierod){
        //     TimeCount=0;
        //     if(guidline>=0){
        //         guidline*=0.99f;
        //     }
        // }
        
    }
}
