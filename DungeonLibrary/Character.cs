using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public abstract class Character
    {
        //FIELDS
        private int _hp;

        //PROPS
        public string Name { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int MaxHP { get; set; }
        public int HP
        {
            get { return _hp; }
            set
            {
                _hp = value <= MaxHP ? value : MaxHP;
            }
        }
        //CTORS
        //Abstract class, no ctors.
        //METHODS
        public virtual int CalcBlock()
        {
            return Block;
        }//end CalcBlock()

        public virtual int CalcHitChance()
        {
            return HitChance;
        }//end CalcHitChance()

        public virtual int CalcDamage()
        {
            return 0;
        }//end CalcDamage()
    }//end class
}
