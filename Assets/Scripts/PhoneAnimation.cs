using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PhoneAnimation : MonoBehaviour
{

    [SerializeField] private Sprite[] animationSprites = new Sprite[100];

    public Image image;
    int imageIndex;

    float timeBetweenFrames = 0.02f;
    float counter;
    void Update()
    {
        counter += Time.deltaTime;
        if (counter > timeBetweenFrames)
        {
            counter = 0;
            imageIndex++;
            if (imageIndex >= animationSprites.Length)
            {
                imageIndex = 0;
            }
            image.sprite = animationSprites[imageIndex];
        }

    }
}