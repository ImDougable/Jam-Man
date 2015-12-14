using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playingClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            //primarily for testing FormatCombatantInfo()

            Hero myHero = new Hero()
            {
                name = "Slappy the Frog",
                description = "The hero of this exmaple.",
                level = 25,
                hitPoints = 50,
                manaPoints = 30,
                ATK = 7,
                DEF = 7,
                MATK = 5,
                MDEF = 6,
                LUCK = 5,
                ALI = 50
            };

            Monster myMonster = new Monster()
            {
                name = "Mook Dragon",
                Attribute = "Fire",
                level = 10,
                hitPoints = 100,
                manaPoints = 75,
                ATK = 5,
                DEF = 5,
                MATK = 10,
                MDEF = 10,
                LUCK = 12,
                ALI = 50
            };

            string heroStats = myHero.FormatCombatantInfo();
            string monsterStats = myMonster.FormatCombatantInfo();

            Console.WriteLine(heroStats);
            Console.WriteLine("\n");
            Console.WriteLine(monsterStats);

            Console.ReadLine();
        }
    }

    abstract class Combatant
    {
        public string name { get; set; }                //Name of the character
        public string description { get; set; }         //Description of the character
        public int level { get; set; }                  //Level of the character
        public int hitPoints { get; set; }              //HP of the character
        public int manaPoints { get; set; }             //MP of the character
        public int ATK { get; set; }                    //Physical damage stat
        public int DEF { get; set; }                    //Physical resist stat
        public int MATK { get; set; }                   //Magic damage stat
        public int MDEF { get; set; }                   //Magic resist stat
        public int LUCK { get; set; }                   //Crit. and droprate modifier
        public int ALI { get; set; }                    //Alignment, how good or evil something is
        public int ATKSP { get; set; }                  //Attack speed, rarely > 1
        public int MVSP { get; set; }                   //Movement speed, rarely > 1

        public abstract string FormatCombatantInfo();   //Method to format stats into presentable string
    }

    class Hero : Combatant
    {
        public int HONOR { get; set; }                  //Hidden stat that changes based on player's fighting practices

        public override string FormatCombatantInfo()
        {
            return String.Format("{0}\n{1}\nLVL :{2}\nHP  :{3}\t\tMP  :{4}\nATK :{5}"
                +"\t\tDEF :{6}\nMATK:{7}\t\tMDEF:{8}\nLUCK:{9}\t\tALI :{10}",
                this.name,
                this.description,
                this.level,
                this.hitPoints,
                this.manaPoints,
                this.ATK,
                this.DEF,
                this.MATK,
                this.MDEF,
                this.LUCK,
                this.ALI);
        }
    }

    class Monster : Combatant
    {
        public string Attribute { get; set; }           //Determines weaknesses to magic types

        public override string FormatCombatantInfo()
        {
            return String.Format("{0}\n{1}\nLVL :{2}\nHP  :{3}\tMP  :{4}\nATK :{5}"
                + "\t\tDEF :{6}\nMATK:{7}\t\tMDEF:{8}\nLUCK:{9}\t\tALI :{10}",
                this.name,
                this.Attribute,
                this.level,
                this.hitPoints,
                this.manaPoints,
                this.ATK,
                this.DEF,
                this.MATK,
                this.MDEF,
                this.LUCK,
                this.ALI);
        }
    }

    abstract class Item
    {
        public string itemName { get; set; }
        public string itemDescription { get; set; }
        enum canEquip
        {
            True,
            False
        }
        enum canUse
        {
            True,
            False
        }
        enum canStack
        {
            True,
            False
        }

    }

    class equipItem : Item
    {
        public int DURA { get; set; }               //how quickly the item deteriorates
        public int IHP { get; set; }                //HP of the item, 0 = breaks
        public int atkMod { get; set; }             //modifier for user's ATK
        public int defMod { get; set; }             //modifier for user's DEF
        public int matkMod { get; set; }            //modifier for user's MATK
        public int mdefMod { get; set; }            //modifier for user's MDEF
        public int luckMod { get; set; }            //modifier for user's LUCK
        public int hpMod { get; set; }              //modifier for user's hitpoints
        public int manaMod { get; set; }            //modifier for user's manapoints
        public string effect { get; set; }          //unique effect to the item; to be better implemented later
    }
}
