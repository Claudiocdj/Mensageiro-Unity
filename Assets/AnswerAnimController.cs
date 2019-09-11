using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public class AnswerAnimController : MonoBehaviour
{
    [SerializeField]
    private Sprite winSprite;
    [SerializeField]
    private Sprite failSprite;

    private SpriteRenderer sr;

    private Animator an;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        an = GetComponent<Animator>();
    }

    public void SetWinAnim()
    {
        sr.sprite = winSprite;

        sr.color = Color.green;

        an.SetTrigger("show");
    }

    public void SetFailAnim()
    {
        sr.sprite = failSprite;

        sr.color = Color.red;

        an.SetTrigger( "show" );
    }
}
