using UnityEngine;

public class Meteror : MonoBehaviour
{
    // public variables
    public SphereCollider sphereCol;
    public ParticleSystem trail;

    void OnCollisionEnter(Collision other)
    {
        Quaternion rot = Quaternion.LookRotation(this.transform.position.normalized);
        rot *= Quaternion.Euler(90f, 0f, 0f);
        GameObject craterChild = Instantiate(GameManager.instance.createrPrefab, other.contacts[0].point, rot);

        sphereCol.enabled = false;
        trail.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        Destroy(this.gameObject, 4f);
    }
}