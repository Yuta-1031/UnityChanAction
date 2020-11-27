using UnityEngine;
using System.Collections;

namespace Footsteps
{
	public class PlayerForward : MonoBehaviour
	{
		public GameObject player;

		void Start()
		{


		}
        private void Update()
        {
			player.transform.Find("Player");
			player.GetComponent<Transform>();

			this.transform.position = player.transform.position;
        }
    }
}
