using UnityEngine;
using System.Collections;
using System;

namespace Pathfinding
{
    /// <summary>
    /// Sets the destination of an AI to the position of a specified object.
    /// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
    /// This component will then make the AI move towards the <see cref="target"/> set on this component.
    ///
    /// See: <see cref="Pathfinding.IAstarAI.destination"/>
    ///
    /// [Open online documentation to see images]
    /// </summary>
    [UniqueComponent(tag = "ai.destination")]
    [HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
    public class AIDestinationSetter : VersionedMonoBehaviour
    {
        /// <summary>The object that the AI should move to</summary>
        public Transform target;
        IAstarAI ai;
        public Transform[] ruta;
        private int indiceRuta;

        void Start()
        {
            //ai.updateRotation = false;
            //ai.updateUpAxis = false;
            indiceRuta = 0;
        }

        void OnEnable()
        {
            ai = GetComponent<IAstarAI>();
            // Update the destination right before searching for a path as well.
            // This is enough in theory, but this script will also update the destination every
            // frame as the destination is used for debugging and may be used for other things by other
            // scripts as well. So it makes sense that it is up to date every frame.
            if (ai != null) ai.onSearchPath += Update;
        }

        void OnDisable()
        {
            if (ai != null) ai.onSearchPath -= Update;
        }

        /// <summary>Updates the AI's destination every frame</summary>
        void Update()
        {
            if (Math.Abs(ai.position.x - target.position.x) <= 9 && Math.Abs(ai.position.y - target.position.y) <= 1)
            {
                if (target != null && ai != null) ai.destination = target.position;
            }
            else if (this.transform.position.x.ToString("00") == ruta[indiceRuta].position.x.ToString("00") && this.transform.position.y.ToString("00") == ruta[indiceRuta].position.y.ToString("00"))
            {
                if (indiceRuta < ruta.Length - 1)
                {
                    indiceRuta++;
                    
                }
                else if (indiceRuta == ruta.Length - 1)
                {
                    indiceRuta = 0;
                    
                }
                ai.destination = ruta[indiceRuta].position;
                
            }
        }

    }
}
