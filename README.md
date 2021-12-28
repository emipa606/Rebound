# Rebound

![Image](https://i.imgur.com/buuPQel.png)

Update of AKreedz mod
https://steamcommunity.com/sharedfiles/filedetails/?id=1692393812

A brief explanation of the mod as I understand it:
 - New trait: Sword Master, low natural chance but automatically added when pawn has 20 in Melee
 - Bullets can be rebounded as long as pawn has a Melee-weapon, but player-pawns must be drafted.
 - Rebound-chance 0.5 * [Manipulation value, max 100%] * (Melee-skill / 10)
	* Example - Manipulation-value: 105%, Melee-skill: 18
		0.5 * 1 * 1.8 = 0.9 = 90% chance
 - Only projectiles that would have hit the pawn can be rebounded
 - Weapon has a chance to take durability-damage when rebounding
	0.4 * (Melee-skill/5)
 - At 1 durability the weapon is thrown to the ground to avoid getting destroyed
 - Projectiles that are too fast cannot be rebounded, speed-limit can be changed in settings.
- Added support for https://steamcommunity.com/sharedfiles/filedetails/?id=2451324814][SYR] Trait Value
- Traditional Chinese translation added, thanks shiuanyue!
- Added a setting to just block the projectiles
- Added setting for disabling automatically getting the rebound trait at melee skill 20
- Added settings for the weapon-damage and base rebound-chance
- Added CE-support

![Image](https://i.imgur.com/pufA0kM.png)

	
![Image](https://i.imgur.com/Z4GOv8H.png)


For those who came in due to the steam name being in english, but no english description, here is a google translate for you. (By Umbreonic Wizard )

New Features: Sword Master
Low probability random occurrence
This feature is also obtained when the colony's fighting level reaches level 20.

Bullet counter condition:
In the recruitment of colonists, armed with melee weapons (non-colonials do not need to be recruited)

Projection counter probability calculation:
Bomb anti- chance = 50% x colonizer operation ability (up to 100%) x (colonial combat level ÷ 10)

Weapon damage probability calculation:
Damaged chance = 40% ÷ (colonial combat level ÷ 5);
Every time the damaged weapon is lowered 1 Durable
Weapons are automatically thrown to the ground when they reach 1


![Image](https://i.imgur.com/PwoNOj4.png)



-  See if the the error persists if you just have this mod and its requirements active.
-  If not, try adding your other mods until it happens again.
-  Post your error-log using https://steamcommunity.com/workshop/filedetails/?id=818773962]HugsLib and command Ctrl+F12
-  For best support, please use the Discord-channel for error-reporting.
-  Do not report errors by making a discussion-thread, I get no notification of that.
-  If you have the solution for a problem, please post it to the GitHub repository.



