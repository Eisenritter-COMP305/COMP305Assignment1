using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        public TextMeshPro livesLable;


        //Public Properties
        //[Header("Scoreboard")]
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

        public void ResetScore()
        {
            _score = 0;
        }


        // Start is called before the first frame update
        void Start()
        {
            ResetScore();
            Score = 0;
        }

        // Update is called once per frame
        void Update()
        {
            scoreLable.text = $"Score: {Score}";
        }
    }
}
