using UnityEngine;
using System.Collections;

[System.Flags]
public enum DamageStatusEffect
{
	None   = 1 << 0,
	Impact = 1 << 1,
	Puncture = 1 << 2,
	Slash   = 1 << 3,
	Cold   = 1 << 4,
	Electricity	= 1 << 5,
	Heat	= 1 << 6,
	Toxin	= 1 << 7,
	Blast	= (1 << 6)|(1 << 4),
	Corrosive = (1 << 5)|(1 << 7),
	Gas = (1 << 6)|(1 << 7),
	Magnetic = (1 << 4)|(1 << 5),
	Radiation = (1 << 5)|(1 << 6),
	Viral = (1 << 4)|(1 << 7)
}



