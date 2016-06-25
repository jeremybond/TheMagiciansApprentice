//Created By: Jeremy Bond
//Date: 27/03/2016

using UnityEngine;
using System.Collections;

namespace Utils
{
	public class AudioChannel : MonoBehaviour
	{	
		public float Volume
		{
			set
			{
				audioSource.volume = Mathf.Clamp01 (value);
			}
			get
			{
				return audioSource.volume;
			}
		}

		public float Pitch
		{
			set
			{
				audioSource.pitch = Mathf.Clamp01 (value);
			}
			get
			{
				return audioSource.pitch;
			}
		}

		public float StereoPan
		{
			set
			{
				audioSource.panStereo = Mathf.Clamp01 (value);
			}
			get
			{
				return audioSource.panStereo;
			}
		}

		public float SpatialBlend
		{
			set
			{
				audioSource.spatialBlend = Mathf.Clamp01 (value);
			}
			get
			{
				return audioSource.spatialBlend;
			}
		}

		public float ReverbZoneMix
		{
			set
			{
				audioSource.reverbZoneMix = Mathf.Clamp (value, 0, 1.1f);
			}
			get
			{
				return audioSource.reverbZoneMix;
			}
		}

		public bool Mute
		{
			set
			{
				audioSource.mute = value;
			}
			get
			{
				return audioSource.mute;
			}
		}

		public bool Loop
		{
			set
			{
				audioSource.loop = value;
			}
			get
			{
				return audioSource.loop;
			}
		}

		public bool IsPlaying
		{
			get
			{
				return audioSource.isPlaying && !paused;
			}
		}

		private AudioSource audioSource;
		private bool paused;

		protected void Awake ()
		{
			audioSource = GetComponent<AudioSource> ();
			audioSource.playOnAwake = false;
		}
		
		internal void Play (AudioClip audioObject)
		{
			audioSource.clip = audioObject;
			audioSource.Play ();
		}

		public void Pause ()
		{
			audioSource.Pause ();
			paused = true;
		}

		public void UnPause ()
		{
			audioSource.UnPause ();
			paused = false;
		}

		public void Stop ()
		{
			audioSource.Stop ();
		}
	}


}