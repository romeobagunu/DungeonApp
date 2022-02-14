using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        //FIELDS
        private int _minDmg;

        //PROPS
        public int MaxDmg { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BonusHitChance { get; set; }
        public int MinDmg
        {
            get { return _minDmg; }
            set
            {
                _minDmg = value > 0 && value <= MaxDmg ? value : 1;
            }
        }//end MinDmg prop

        //CTORS
        public Weapon(string name, string description, int minDmg, int maxDmg, int bonusHitChance)
        {
            MaxDmg = maxDmg;
            Name = name;
            Description = description;
            BonusHitChance = bonusHitChance;
            MinDmg = minDmg;
        }//end FQCTOR

        //METHODS
        public override string ToString()
        {
            return string.Format("{0}\n" +
                "Damage: {1} - {2}\n" +
                "Bonus Hit Chance: {3}%\n" +
                "{4}",
                Name,
                MinDmg,
                MaxDmg,
                BonusHitChance,
                Description);
            //TODO: Update Hit Chance to reflect % logic.
        }//end override ToString()
    }//end class
}//end namespace
