using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;

using SharpDX;

using Color = System.Drawing.Color;

namespace DienoRumble
{
    class Program
    {
        //Copy pasta boilerplate stuff from Esk0r
        public const string ChampionName = "Rumble";
        private static Obj_AI_Hero Player = ObjectManager.Player;
        public static Orbwalking.Orbwalker Orbwalker;
        public static List<Spell> SpellList = new List<Spell>();
        public static Spell Q;
        public static Spell W;
        public static Spell E;
        public static Spell R;
        public static SpellSlot IgniteSlot;
        public static Menu Config;

        static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;

        }

        private static void Game_OnGameLoad(EventArgs args)
        {
            if (Player.BaseSkinName != ChampionName) return;
            Q = new Spell(SpellSlot.Q, 600);
            W = new Spell(SpellSlot.W);
            E = new Spell(SpellSlot.E, 950);
            R = new Spell(SpellSlot.R, 1750);
            IgniteSlot = Player.GetSpellSlot("SummonerDot");
            Q.SetSkillshot(0.25f, 125f, float.MaxValue, false, SkillshotType.SkillshotLine);
            E.SetSkillshot(0.25f, 2000f, 2500f, false, SkillshotType.SkillshotLine);
            R.SetSkillshot(float.MaxValue, 55f, 2000f, false, SkillshotType.SkillshotLine);
        }
    }
}
