using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2Profile
{
	class Program
	{
		static int Main(string[] args)
		{
			if (args.Length < 1) return 1;

			B2Profile profile = new B2Profile();

			if (profile.Read(args[0]) == false)
			{
				return 1;
			}

			Console.WriteLine("Golden Keys: " + profile.GoldenKeys);
			Console.WriteLine("Badass Rank: " + profile.BadassRank);
			Console.WriteLine("Badass Tokens: " + profile.BadassTokens);
			Console.WriteLine("Used Badass Tokens: " + profile.BadassTokensUsed);
			Console.WriteLine("Earned Badass Tokens: " + profile.BadassTokensEarned);
			Console.WriteLine();

			Console.WriteLine("Bonus Maximum Health: " + profile.GetMaximumHealth());
			Console.WriteLine("Bonus Shield Capacity: " + profile.GetShieldCapacity());
			Console.WriteLine("Bonus Shield Recharge Delay: " + profile.GetShieldRechargeDelay());
			Console.WriteLine("Bonus Shield Recharge Rate: " + profile.GetShieldRechargeRate());
			Console.WriteLine("Bonus Melee Damage: " + profile.GetMeleeDamage());
			Console.WriteLine("Bonus Grenade Damage: " + profile.GetGrenadeDamage());
			Console.WriteLine("Bonus Gun Accuracy: " + profile.GetGunAccuracy());
			Console.WriteLine("Bonus Gun Damage: " + profile.GetGunDamage());
			Console.WriteLine("Bonus Fire Rate: " + profile.GetFireRate());
			Console.WriteLine("Bonus Recoil Reduction: " + profile.GetRecoilReduction());
			Console.WriteLine("Bonus Reload Speed: " + profile.GetReloadSpeed());
			Console.WriteLine("Bonus Elemental Effect Chance: " + profile.GetElementalEffectChance());
			Console.WriteLine("Bonus Elemental Effect Damage: " + profile.GetElementalEffectDamage());
			Console.WriteLine("Bonus Critical Hit Damage: " + profile.GetCriticalHitDamage());

			if (profile.Write("profile_out.bin") == false)
			{
				return 1;
			}

			return 0;
		}
	}
}
