using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//조명 조절 스크립트
public class LightManager : MonoBehaviour
{
    public Light spotLight;
    public bool brighten;
    // Start is called before the first frame update   

    // Update is called once per frame
    void Update()
    {
        if(!brighten)
        {
            Dark();
        }

        if(brighten)
        {
            Bright();
        }
        
    }

    void Bright()
    {
      spotLight.intensity += 2.5f*Time.deltaTime;
        if(spotLight.intensity >= 10.0f)
        {
            brighten = false;
        }
    }


    void Dark()
    {
      spotLight.intensity -= 2.5f*Time.deltaTime;
        if(spotLight.intensity <= 0.0f)
        {
            brighten = true;
        }
    }






}
