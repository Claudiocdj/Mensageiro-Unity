using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SetColorAndSprite : MonoBehaviour
{
    public Sprite[] houses;

    public Color[] colors;

    void Awake()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        sr.color = colors[Random.Range( 0, colors.Length )];

        sr.sprite = houses[Random.Range( 0, houses.Length )];
    }
}
