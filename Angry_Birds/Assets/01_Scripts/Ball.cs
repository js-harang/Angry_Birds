using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D hook;

    public float releaseTime = 0.15f;
    public float maxDragDistance = 2;

    public GameObject nextBall;

    public bool isPressed = false;

    private void Update()
    {
        if (isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
                rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
            else
                rb.position = mousePos;
        }
    }

    private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
        SoundManager.sm.Bgm(0);
    }

    private void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;
        SoundManager.sm.Bgm(1);
        StartCoroutine(Release());
    }

    private IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);

        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;

        yield return new WaitForSeconds(5f);


        if (nextBall != null)
            nextBall.SetActive(true);
        else
        {
            Enemy.enemiesAlive = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
