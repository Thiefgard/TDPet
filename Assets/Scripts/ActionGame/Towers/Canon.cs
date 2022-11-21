using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] float _timeInAir = 0.4f;
    [SerializeField] float _explosionRadius;
    [SerializeField] int _damage;
    private Rigidbody _rb;

    public void Fire(Vector3 startPos, Vector3 target, int damage)
    {
        _damage = damage;
        LaunchCanopyProjectile(startPos, target, _timeInAir);
    }
    private void OnTriggerEnter(Collider other)
    {
        IDamagable target = other.gameObject.GetComponent<IDamagable>();
        if(target != null)
        {
            Explosion();
            Destroy(this.gameObject);
        }
        RoadTile road = other.gameObject.GetComponent<RoadTile>();
        if(road != null)
        {
            Explosion();
            Destroy(this.gameObject);
        }
    }
    //Explosion of Canon
    private void Explosion()
    {
        Destroy(_rb);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _explosionRadius);
        foreach(Collider collider in hitColliders)
        {
            IDamagable target = collider.GetComponent<IDamagable>();
            if(target != null)
            {
                target.GetDamage(_damage);
            }
        }
        
    }

    
    private void LaunchCanopyProjectile(Vector3 start, Vector3 end, float timeCorrection = 1f)
    {
        float time = GetTime(start, end, timeCorrection);
        Vector3 v = CalculateVelocity(start, end, time);
        transform.rotation = Quaternion.LookRotation(v);
        _rb = gameObject.AddComponent(typeof(Rigidbody)).GetComponent<Rigidbody>();
        _rb.angularDrag = 0f;
        _rb.mass = 10f;
        _rb.velocity = v;
    }
    //calculate time in air by distance
    private float GetTime(Vector3 start, Vector3 end, float timeCorrection = 1f)
    {
        return Vector3.Distance(start, end) * Time.fixedDeltaTime + timeCorrection;
    }
    //Calculate curve by Distance;
    private Vector3 CalculateVelocity(Vector3 start, Vector3 end, float time)
    {
        //define the distance x and y first
        Vector3 distance = end - start;
        Vector3 distance_x_z = distance;
        distance_x_z.Normalize();
        distance_x_z.y = 0;

        //creating a float that represents our distance 
        float sy = distance.y;
        float sxz = distance.magnitude;

        //calculating initial x velocity
        float Vxz = sxz / time;

        ////calculating initial y velocity
        float Vy = sy / time + 0.502f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distance_x_z * Vxz;
        result.y = Vy;

        return result;
    }
}
