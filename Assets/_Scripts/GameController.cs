/*******************************************/
/*       Created By: George Zhou           */
/*       Student ID: 300613283             */
/*******************************************/

// This is the game controller script, meant to be attached to a empty game object

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //This is required for TextMeshPro Control

namespace Util
{
    [System.Serializable]
    public class GameController: MonoBehaviour
    {
        [Header("Scene Game Objects")]
        public GameObject enemies;
        public GameObject projectile;

        [Header("Audio Manager")]
        public SoundClip soundClip;
        public AudioSource[] audioSources;

        
        [SerializeField]
        private int _score { get; set; }
        [SerializeField]
        public TextMeshProUGUI scoreLable;

        [SerializeField]
        private int _lives { get; set; }
        [SerializeField]
        public TextMeshProUGUI livesLable;

        public int Score {
            get
            {
                return _score;
            }
            set {
                _score = value;
            }
        }

        public int Lives
        {
            get
            {
                return _lives;
            }
            set
            {
                _lives = value;
            }
        }


        //Scoring System
        public void AddScore()
        {
            _score+=50;
        }

        public void ResetAll()
        {
            _score = 0;
            _lives = 5;
        }


        // Start is called before the first frame update
        void Start()
        {
            AudioSource activeAudioSource = audioSources[(int)soundClip];
            activeAudioSource.playOnAwake = true;
            activeAudioSource.loop = true;
            activeAudioSource.Play();

            ResetAll();
            Score = 0;
            Lives = 5;
        }

        // Update is called once per frame
        void Update()
        {
            scoreLable.text = $"Score: {Score}";
            livesLable.text = $"Lives: {Lives}";
        }
    }
}
