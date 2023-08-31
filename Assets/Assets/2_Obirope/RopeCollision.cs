using Obi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCollision : MonoBehaviour
{
    private ObiSolver _solver;
    private void Awake()
    {
        _solver = GetComponent<ObiSolver>();
    }
    private void OnEnable()
    {
        _solver.OnParticleCollision += Solver_OnParticleCollision;
        _solver.OnCollision += Solver_OnCollision;
    }

    private void OnDisable()
    {
        _solver.OnParticleCollision -= Solver_OnParticleCollision;
        _solver.OnCollision += Solver_OnCollision;

    }
    private void Solver_OnParticleCollision(object sender, ObiSolver.ObiCollisionEventArgs e)
    {
        //if (GameManager.Instance.State is not GameState.Checking)
        //{
        //    return;
        //}
        //standaloneRopes.Clear();

        //GameManager.Instance.State = GameState.Waiting;
        //List<GameObject> rope = new List<GameObject>();
        //for (int i = 0; i < ropes.Count; i++)
        //{
        //    if (ropes[i].activeSelf)
        //    {
        //        rope.Add(ropes[i]);
        //    }
        //}
        //Debug.Log(_solver.particleToActor.Length);

        var world = ObiColliderWorld.GetInstance();
        foreach (var contact in e.contacts)
        {

            // this one is an actual collision:
            //Debug.Log(contact.pointA + " pt");
            if (true || contact.distance < 0.01f)
            {

                int particleIndexA = _solver.simplices[contact.bodyA];
                int particleIndexB = _solver.simplices[contact.bodyB];

                var pa = _solver.particleToActor[particleIndexA];
                var po = _solver.particleToActor[particleIndexB];

                //Debug.Log(pa.actor.gameObject.name);
                //Debug.Log(po.actor.gameObject.name);

                //Debug.Log(particleIndexA + " " + particleIndexB);
                if (pa.actor.gameObject != po.actor.gameObject)
                {
                    // Debug.Log(pa.actor.gameObject.name + " collides with: " + po.actor.gameObject.name);
                    //if (rope.Contains(pa.actor.gameObject))
                    //{
                    //    rope.Remove(pa.actor.gameObject);
                    //}

                    //if (rope.Contains(po.actor.gameObject))
                    //{
                    //    rope.Remove(po.actor.gameObject);
                    //}
                }
            }
        }

    }

    void Solver_OnCollision(object sender, Obi.ObiSolver.ObiCollisionEventArgs e)
    {
        var world = ObiColliderWorld.GetInstance();
        // just iterate over all contacts in the current frame:
        foreach (Oni.Contact contact in e.contacts)
        {
            // if this one is an actual collision:
            if (contact.distance < 0.01)
            {

                ObiColliderBase col1 = world.colliderHandles[contact.bodyB].owner;
                int particleIndexA = _solver.simplices[contact.bodyA];
                int particleIndexB = _solver.simplices[contact.bodyB];
                var pa = _solver.particleToActor[particleIndexA];
                var po = _solver.particleToActor[particleIndexB];

                Debug.Log(pa.actor.gameObject.name);
                Debug.Log(po.actor.gameObject.name);
                //if (!col1.CompareTag("Ground"))
                //{

                //}
            }

        }
    }

}
