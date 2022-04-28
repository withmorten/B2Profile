using System;
using B2Profile;

namespace B2ProfileCMD
{
	class Program
	{
		static int Main(string[] args)
		{
			if (args.Length < 1) return 1;

			Profile profile = new Profile();

			if (profile.Load(args[0], true) == false)
			{
				Console.WriteLine("Error loading " + args[0]);

				return 1;
			}

			// Just some examples what you can do with this ...

			// default we just dump the profile.bin contents to stdout and exit
#if true
			profile.PrintEntries();

			return 0;
#endif

			// Dump some data before editing ...
#if false
			Console.WriteLine("Input:");
			Console.WriteLine();

			Console.WriteLine("Golden Keys POPremierClub Valid: " + profile.GoldenKeysPOPremierClub.IsValid());
			Console.WriteLine("Golden Keys POPremierClub NumKeys: " + profile.GoldenKeysPOPremierClub.GetNumKeys());
			Console.WriteLine("Golden Keys POPremierClub NumKeysUsed: " + profile.GoldenKeysPOPremierClub.GetNumKeysUsed());
			Console.WriteLine();

			Console.WriteLine("Golden Keys Tulip Valid: " + profile.GoldenKeysTulip.IsValid());
			Console.WriteLine("Golden Keys Tulip NumKeys: " + profile.GoldenKeysTulip.GetNumKeys());
			Console.WriteLine("Golden Keys Tulip NumKeysUsed: " + profile.GoldenKeysTulip.GetNumKeysUsed());
			Console.WriteLine();

			Console.WriteLine("Golden Keys SHiFT Valid: " + profile.GoldenKeysShift.IsValid());
			Console.WriteLine("Golden Keys SHiFT NumKeys: " + profile.GoldenKeysShift.GetNumKeys());
			Console.WriteLine("Golden Keys SHiFT NumKeysUsed: " + profile.GoldenKeysShift.GetNumKeysUsed());
			Console.WriteLine();

			Console.WriteLine("Badass Rank: " + profile.BadassRank);
			Console.WriteLine("Badass Tokens: " + profile.BadassTokensAvailable);
			Console.WriteLine("Earned Badass Tokens: " + profile.BadassTokensEarned);
			Console.WriteLine();

			Console.WriteLine("Bonus Maximum Health: " + profile.BonusStats[Profile.BonusStatID.MaximumHealth]);
			Console.WriteLine("Bonus Shield Capacity: " + profile.BonusStats[Profile.BonusStatID.ShieldCapacity]);
			Console.WriteLine("Bonus Shield Recharge Delay: " + profile.BonusStats[Profile.BonusStatID.ShieldRechargeDelay]);
			Console.WriteLine("Bonus Shield Recharge Rate: " + profile.BonusStats[Profile.BonusStatID.ShieldRechargeRate]);
			Console.WriteLine("Bonus Melee Damage: " + profile.BonusStats[Profile.BonusStatID.MeleeDamage]);
			Console.WriteLine("Bonus Grenade Damage: " + profile.BonusStats[Profile.BonusStatID.GrenadeDamage]);
			Console.WriteLine("Bonus Gun Accuracy: " + profile.BonusStats[Profile.BonusStatID.GunAccuracy]);
			Console.WriteLine("Bonus Gun Damage: " + profile.BonusStats[Profile.BonusStatID.GunDamage]);
			Console.WriteLine("Bonus Fire Rate: " + profile.BonusStats[Profile.BonusStatID.FireRate]);
			Console.WriteLine("Bonus Recoil Reduction: " + profile.BonusStats[Profile.BonusStatID.RecoilReduction]);
			Console.WriteLine("Bonus Reload Speed: " + profile.BonusStats[Profile.BonusStatID.ReloadSpeed]);
			Console.WriteLine("Bonus Elemental Effect Chance: " + profile.BonusStats[Profile.BonusStatID.ElementalEffectChance]);
			Console.WriteLine("Bonus Elemental Effect Damage: " + profile.BonusStats[Profile.BonusStatID.ElementalEffectDamage]);
			Console.WriteLine("Bonus Critical Hit Damage: " + profile.BonusStats[Profile.BonusStatID.CriticalHitDamage]);
#endif

			// Set all key entries to max (765 keys total)
#if false
			profile.GoldenKeysPOPremierClub.SetNumKeys(Profile.MaxGoldenKeys);
			profile.GoldenKeysPOPremierClub.SetNumKeysUsed(0);

			profile.GoldenKeysTulip.SetNumKeys(Profile.MaxGoldenKeys);
			profile.GoldenKeysTulip.SetNumKeysUsed(0);

			profile.GoldenKeysShift.SetNumKeys(Profile.MaxGoldenKeys);
			profile.GoldenKeysShift.SetNumKeysUsed(0);
#endif

			// Dump some data after editing ...
#if false
			Console.WriteLine();

			Console.WriteLine("Output:");
			Console.WriteLine();

			Console.WriteLine("Golden Keys POPremierClub Valid: " + profile.GoldenKeysPOPremierClub.IsValid());
			Console.WriteLine("Golden Keys POPremierClub NumKeys: " + profile.GoldenKeysPOPremierClub.GetNumKeys());
			Console.WriteLine("Golden Keys POPremierClub NumKeysUsed: " + profile.GoldenKeysPOPremierClub.GetNumKeysUsed());
			Console.WriteLine();

			Console.WriteLine("Golden Keys Tulip Valid: " + profile.GoldenKeysTulip.IsValid());
			Console.WriteLine("Golden Keys Tulip NumKeys: " + profile.GoldenKeysTulip.GetNumKeys());
			Console.WriteLine("Golden Keys Tulip NumKeysUsed: " + profile.GoldenKeysTulip.GetNumKeysUsed());
			Console.WriteLine();

			Console.WriteLine("Golden Keys SHiFT Valid: " + profile.GoldenKeysShift.IsValid());
			Console.WriteLine("Golden Keys SHiFT NumKeys: " + profile.GoldenKeysShift.GetNumKeys());
			Console.WriteLine("Golden Keys SHiFT NumKeysUsed: " + profile.GoldenKeysShift.GetNumKeysUsed());
			Console.WriteLine();

			Console.WriteLine("Badass Rank: " + profile.BadassRank);
			Console.WriteLine("Badass Tokens: " + profile.BadassTokensAvailable);
			Console.WriteLine("Earned Badass Tokens: " + profile.BadassTokensEarned);
			Console.WriteLine();

			Console.WriteLine("Bonus Maximum Health: " + profile.BonusStats[Profile.BonusStatID.MaximumHealth]);
			Console.WriteLine("Bonus Shield Capacity: " + profile.BonusStats[Profile.BonusStatID.ShieldCapacity]);
			Console.WriteLine("Bonus Shield Recharge Delay: " + profile.BonusStats[Profile.BonusStatID.ShieldRechargeDelay]);
			Console.WriteLine("Bonus Shield Recharge Rate: " + profile.BonusStats[Profile.BonusStatID.ShieldRechargeRate]);
			Console.WriteLine("Bonus Melee Damage: " + profile.BonusStats[Profile.BonusStatID.MeleeDamage]);
			Console.WriteLine("Bonus Grenade Damage: " + profile.BonusStats[Profile.BonusStatID.GrenadeDamage]);
			Console.WriteLine("Bonus Gun Accuracy: " + profile.BonusStats[Profile.BonusStatID.GunAccuracy]);
			Console.WriteLine("Bonus Gun Damage: " + profile.BonusStats[Profile.BonusStatID.GunDamage]);
			Console.WriteLine("Bonus Fire Rate: " + profile.BonusStats[Profile.BonusStatID.FireRate]);
			Console.WriteLine("Bonus Recoil Reduction: " + profile.BonusStats[Profile.BonusStatID.RecoilReduction]);
			Console.WriteLine("Bonus Reload Speed: " + profile.BonusStats[Profile.BonusStatID.ReloadSpeed]);
			Console.WriteLine("Bonus Elemental Effect Chance: " + profile.BonusStats[Profile.BonusStatID.ElementalEffectChance]);
			Console.WriteLine("Bonus Elemental Effect Damage: " + profile.BonusStats[Profile.BonusStatID.ElementalEffectDamage]);
			Console.WriteLine("Bonus Critical Hit Damage: " + profile.BonusStats[Profile.BonusStatID.CriticalHitDamage]);
#endif

#if false
			Entry FOVEntry = profile.GetEntry(EntryID.FOV);

			FOVEntry.SetInt32Data(Int32.Parse(args[1]));
#endif

			if (profile.Save("profile.bin", true) == false)
			{
				Console.WriteLine("Error saving profile.bin");

				return 1;
			}

			return 0;
		}
	}
}
