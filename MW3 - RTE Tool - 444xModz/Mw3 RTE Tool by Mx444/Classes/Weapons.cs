using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Weapons
    {
        //Mw3 Weapons List by Bytes:
        #region WeaponList
        public static class WeaponList
        {
            //3 Bytes: 0x00,0x00,0x00
            //First is 2nd Attachment
            //Second is 1st Attachment + Camo
            //Third is Weapon
            public static class Seatown
            {
                public static byte[] DefaultWeapon = new byte[] { 0x00, 0x00, 0x01 };
                public static byte[] Stick = new byte[] { 0x00, 0x00, 0x02 };
                public static byte[] RiotShield = new byte[] { 0x00, 0x00, 0x03 };
                public static byte[] RiotShield_2 = new byte[] { 0x00, 0x00, 0x04 };
                public static byte[] Magnum_44 = new byte[] { 0x00, 0x00, 0x05 };
                public static byte[] USP_45 = new byte[] { 0x00, 0x00, 0x06 };
                public static byte[] USP_45_2 = new byte[] { 0x00, 0x00, 0x07 };
                public static byte[] Desert_Eagle = new byte[] { 0x00, 0x00, 0x08 };
                public static byte[] MP412 = new byte[] { 0x00, 0x00, 0x09 };
                public static byte[] MP412_2 = new byte[] { 0x00, 0x00, 0x0A };
                public static byte[] P99 = new byte[] { 0x00, 0x00, 0x0B };
                public static byte[] Five_Seven = new byte[] { 0x00, 0x00, 0x0C };
                public static byte[] FMG9 = new byte[] { 0x00, 0x00, 0x0D };
                public static byte[] Skorpion = new byte[] { 0x00, 0x00, 0x0E };
                public static byte[] MP9 = new byte[] { 0x00, 0x00, 0x0F };
                public static byte[] G18 = new byte[] { 0x00, 0x00, 0x10 };
                public static byte[] MP5 = new byte[] { 0x00, 0x00, 0x11 };
                public static byte[] PM_9 = new byte[] { 0x00, 0x00, 0x12 };
                public static byte[] P90 = new byte[] { 0x00, 0x00, 0x13 };
                public static byte[] PP90M1 = new byte[] { 0x00, 0x00, 0x14 };
                public static byte[] UMP45 = new byte[] { 0x00, 0x00, 0x15 };
                public static byte[] MP7 = new byte[] { 0x00, 0x00, 0x16 };
                public static byte[] AK47 = new byte[] { 0x00, 0x00, 0x17 };
                public static byte[] M16A4 = new byte[] { 0x00, 0x00, 0x18 };
                public static byte[] M4A1 = new byte[] { 0x00, 0x00, 0x19 };
                public static byte[] FAD = new byte[] { 0x00, 0x00, 0x1A };
                public static byte[] ACR6_8 = new byte[] { 0x00, 0x00, 0x1B };
                public static byte[] Type95 = new byte[] { 0x00, 0x00, 0x1C };
                public static byte[] MK14 = new byte[] { 0x00, 0x00, 0x1D };
                public static byte[] SCAR_L = new byte[] { 0x00, 0x00, 0x1E };
                public static byte[] G36C = new byte[] { 0x00, 0x00, 0x1F };
                public static byte[] CM901 = new byte[] { 0x00, 0x00, 0x20 };
                public static byte[] M203 = new byte[] { 0x00, 0x00, 0x21 };
                public static byte[] M320_GLM = new byte[] { 0x00, 0x00, 0x22 };
                public static byte[] RPG = new byte[] { 0x00, 0x00, 0x23 };
                public static byte[] SMAW = new byte[] { 0x00, 0x00, 0x24 };
                public static byte[] Stinger = new byte[] { 0x00, 0x00, 0x25 };
                public static byte[] Javelin = new byte[] { 0x00, 0x00, 0x26 };
                public static byte[] XM25 = new byte[] { 0x00, 0x00, 0x27 };
                public static byte[] Dragunov = new byte[] { 0x00, 0x00, 0x28 };
                public static byte[] MSR = new byte[] { 0x00, 0x00, 0x29 };
                public static byte[] Barret_50Cal = new byte[] { 0x00, 0x00, 0x2A };
                public static byte[] RSASS = new byte[] { 0x00, 0x00, 0x2B };
                public static byte[] AS50 = new byte[] { 0x00, 0x00, 0x2C };
                public static byte[] L118A = new byte[] { 0x00, 0x00, 0x2D };
                public static byte[] KSG12 = new byte[] { 0x00, 0x00, 0x2E };
                public static byte[] Model1887 = new byte[] { 0x00, 0x00, 0x2F };
                public static byte[] Striker = new byte[] { 0x00, 0x00, 0x30 };
                public static byte[] AA_12 = new byte[] { 0x00, 0x00, 0x31 };
                public static byte[] USAS_12 = new byte[] { 0x00, 0x00, 0x32 };
                public static byte[] SPAS12 = new byte[] { 0x00, 0x00, 0x33 };
                public static byte[] M60E4_Juggernaut = new byte[] { 0x00, 0x00, 0x34 };
                public static byte[] AUG_HBAR = new byte[] { 0x04, 0x06, 0x34 };
                public static byte[] M60E4 = new byte[] { 0x00, 0x00, 0x35 };
                public static byte[] MK46 = new byte[] { 0x00, 0x00, 0x36 };
                public static byte[] PKP_PECHENEG = new byte[] { 0x00, 0x00, 0x37 };
                public static byte[] L86_LSW = new byte[] { 0x00, 0x00, 0x38 };
                public static byte[] MG36 = new byte[] { 0x00, 0x00, 0x39 };
                public static byte[] C4 = new byte[] { 0x00, 0x00, 0x3A };
                public static byte[] C4_Glitch /*(Throw it, and after 8 seconds, it blowing)*/ = new byte[] { 0x00, 0x00, 0x3B };
                public static byte[] Claymore = new byte[] { 0x00, 0x00, 0x3C };
                public static byte[] Trophy_System = new byte[] { 0x00, 0x00, 0x3D };
                public static byte[] MZ3_Designanator /*(F2000)*/ = new byte[] { 0x00, 0x00, 0x3E };
                public static byte[] Scrambler = new byte[] { 0x00, 0x00, 0x3F };
                public static byte[] NoWeapon = new byte[] { 0x00, 0x00, 0x40 };
                public static byte[] Semtex = new byte[] { 0x00, 0x00, 0x41 };
                public static byte[] Frag = new byte[] { 0x00, 0x00, 0x42 };
                public static byte[] Flash = new byte[] { 0x00, 0x00, 0x43 };
                public static byte[] Smoke = new byte[] { 0x00, 0x00, 0x44 };
                public static byte[] Stun = new byte[] { 0x00, 0x00, 0x45 };
                public static byte[] EMP_Grande = new byte[] { 0x00, 0x00, 0x46 };
                public static byte[] Throwing_Knife = new byte[] { 0x00, 0x00, 0x47 };
                public static byte[] Bouncing_Betty = new byte[] { 0x00, 0x00, 0x48 };
                public static byte[] Tactical_Insertion = new byte[] { 0x00, 0x00, 0x49 };
                public static byte[] Flashing_Weapon = new byte[] { 0x00, 0x00, 0x4A };
                public static byte[] Frag_2 = new byte[] { 0x00, 0x00, 0x4B };
                public static byte[] NoWeapon_2 = new byte[] { 0x00, 0x00, 0x4C };
                public static byte[] NoWeapon_3 = new byte[] { 0x00, 0x00, 0x4D };
                public static byte[] Portable_Radar /*(Fake)*/ = new byte[] { 0x00, 0x00, 0x4E };
                public static byte[] Bomb = new byte[] { 0x00, 0x00, 0x4F };
                public static byte[] Bomb_2 = new byte[] { 0x00, 0x00, 0x50 };
                public static byte[] Phone = new byte[] { 0x00, 0x00, 0x5F };
                public static byte[] Laptop = new byte[] { 0x00, 0x00, 0x52 };
                public static byte[] Phone_2 = new byte[] { 0x00, 0x00, 0x62 };
                public static byte[] Laptop_2 = new byte[] { 0x00, 0x00, 0x56 };
                public static byte[] Airdrop_Marker = new byte[] { 0x00, 0x00, 0x5D };
                public static byte[] Vest = new byte[] { 0x00, 0x00, 0x60 };
                public static byte[] Airdrop_Trap_Marker = new byte[] { 0x00, 0x00, 0x61 };
                public static byte[] Airdrop_Escort_Marker = new byte[] { 0x00, 0x00, 0x66 };
                public static byte[] AC130_25mm = new byte[] { 0x00, 0x00, 0x67 };
                public static byte[] AC130_40mm = new byte[] { 0x00, 0x00, 0x68 };
                public static byte[] AC130_105mm = new byte[] { 0x00, 0x00, 0x69 };
                public static byte[] Stinger_Bullet = new byte[] { 0x00, 0x00, 0x6A };
                public static byte[] Javelin_Fake = new byte[] { 0x00, 0x00, 0x6B };
                public static byte[] Harriar_Bullets = new byte[] { 0x00, 0x00, 0x6F };
                public static byte[] Harriar_Rockets = new byte[] { 0x00, 0x00, 0x70 };
                public static byte[] Helicopter_Bullets = new byte[] { 0x00, 0x00, 0x71 };
                public static byte[] Frag_Airdrop_Trap /*(Explode like carapackage trap)*/ = new byte[] { 0x00, 0x00, 0x72 };
                public static byte[] Osprey_Vision = new byte[] { 0x00, 0x00, 0x73 };
                public static byte[] Strafe_Run = new byte[] { 0x00, 0x00, 0x74 };
                public static byte[] Pavelow_Bullets = new byte[] { 0x00, 0x00, 0x75 };
                public static byte[] EscortAirdrop_Bullets = new byte[] { 0x00, 0x00, 0x76 };
                public static byte[] Ripper_Vision = new byte[] { 0x00, 0x00, 0x7F };
                public static byte[] Ripper_Vision_Other = new byte[] { 0x00, 0x00, 0x80 };
                public static byte[] Walking_IMS = new byte[] { 0x00, 0x00, 0x81 };
                public static byte[] Remote_Sentry_Bullets = new byte[] { 0x00, 0x00, 0x82 }; //Must give IMS Before using this, otherwise its freeze!
                public static byte[] Remote_Sentry_Vision = new byte[] { 0x00, 0x00, 0x84 };
                public static byte[] Recon_Drone_Vision = new byte[] { 0x00, 0x00, 0x85 };
                public static byte[] Recon_Drone_Weapon = new byte[] { 0x00, 0x00, 0x86 };
                public static byte[] AssaultDrone_Vision = new byte[] { 0x00, 0x00, 0x89 };
                public static byte[] AssaultDrone_Rockets = new byte[] { 0x00, 0x00, 0x8A };
                public static byte[] Osprey_Bullets = new byte[] { 0x00, 0x00, 0x7D };
            }
            public static class Dome
            {
                public static byte[] DefaultWeapon = new byte[] { 0x00, 0x00, 0x02 };
                public static byte[] Stick = new byte[] { 0x00, 0x00, 0x03 };
                public static byte[] RiotShield = new byte[] { 0x00, 0x00, 0x04 };
                public static byte[] RiotShield_2 = new byte[] { 0x00, 0x00, 0x05 };
                public static byte[] Magnum_44 = new byte[] { 0x00, 0x00, 0x06 };
                public static byte[] USP_45 = new byte[] { 0x00, 0x00, 0x07 };
                public static byte[] USP_45_2 = new byte[] { 0x00, 0x00, 0x08 };
                public static byte[] Desert_Eagle = new byte[] { 0x00, 0x00, 0x09 };
                public static byte[] MP412 = new byte[] { 0x00, 0x00, 0x0A };
                public static byte[] MP412_2 = new byte[] { 0x00, 0x00, 0x0B };
                public static byte[] P99 = new byte[] { 0x00, 0x00, 0x0C };
                public static byte[] Five_Seven = new byte[] { 0x00, 0x00, 0x0D };
                public static byte[] FMG9 = new byte[] { 0x00, 0x00, 0x0E };
                public static byte[] Skorpion = new byte[] { 0x00, 0x00, 0x0F };
                public static byte[] MP9 = new byte[] { 0x00, 0x00, 0x10 };
                public static byte[] G18 = new byte[] { 0x00, 0x00, 0x11 };
                public static byte[] MP5 = new byte[] { 0x00, 0x00, 0x12 };
                public static byte[] PM_9 = new byte[] { 0x00, 0x00, 0x13 };
                public static byte[] P90 = new byte[] { 0x00, 0x00, 0x14 };
                public static byte[] PP90M1 = new byte[] { 0x00, 0x00, 0x15 };
                public static byte[] UMP45 = new byte[] { 0x00, 0x00, 0x16 };
                public static byte[] MP7 = new byte[] { 0x00, 0x00, 0x17 };
                public static byte[] AK47 = new byte[] { 0x00, 0x00, 0x18 };
                public static byte[] M16A4 = new byte[] { 0x00, 0x00, 0x19 };
                public static byte[] M4A1 = new byte[] { 0x00, 0x00, 0x1A };
                public static byte[] FAD = new byte[] { 0x00, 0x00, 0x1B };
                public static byte[] ACR6_8 = new byte[] { 0x00, 0x00, 0x1C };
                public static byte[] Type95 = new byte[] { 0x00, 0x00, 0x1D };
                public static byte[] MK14 = new byte[] { 0x00, 0x00, 0x1E };
                public static byte[] SCAR_L = new byte[] { 0x00, 0x00, 0x1F };
                public static byte[] G36C = new byte[] { 0x00, 0x00, 0x20 };
                public static byte[] CM901 = new byte[] { 0x00, 0x00, 0x21 };
                public static byte[] M203 = new byte[] { 0x00, 0x00, 0x22 };
                public static byte[] M320_GLM = new byte[] { 0x00, 0x00, 0x23 };
                public static byte[] RPG = new byte[] { 0x00, 0x00, 0x24 };
                public static byte[] SMAW = new byte[] { 0x00, 0x00, 0x25 };
                public static byte[] Stinger = new byte[] { 0x00, 0x00, 0x26 };
                public static byte[] Javelin = new byte[] { 0x00, 0x00, 0x27 };
                public static byte[] XM25 = new byte[] { 0x00, 0x00, 0x28 };
                public static byte[] Dragunov = new byte[] { 0x00, 0x00, 0x29 };
                public static byte[] MSR = new byte[] { 0x00, 0x00, 0x2A };
                public static byte[] Barret_50Cal = new byte[] { 0x00, 0x00, 0x2B };
                public static byte[] RSASS = new byte[] { 0x00, 0x00, 0x2C };
                public static byte[] AS50 = new byte[] { 0x00, 0x00, 0x2D };
                public static byte[] L118A = new byte[] { 0x00, 0x00, 0x2E };
                public static byte[] KSG12 = new byte[] { 0x00, 0x00, 0x2F };
                public static byte[] Model1887 = new byte[] { 0x00, 0x00, 0x30 };
                public static byte[] Striker = new byte[] { 0x00, 0x00, 0x31 };
                public static byte[] AA_12 = new byte[] { 0x00, 0x00, 0x32 };
                public static byte[] USAS_12 = new byte[] { 0x00, 0x00, 0x33 };
                public static byte[] SPAS12 = new byte[] { 0x00, 0x00, 0x34 };
                public static byte[] M60E4_Juggernaut = new byte[] { 0x00, 0x00, 0x35 };
                public static byte[] M60E4 = new byte[] { 0x00, 0x00, 0x36 };
                public static byte[] MK46 = new byte[] { 0x00, 0x00, 0x37 };
                public static byte[] PKP_PECHENEG = new byte[] { 0x00, 0x00, 0x38 };
                public static byte[] L86_LSW = new byte[] { 0x00, 0x00, 0x39 };
                public static byte[] MG36 = new byte[] { 0x00, 0x00, 0x3A };
                public static byte[] C4 = new byte[] { 0x00, 0x00, 0x3B };
                public static byte[] C4_Glitch /*(Throw it, and after 8 seconds, it blowing)*/ = new byte[] { 0x00, 0x00, 0x3C };
                public static byte[] Claymore = new byte[] { 0x00, 0x00, 0x3D };
                public static byte[] Trophy_System = new byte[] { 0x00, 0x00, 0x3E };
                public static byte[] MZ3_Designanator /*(F2000)*/ = new byte[] { 0x00, 0x00, 0x3F };
                public static byte[] Scrambler = new byte[] { 0x00, 0x00, 0x40 };
                public static byte[] NoWeapon = new byte[] { 0x00, 0x00, 0x41 };
                public static byte[] Semtex = new byte[] { 0x00, 0x00, 0x42 };
                public static byte[] Frag = new byte[] { 0x00, 0x00, 0x43 };
                public static byte[] Flash = new byte[] { 0x00, 0x00, 0x44 };
                public static byte[] Smoke = new byte[] { 0x00, 0x00, 0x45 };
                public static byte[] Stun = new byte[] { 0x00, 0x00, 0x46 };
                public static byte[] EMP_Grande = new byte[] { 0x00, 0x00, 0x47 };
                public static byte[] Throwing_Knife = new byte[] { 0x00, 0x00, 0x48 };
                public static byte[] Bouncing_Betty = new byte[] { 0x00, 0x00, 0x49 };
                public static byte[] Tactical_Insertion = new byte[] { 0x00, 0x00, 0x4A };
                public static byte[] Flashing_Weapon = new byte[] { 0x00, 0x00, 0x4B };
                public static byte[] Frag_2 = new byte[] { 0x00, 0x00, 0x4C };
                public static byte[] NoWeapon_2 = new byte[] { 0x00, 0x00, 0x4D };
                public static byte[] NoWeapon_3 = new byte[] { 0x00, 0x00, 0x4E };
                public static byte[] Portable_Radar /*(Fake)*/ = new byte[] { 0x00, 0x00, 0x4F };
                public static byte[] Bomb = new byte[] { 0x00, 0x00, 0x50 };
                public static byte[] Bomb_2 = new byte[] { 0x00, 0x00, 0x51 };
                public static byte[] Phone = new byte[] { 0x00, 0x00, 0x60 };
                public static byte[] Laptop = new byte[] { 0x00, 0x00, 0x53 };
                public static byte[] Phone_2 = new byte[] { 0x00, 0x00, 0x63 };
                public static byte[] Laptop_2 = new byte[] { 0x00, 0x00, 0x57 };
                public static byte[] Airdrop_Marker = new byte[] { 0x00, 0x00, 0x5E };
                public static byte[] Vest = new byte[] { 0x00, 0x00, 0x61 };
                public static byte[] Airdrop_Trap_Marker = new byte[] { 0x00, 0x00, 0x62 };
                public static byte[] Airdrop_Escort_Marker = new byte[] { 0x00, 0x00, 0x67 };
                public static byte[] AC130_25mm = new byte[] { 0x00, 0x00, 0x68 };
                public static byte[] AC130_40mm = new byte[] { 0x00, 0x00, 0x69 };
                public static byte[] AC130_105mm = new byte[] { 0x00, 0x00, 0x6A };
                public static byte[] Stinger_Bullet = new byte[] { 0x00, 0x00, 0x6B };
                public static byte[] Javelin_Fake = new byte[] { 0x00, 0x00, 0x6C };
                public static byte[] Harriar_Bullets = new byte[] { 0x00, 0x00, 0x70 };
                public static byte[] Harriar_Rockets = new byte[] { 0x00, 0x00, 0x71 };
                public static byte[] Helicopter_Bullets = new byte[] { 0x00, 0x00, 0x72 };
                public static byte[] Frag_Airdrop_Trap /*(Explode like carapackage trap)*/ = new byte[] { 0x00, 0x00, 0x73 };
                public static byte[] Osprey_Vision = new byte[] { 0x00, 0x00, 0x74 };
                public static byte[] Strafe_Run = new byte[] { 0x00, 0x00, 0x75 };
                public static byte[] Pavelow_Bullets = new byte[] { 0x00, 0x00, 0x76 };
                public static byte[] EscortAirdrop_Bullets = new byte[] { 0x00, 0x00, 0x77 };
                public static byte[] Ripper_Vision = new byte[] { 0x00, 0x00, 0x80 };
                public static byte[] Ripper_Vision_Other = new byte[] { 0x00, 0x00, 0x81 };
                public static byte[] Walking_IMS = new byte[] { 0x00, 0x00, 0x82 };
                public static byte[] Remote_Sentry_Bullets = new byte[] { 0x00, 0x00, 0x83 }; //Must give IMS Before using this, otherwise its freeze!
                public static byte[] Remote_Sentry_Vision = new byte[] { 0x00, 0x00, 0x85 };
                public static byte[] Recon_Drone_Vision = new byte[] { 0x00, 0x00, 0x86 };
                public static byte[] Recon_Drone_Weapon = new byte[] { 0x00, 0x00, 0x87 };
                public static byte[] AssaultDrone_Vision = new byte[] { 0x00, 0x00, 0x8A };
                public static byte[] AssaultDrone_Rockets = new byte[] { 0x00, 0x00, 0x8B };
                public static byte[] Osprey_Bullets = new byte[] { 0x00, 0x00, 0x7E };
            }
        }
        #endregion
         #region Offsets
        public static class Offsets
        {
            public static uint Akimbo_Secondary = 0x0110a531;
            public static uint Akimbo_Primary = 0x0110a549;
            public static uint GrandeLuncherBullets = 0x0110a6b4;
            public static uint GrandeLuncherClip = 0x0110a630;
            public static class Primary
            {
                public static uint
                    Weapon1 = 0x0110a4fd,
                    Weapon2 = 0x0110a5f1,
                    Weapon3 = 0x0110a6a5,
                    AmmoClip = 0x0110a628,
                    AmmoBullets = Primary.Weapon3 + 0x3,// = 0x0110a6a8,
                    AkimboAmmo = 0x0110a6ac;
            }
            public static class Secondary
            {
                public static uint
                    Weapon1 = 0x0110a4f5,
                    Weapon2 = 0x0110a5f1,
                    Weapon3 = 0x0110a68d,
                    AmmoClip = 0x0110a618,
                    AmmoBullets = Secondary.Weapon3 + 0x3,// = 0x0110a690
                    AkimboAmmo = 0x0110a694;
            }
            public static class _3Weapon
            {
                public static uint
                    Weapon1 = 0x0110a505,
                    Weapon2 = 0x0110a63d,
                    Weapon3 = 0x0110a6c9,
                    AmmoBullets = _3Weapon.Weapon3 + 0x3, // = 0x0110a640
                    AmmoClip = _3Weapon.Weapon2 + 0x3; // = 0x0110a6cc
            }
            public static class _4Weapon
            {
                public static uint
                    Weapon1 = 0x0110a509,
                    Weapon2 = 0x0110a645,
                    Weapon3 = 0x0110a6d5,
                    AmmoBullets = _4Weapon.Weapon3 + 0x3, // = 0x0110a648
                    AmmoClip = _4Weapon.Weapon2 + 0x3; // = 0x0110a6d8
            }
            public static class _5Weapon
            {
                public static uint
                    Weapon1 = 0x0110a50d,
                    Weapon2 = 0x0110a64d,
                    Weapon3 = 0x0110a6e1,
                    AmmoBullets = _5Weapon.Weapon3 + 0x3, // = 0x0110a6e4
                    AmmoClip = _5Weapon.Weapon2 + 0x3; // = 0x0110a6d8
            }
            public static class _6Weapon
            {
                public static uint
                    Weapon1 = 0x0110a511,
                    Weapon2 = 0x0110a655,
                    Weapon3 = 0x0110a6bd,
                    AmmoBullets = _6Weapon.Weapon3 + 0x3, // = 0x0110a6c0
                    AmmoClip = _6Weapon.Weapon2 + 0x3; // = 0x0110a658
            }
            public static class Tactical
            {
                public static uint
                    Weapon1 = 0x0110a501,
                    Weapon2 = 0x0110a635,
                    Weapon3 = 0x0110a6bd,
                    AmmoBullets = Tactical.Weapon3 + 0x3, // = 0x0110a6c0
                    AmmoClip = Tactical.Weapon2 + 0x3; // = 0x0110a638
            }
            public static class Lethal
            {
                public static uint
                    Weapon1 = 0x0110a4f9,
                    Weapon2 = 0x0110a61d,
                    Weapon3 = 0x0110a6c9,
                    AmmoBullets = Lethal.Weapon3 + 0x3, // = 0x0110a620
                    AmmoClip = Lethal.Weapon2 + 0x3, // = 0x0110a6cc
                    RealAmmo = 0x0110a69c;
            }
        }
        #endregion
 
         #region Bullet
        #region map
        class map
               {
        public static bool SetUp1 = (((((((getMapName() == "Seatown") | (getMapName() == "Arkaden")) |
                          (getMapName() == "Downturn")) | (getMapName() == "Bootleg")) | (getMapName() == "Lockdown")) |
                          (getMapName() == "Village")) | (getMapName() == "Mission"));
               }
        #endregion
        #region GetMapDetails
 
        private static String ReturnInfos(Int32 Index)
        {
            return Encoding.ASCII.GetString(Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.GetBytes(0X008360d5, 0x100)).Replace(@"\", "|").Split('|')[Index];
        }
        public static String getMapName()
        {
            String Map = ReturnInfos(6);
            switch (Map)
            {
                default: return "Unknown Map";
                case "mp_alpha": return "Lockdown";
                case "mp_bootleg": return "Bootleg";
                case "mp_bravo": return "Mission";
                case "mp_carbon": return "Carbon";
                case "mp_dome": return "Dome";
                case "mp_exchange": return "Downturn";
                case "mp_hardhat": return "Hardhat";
                case "mp_interchange": return "Interchange";
                case "mp_lambeth": return "Fallen";
                case "mp_mogadishu": return "Bakaara";
                case "mp_paris": return "Resistance";
                case "mp_plaza2": return "Arkaden";
                case "mp_radar": return "Outpost";
                case "mp_seatown": return "Seatown";
                case "mp_underground": return "Underground";
                case "mp_village": return "Village";
                case "mp_aground_ss": return "Aground";
                case "mp_cement": return "Foundation";
                case "mp_hillside_ss": return "Getaway";
                case "mp_italy": return "Piazza";
                case "mp_meteora": return "Sanctuary";
                case "mp_morningwood": return "Black Box";
                case "mp_overwatch": return "Overwatch";
                case "mp_park": return "Liberation";
                case "mp_qadeem": return "Oasis";
                case "mp_restrepo_ss": return "Lookout";
                case "mp_terminal_cls": return "Terminal";
            }
        }
        public String getGameMode()
        {
            String GM = ReturnInfos(2);
            switch (GM)
            {
                default: return "Unknown Gametype";
                case "war": return "Team Deathmatch";
                case "dm": return "Free for All";
                case "sd": return "Search and Destroy";
                case "dom": return "Domination";
                case "conf": return "Kill Confirmed";
                case "sab": return "Sabotage";
                case "koth": return "Head Quartes";
                case "ctf": return "Capture The Flag";
                case "infect": return "Infected";
                case "sotf": return "Hunted";
                case "dd": return "Demolition";
                case "grnd": return "Drop Zone";
                case "tdef": return "Team Defender";
                case "tjugg": return "Team Juggernaut";
                case "jugg": return "Juggernaut";
                case "gun": return "Gun Game";
                case "oic": return "One In The Chamber";
 
            }
        }
        public String getHostName()
        {
            String Host = ReturnInfos(16);
            if (Host == "Modern Warfare 3")
                return "Dedicated Server (No Player is Host)";
            else if (Host == "")
                return "You are not In-Game";
            else return Host;
        }
        #endregion
 
 
 
       
 
 
        #region Weapons
        public static void Rockets(uint client)
        {
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory((Offsets.Akimbo_Secondary + ((uint)client * 0x3980)), new byte[] { 0x00 });//Remove the akimbo, to prevent Freeze issus!
            byte[] Rocket_Dome = WeaponList.Dome.Harriar_Rockets;
            byte[] Rocket_Seatown = WeaponList.Seatown.Harriar_Rockets;
            if (map.SetUp1)
            {
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon1 + (0x3980 * client), Rocket_Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon2 + (0x3980 * client), Rocket_Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon3 + (0x3980 * client), Rocket_Seatown);
            }
            else//If the maps are not the maps that are on "SetUp1"(The maps dome and etc)
            {
                //It will give diffrent bytes
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon1 + (0x3980 * client), Rocket_Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon2 + (0x3980 * client), Rocket_Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon3 + (0x3980 * client), Rocket_Dome);
            }
            //And Ammo:
            byte[] UltimateAmmo = new byte[] { 0x0F, 0xFF, 0xFF, 0xFF };
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.AkimboAmmo + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.AmmoBullets + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.AmmoClip + (0x3980 * client), UltimateAmmo);
        }
        #endregion
 
        #region AC130
        #region RemovenecessaryStuff
        public static void RemovenecessaryStuff(UInt32 client)
        {
            byte[] Remove = new byte[] { 0x00, 0, 0 };
            byte[] RemoveAkimbo = new byte[] { 0x00 };
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets._3Weapon.Weapon1 + (client * 0x3980), Remove);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets._3Weapon.Weapon2 + (client * 0x3980), Remove);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets._3Weapon.Weapon3 + (client * 0x3980), Remove);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets._4Weapon.Weapon1 + (client * 0x3980), Remove);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets._4Weapon.Weapon2 + (client * 0x3980), Remove);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets._4Weapon.Weapon3 + (client * 0x3980), Remove);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets._5Weapon.Weapon1 + (client * 0x3980), Remove);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets._5Weapon.Weapon2 + (client * 0x3980), Remove);
        }
        #endregion
 
        #region 25mm
 
        public static void AC130_25mm(UInt32 client)
        {
            byte[] _25Dome = WeaponList.Dome.AC130_25mm;
            byte[] _25Seatown = WeaponList.Seatown.AC130_25mm;
            RemovenecessaryStuff(client);
            if (map.SetUp1)
            {
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon1 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon2 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon3 + (client * 0x3980), _25Seatown);
                //Now the secondary need to have the same bytes aswell, so:
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon1 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon2 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon3 + (client * 0x3980), _25Seatown);
            }
            else//For the other maps...
            {
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon1 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon2 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon3 + (client * 0x3980), _25Dome);
                //Now the secondary need to have the same bytes aswell, so:
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon1 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon2 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon3 + (client * 0x3980), _25Dome);
            }
            //And Ammo:
            byte[] UltimateAmmo = new byte[] { 0x0F, 0xFF, 0xFF, 0xFF };
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.AkimboAmmo + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.AmmoBullets + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.AmmoClip + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.AkimboAmmo + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.AmmoBullets + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.AmmoClip + (0x3980 * client), UltimateAmmo);
        }
        public static void AC130_40mm(UInt32 client)
        {
            byte[] _25Dome = WeaponList.Dome.AC130_40mm;
            byte[] _25Seatown = WeaponList.Seatown.AC130_40mm;
            RemovenecessaryStuff(client);
            if (map.SetUp1)
            {
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon1 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon2 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon3 + (client * 0x3980), _25Seatown);
                //Now the secondary need to have the same bytes aswell, so:
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon1 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon2 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon3 + (client * 0x3980), _25Seatown);
            }
            else//For the other maps...
            {
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon1 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon2 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon3 + (client * 0x3980), _25Dome);
                //Now the secondary need to have the same bytes aswell, so:
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon1 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon2 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon3 + (client * 0x3980), _25Dome);
            }
            //And Ammo:
            byte[] UltimateAmmo = new byte[] { 0x0F, 0xFF, 0xFF, 0xFF };
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.AkimboAmmo + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.AmmoBullets + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.AmmoClip + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.AkimboAmmo + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.AmmoBullets + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.AmmoClip + (0x3980 * client), UltimateAmmo);
        }
        public static void Pavelow(UInt32 client)
        {
            byte[] _25Dome = WeaponList.Dome.Pavelow_Bullets;
            byte[] _25Seatown = WeaponList.Seatown.Pavelow_Bullets;
            RemovenecessaryStuff(client);
            if (map.SetUp1)
            {
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon1 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon2 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon3 + (client * 0x3980), _25Seatown);
                //Now the secondary need to have the same bytes aswell, so:
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon1 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon2 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon3 + (client * 0x3980), _25Seatown);
            }
            else//For the other maps...
            {
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon1 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon2 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon3 + (client * 0x3980), _25Dome);
                //Now the secondary need to have the same bytes aswell, so:
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon1 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon2 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon3 + (client * 0x3980), _25Dome);
            }
            //And Ammo:
            byte[] UltimateAmmo = new byte[] { 0x0F, 0xFF, 0xFF, 0xFF };
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.AkimboAmmo + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.AmmoBullets + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.AmmoClip + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.AkimboAmmo + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.AmmoBullets + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.AmmoClip + (0x3980 * client), UltimateAmmo);
        }
        public static void helicopter(UInt32 client)
        {
            byte[] _25Dome = WeaponList.Dome.Helicopter_Bullets;
            byte[] _25Seatown = WeaponList.Seatown.Helicopter_Bullets;
            RemovenecessaryStuff(client);
            if (map.SetUp1)
            {
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon1 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon2 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon3 + (client * 0x3980), _25Seatown);
                //Now the secondary need to have the same bytes aswell, so:
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon1 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon2 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon3 + (client * 0x3980), _25Seatown);
            }
            else//For the other maps...
            {
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon1 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon2 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon3 + (client * 0x3980), _25Dome);
                //Now the secondary need to have the same bytes aswell, so:
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon1 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon2 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon3 + (client * 0x3980), _25Dome);
            }
            //And Ammo:
            byte[] UltimateAmmo = new byte[] { 0x0F, 0xFF, 0xFF, 0xFF };
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.AkimboAmmo + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.AmmoBullets + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.AmmoClip + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.AkimboAmmo + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.AmmoBullets + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.AmmoClip + (0x3980 * client), UltimateAmmo);
        }
        public static void osprey(UInt32 client)
        {
            byte[] _25Dome = WeaponList.Dome.Osprey_Bullets;
            byte[] _25Seatown = WeaponList.Seatown.Osprey_Bullets;
            RemovenecessaryStuff(client);
            if (map.SetUp1)
            {
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon1 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon2 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon3 + (client * 0x3980), _25Seatown);
                //Now the secondary need to have the same bytes aswell, so:
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon1 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon2 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon3 + (client * 0x3980), _25Seatown);
            }
            else//For the other maps...
            {
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon1 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon2 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon3 + (client * 0x3980), _25Dome);
                //Now the secondary need to have the same bytes aswell, so:
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon1 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon2 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon3 + (client * 0x3980), _25Dome);
            }
            //And Ammo:
            byte[] UltimateAmmo = new byte[] { 0x0F, 0xFF, 0xFF, 0xFF };
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.AkimboAmmo + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.AmmoBullets + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.AmmoClip + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.AkimboAmmo + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.AmmoBullets + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.AmmoClip + (0x3980 * client), UltimateAmmo);
        }
        public static void IMS(UInt32 client)
        {
            byte[] _25Dome = WeaponList.Dome.Walking_IMS;
            byte[] _25Seatown = WeaponList.Seatown.Walking_IMS;
            RemovenecessaryStuff(client);
            if (map.SetUp1)
            {
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon1 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon2 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon3 + (client * 0x3980), _25Seatown);
                //Now the secondary need to have the same bytes aswell, so:
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon1 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon2 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon3 + (client * 0x3980), _25Seatown);
            }
            else//For the other maps...
            {
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon1 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon2 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon3 + (client * 0x3980), _25Dome);
                //Now the secondary need to have the same bytes aswell, so:
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon1 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon2 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon3 + (client * 0x3980), _25Dome);
            }
            //And Ammo:
            byte[] UltimateAmmo = new byte[] { 0x0F, 0xFF, 0xFF, 0xFF };
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.AkimboAmmo + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.AmmoBullets + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.AmmoClip + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.AkimboAmmo + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.AmmoBullets + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.AmmoClip + (0x3980 * client), UltimateAmmo);
        }
        public static void Bomb(UInt32 client)
        {
            byte[] _25Dome = WeaponList.Dome.Bomb;
            byte[] _25Seatown = WeaponList.Seatown.Bomb;
            RemovenecessaryStuff(client);
            if (map.SetUp1)
            {
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon1 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon2 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon3 + (client * 0x3980), _25Seatown);
                //Now the secondary need to have the same bytes aswell, so:
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon1 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon2 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon3 + (client * 0x3980), _25Seatown);
            }
            else//For the other maps...
            {
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon1 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon2 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon3 + (client * 0x3980), _25Dome);
                //Now the secondary need to have the same bytes aswell, so:
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon1 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon2 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon3 + (client * 0x3980), _25Dome);
            }
            //And Ammo:
            byte[] UltimateAmmo = new byte[] { 0x0F, 0xFF, 0xFF, 0xFF };
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.AkimboAmmo + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.AmmoBullets + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.AmmoClip + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.AkimboAmmo + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.AmmoBullets + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.AmmoClip + (0x3980 * client), UltimateAmmo);
        }
        public static void Lap(UInt32 client)
        {
            byte[] _25Dome = WeaponList.Dome.Laptop;
            byte[] _25Seatown = WeaponList.Seatown.Laptop;
            RemovenecessaryStuff(client);
            if (map.SetUp1)
            {
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon1 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon2 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon3 + (client * 0x3980), _25Seatown);
                //Now the secondary need to have the same bytes aswell, so:
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon1 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon2 + (client * 0x3980), _25Seatown);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon3 + (client * 0x3980), _25Seatown);
            }
            else//For the other maps...
            {
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon1 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon2 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.Weapon3 + (client * 0x3980), _25Dome);
                //Now the secondary need to have the same bytes aswell, so:
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon1 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon2 + (client * 0x3980), _25Dome);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.Weapon3 + (client * 0x3980), _25Dome);
            }
            //And Ammo:
            byte[] UltimateAmmo = new byte[] { 0x0F, 0xFF, 0xFF, 0xFF };
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.AkimboAmmo + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.AmmoBullets + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Secondary.AmmoClip + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.AkimboAmmo + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.AmmoBullets + (0x3980 * client), UltimateAmmo);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offsets.Primary.AmmoClip + (0x3980 * client), UltimateAmmo);
        }
        #endregion
        #endregion
        #endregion
    }

