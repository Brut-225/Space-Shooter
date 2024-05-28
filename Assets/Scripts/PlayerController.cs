using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public UnityEvent OnPlayerHealthChanged = new();

    public float Speed = 10.0f;
    public float ShootCooldown = 0.25f;
    public GameObject LaserPrefab;
    public List<GameObject> LaserPoints = new List<GameObject>();
    public int Life = 3;

    private Camera cam;
    private Renderer rend;
    private float objectWidth;
    private Collider2D collider2d;

    private float NextFire = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rend = GetComponent<Renderer>();
        objectWidth = rend.bounds.size.x;
        collider2d = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead())
        {
            return;
        }


#if !UNITY_EDITOR
        float acceleration = Input.acceleration.x;
#else
        float acceleration = Input.GetAxis("Horizontal");
#endif


        float moveX = acceleration * Speed;

        Vector3 position = transform.position;
        position.x += moveX * Time.deltaTime;

        if (position.x < GetMinBounds())
        {
            position.x = GetMinBounds();
        }

        if (position.x > GetMaxBounds())
        {
            position.x = GetMaxBounds();
        }

        transform.position = position;

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public bool IsDead()
    {
        return Life <= 0;
    }

    public void TakeDamage()
    {
        if (IsDead())
        {
            return;
        }

        Life--;
        if (Life <= 0)
        {
            StartCoroutine(RestartGame());
            rend.enabled = false;
            collider2d.enabled = false;
        }
        OnPlayerHealthChanged.Invoke();
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(2.0f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    void Shoot()
    {
        if (IsDead())
        {
            return;
        }

        if (Time.time < NextFire)
        {
            return;
        }

        NextFire = Time.time + ShootCooldown;
        foreach (var point in LaserPoints)
        {
            Instantiate(LaserPrefab, point.transform.position, Quaternion.identity);
        }
    }

    float GetMinBounds()
    {
        var minX = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane)).x + objectWidth / 2;
        return minX;
    }

    float GetMaxBounds()
    {
        var maxX = cam.ViewportToWorldPoint(new Vector3(1, 0, cam.nearClipPlane)).x - objectWidth / 2;
        return maxX;
    }
}
