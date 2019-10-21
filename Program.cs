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

			if (profile.Load(args[0]) == false)
			{
				Console.WriteLine("Error loading " + args[0]);

				return 1;
			}

#if true
			Console.WriteLine("Input:");
			Console.WriteLine();

			Console.WriteLine("Golden Keys POPremierClub Valid: " + profile.GetGoldenKeysPOPremierClubEntry().Valid);
			Console.WriteLine("Golden Keys POPremierClub NumKeys: " + profile.GetGoldenKeysPOPremierClubEntry().NumKeys);
			Console.WriteLine("Golden Keys POPremierClub NumKeysUsed: " + profile.GetGoldenKeysPOPremierClubEntry().NumKeysUsed);
			Console.WriteLine();

			Console.WriteLine("Golden Keys Tulip Valid: " + profile.GetGoldenKeysTulipEntry().Valid);
			Console.WriteLine("Golden Keys Tulip NumKeys: " + profile.GetGoldenKeysTulipEntry().NumKeys);
			Console.WriteLine("Golden Keys Tulip NumKeysUsed: " + profile.GetGoldenKeysTulipEntry().NumKeysUsed);
			Console.WriteLine();

			Console.WriteLine("Golden Keys SHiFT Valid: " + profile.GetGoldenKeysShiftEntry().Valid);
			Console.WriteLine("Golden Keys SHiFT NumKeys: " + profile.GetGoldenKeysShiftEntry().NumKeys);
			Console.WriteLine("Golden Keys SHiFT NumKeysUsed: " + profile.GetGoldenKeysShiftEntry().NumKeysUsed);
			Console.WriteLine();

			Console.WriteLine("Badass Rank: " + profile.GetBadassRank());
			Console.WriteLine("Badass Tokens: " + profile.GetBadassTokens());
			Console.WriteLine("Earned Badass Tokens: " + profile.GetBadassTokensEarned());
			Console.WriteLine();

			Console.WriteLine("Bonus Maximum Health: " + profile.GetMaximumHealthBonus());
			Console.WriteLine("Bonus Shield Capacity: " + profile.GetShieldCapacityBonus());
			Console.WriteLine("Bonus Shield Recharge Delay: " + profile.GetShieldRechargeDelayBonus());
			Console.WriteLine("Bonus Shield Recharge Rate: " + profile.GetShieldRechargeRateBonus());
			Console.WriteLine("Bonus Melee Damage: " + profile.GetMeleeDamageBonus());
			Console.WriteLine("Bonus Grenade Damage: " + profile.GetGrenadeDamageBonus());
			Console.WriteLine("Bonus Gun Accuracy: " + profile.GetGunAccuracyBonus());
			Console.WriteLine("Bonus Gun Damage: " + profile.GetGunDamageBonus());
			Console.WriteLine("Bonus Fire Rate: " + profile.GetFireRateBonus());
			Console.WriteLine("Bonus Recoil Reduction: " + profile.GetRecoilReductionBonus());
			Console.WriteLine("Bonus Reload Speed: " + profile.GetReloadSpeedBonus());
			Console.WriteLine("Bonus Elemental Effect Chance: " + profile.GetElementalEffectChanceBonus());
			Console.WriteLine("Bonus Elemental Effect Damage: " + profile.GetElementalEffectDamageBonus());
			Console.WriteLine("Bonus Critical Hit Damage: " + profile.GetCriticalHitDamageBonus());
#endif

#if false
			Console.WriteLine();

			Console.WriteLine("Output:");
			Console.WriteLine();

			Console.WriteLine("Golden Keys POPremierClub Valid: " + profile.GetGoldenKeysPOPremierClubEntry().Valid);
			Console.WriteLine("Golden Keys POPremierClub NumKeys: " + profile.GetGoldenKeysPOPremierClubEntry().NumKeys);
			Console.WriteLine("Golden Keys POPremierClub NumKeysUsed: " + profile.GetGoldenKeysPOPremierClubEntry().NumKeysUsed);
			Console.WriteLine();

			Console.WriteLine("Golden Keys Tulip Valid: " + profile.GetGoldenKeysTulipEntry().Valid);
			Console.WriteLine("Golden Keys Tulip NumKeys: " + profile.GetGoldenKeysTulipEntry().NumKeys);
			Console.WriteLine("Golden Keys Tulip NumKeysUsed: " + profile.GetGoldenKeysTulipEntry().NumKeysUsed);
			Console.WriteLine();

			Console.WriteLine("Golden Keys SHiFT Valid: " + profile.GetGoldenKeysShiftEntry().Valid);
			Console.WriteLine("Golden Keys SHiFT NumKeys: " + profile.GetGoldenKeysShiftEntry().NumKeys);
			Console.WriteLine("Golden Keys SHiFT NumKeysUsed: " + profile.GetGoldenKeysShiftEntry().NumKeysUsed);
			Console.WriteLine();

			Console.WriteLine("Badass Rank: " + profile.GetBadassRank());
			Console.WriteLine("Badass Tokens: " + profile.GetBadassTokens());
			Console.WriteLine("Earned Badass Tokens: " + profile.GetBadassTokensEarned());
			Console.WriteLine();

			Console.WriteLine("Bonus Maximum Health: " + profile.GetMaximumHealthBonus());
			Console.WriteLine("Bonus Shield Capacity: " + profile.GetShieldCapacityBonus());
			Console.WriteLine("Bonus Shield Recharge Delay: " + profile.GetShieldRechargeDelayBonus());
			Console.WriteLine("Bonus Shield Recharge Rate: " + profile.GetShieldRechargeRateBonus());
			Console.WriteLine("Bonus Melee Damage: " + profile.GetMeleeDamageBonus());
			Console.WriteLine("Bonus Grenade Damage: " + profile.GetGrenadeDamageBonus());
			Console.WriteLine("Bonus Gun Accuracy: " + profile.GetGunAccuracyBonus());
			Console.WriteLine("Bonus Gun Damage: " + profile.GetGunDamageBonus());
			Console.WriteLine("Bonus Fire Rate: " + profile.GetFireRateBonus());
			Console.WriteLine("Bonus Recoil Reduction: " + profile.GetRecoilReductionBonus());
			Console.WriteLine("Bonus Reload Speed: " + profile.GetReloadSpeedBonus());
			Console.WriteLine("Bonus Elemental Effect Chance: " + profile.GetElementalEffectChanceBonus());
			Console.WriteLine("Bonus Elemental Effect Damage: " + profile.GetElementalEffectDamageBonus());
			Console.WriteLine("Bonus Critical Hit Damage: " + profile.GetCriticalHitDamageBonus());
#endif

			if (profile.Save("profile.bin") == false)
			{
				Console.WriteLine("Error saving profile.bin");

				return 1;
			}

			return 0;
		}
	}
}
