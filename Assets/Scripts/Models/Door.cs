using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GGJ
{
    public class Door : Obstacle
    {
        public bool isOpened;
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void OpenDoor()
        {
            isOpened = true;
            GetComponent<Animator>().enabled = true;
        }
        public override void DoEffect()
        {
            if (isOpened)
            {
                GameManager.Instance.WinGame();
            }
            else
            {
                GameManager.Instance.LoseGame();
            }
        }
    }
}