using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackDisplay : MonoBehaviour {

    public Pack pack;

    public Image artworkImage;

    private void Start()
    {
        artworkImage.sprite = pack.artwork;
    }
}