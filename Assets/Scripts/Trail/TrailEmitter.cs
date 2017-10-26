using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Trails;

namespace Trails
{
    // Created by Edward Kay-Coles a.k.a Hoeloe
    public class TrailEmitter : MonoBehaviour
    {
        public float extendTime;

        //Stores all live trails
        private LinkedList<Trail> trails = new LinkedList<Trail>();

        //Parameters
        public float width = 0.1f;
        public float decayTime = 1f;
        public Material material;
        public int roughness = 0;
        public bool softSourceEnd = false;
        public Transform Ptr;

        private Trail lastTrail;

        //Checks if the most recent trail is active or not
        public bool Active
        {
            get { return (trails.Count == 0 ? false : (!trails.Last.Value.Finished)); }
        }

        // Update is called once per frame
        void Update()
        {
            //Don't update if there are no trails
            if (trails.Count == 0) return;

            //Essentially a foreach loop, allowing trails to be removed from the list if they are finished
            LinkedListNode<Trail> t = trails.First;
            LinkedListNode<Trail> n;
            do
            {
                n = t.Next;
                t.Value.Update();
                if (t.Value.Dead)
                    trails.Remove(t);
                t = n;
            } while (n != null);
            if (Input.GetKeyDown(KeyCode.Q))
            {
                //material.color = Color.black;
                material.color = Ptr.GetComponent<Material>().color;
            }


        }

        /// <summary>
        /// Creates a new trail.
        /// </summary>
        public void NewTrail()
        {
            //Stops emitting the last trail and passes the parameters onto a new one
            // EndTrail();

            if (trails.Count != 0)
            {
                // lastTrail = trails.Last.Value;
                StartCoroutine("EndTrail", trails.Last.Value);
            }
            var mat = new Material(material);
            trails.AddLast(new Trail(transform, mat, decayTime, roughness, softSourceEnd, width));
        }

        IEnumerator EndTrail(Trail trail)
        {
            yield return new WaitForSeconds(extendTime);
            // if (!Active) return;

            //lastTrail.Finish();
            trail.Finish();
        }

        /// <summary>
        /// Deactivate the last trail if it was already active.
        /// </summary>
        public void EndTrail()
        {
            if (!Active) return;
            trails.Last.Value.Finish();
        }

    }
}