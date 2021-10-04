using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBoard : MonoBehaviour
{
    // Start is called before the first frame update

    //config params
    [SerializeField] AudioClip[] abiS;
    [SerializeField] AudioClip[] joeR;
    [SerializeField] AudioClip[] johnF;
    [SerializeField] AudioClip[] liamO;
    [SerializeField] AudioClip[] mattO;
    [SerializeField] AudioClip[] johnK;


    //cached refs
    [SerializeField] AudioSource myAudioSource;

    private void Start()
    {
    }
    public void PlayAbiS0()
    {
        PlayClip(abiS[0]);
    }
    public void PlayAbiS1()
    {
        PlayClip(abiS[1]);
    }
    public void PlayAbiS2()
    {
        PlayClip(abiS[2]);
    }
    public void PlayAbiS3()
    {
        PlayClip(abiS[3]);
    }
    public void PlayAbiS4()
    {
        PlayClip(abiS[4]);
    }
    public void PlayAbiS5()
    {
        PlayClip(abiS[5]);
    }
    public void PlayAbiS6()
    {
        PlayClip(abiS[6]);
    }
    public void PlayAbiS7()
    {
        PlayClip(abiS[7]);
    }
    public void PlayAbiS8()
    {
        PlayClip(abiS[8]);
    }
    public void PlayAbiS9()
    {
        PlayClip(abiS[9]);
    }
    public void PlayAbiS10()
    {
        PlayClip(abiS[10]);
    }
    public void PlayAbiS11()
    {
        PlayClip(abiS[11]);
    }
    public void PlayAbiS12()
    {
        PlayClip(abiS[12]);
    }
    public void PlayAbiS13()
    {
        PlayClip(abiS[13]);
    }
    public void PlayAbiS14()
    {
        PlayClip(abiS[14]);
    }
    public void PlayAbiS15()
    {
        PlayClip(abiS[15]);
    }
    public void PlayAbiS16()
    {
        PlayClip(abiS[16]);
    }
    public void PlayAbiS17()
    {
        PlayClip(abiS[17]);
    }
    public void PlayJoe0()
    {
        PlayClip(joeR[0]);
    }
    public void PlayJoe1()
    {
        PlayClip(joeR[1]);
    }
    public void PlayJohnF0()
    {
        PlayClip(johnF[0]);
    }
    public void PlayJohnF1()
    {
        PlayClip(johnF[1]);
    }
    public void PlayJohnF2()
    {
        PlayClip(johnF[2]);
    }
    public void PlayJohnF3()
    {
        PlayClip(johnF[3]);
    }
    public void PlayJohnF4()
    {
        PlayClip(johnF[4]);
    }
    public void PlayJohnF5()
    {
        PlayClip(johnF[5]);
    }
    public void PlayJohnF6()
    {
        PlayClip(johnF[6]);
    }
    public void PlayJohnK0()
    {
        PlayClip(johnK[0]);
    }
    public void PlayLiamO0()
    {
        PlayClip(liamO[0]);
    }
    public void PlayLiamO1()
    {
        PlayClip(liamO[1]);
    }
    public void PlayMattO0()
    {
        PlayClip(mattO[0]);
    }
    private void PlayClip(AudioClip clipToPlay)
    {
        myAudioSource.clip = clipToPlay;
        myAudioSource.Play();
    }

}
