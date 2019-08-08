using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SOKOBAN
{
    class Game
    {
        public enum Etat
        {
            Voide,
            Wall,
            Target
        }

        private Etat[,] grille;

       private  List<Position> caisses;

       public List<Position> Caisses
        {
            get
            {
                return caisses;
            }

        }

        public Position Player
        {
            get
            {
                return player;
            }

         }

     

        private Position player;

        static String gride_text = "..XXXXXX..XXX.oo.XXXX..o..o..XX........XXXX....XXX..XX.CXX...XXXC.XXX..X.CP.C.X..X......X..XXXXXXXX.";

        private int number_of_moves;

        public int Number_of_moves
        {
            get
            {
                return number_of_moves;
            }

        }

        public Game()
        {
            grille = new Etat[10, 10];
            InitCard();
            number_of_moves = 0 ;
        }

        public bool End()
        {
            foreach(Position caisse in caisses)
            {
                if(grille[caisse.x,caisse.y] != Etat.Target)
                { return false;
                }
                
            }

            return true;
        }

        private void InitCard()
        {
            caisses = new List<Position>();

            for(int  ligne = 0; ligne<10; ligne++)
            {
                for(int colonne=0; colonne<10; colonne++)
                {
                    switch(gride_text[ligne*10+colonne])
                    {
                        case '.':
                            grille[ligne, colonne] = Etat.Voide;
                            break;

                        case 'C':
                            caisses.Add(new Position(ligne, colonne));
                            grille[ligne, colonne] = Etat.Voide;
                            break;

                        case 'P':

                            player = new Position(ligne, colonne);
                            grille[ligne, colonne] = Etat.Voide;
                            break;

                        case 'X': grille[ligne, colonne] = Etat.Wall;
                            break;

                        case 'o': grille[ligne, colonne] = Etat.Target;
                            break;

                    }
                }
            }


        }

        public void key_touched(Key key)
        {
            Position new_pos_player = new Position(player.x, player.y);
            Calcul_New_Pos_Player(new_pos_player , key);

            if (Box_Ok(new_pos_player, key))
            {
                player = new_pos_player;
                number_of_moves++;
            }
        }

        private static void Calcul_New_Pos_Player(Position new_pos_player, Key key)
        {
            switch (key)
            {
                case Key.Down:
                    new_pos_player.x++; break;
                case Key.Up:
                    new_pos_player.x--; break;
                case Key.Left:
                    new_pos_player.y--; break;
                case Key.Right:
                    new_pos_player.y++; break;
            }
        }

        private bool Box_Ok(Position new_pos, Key key)
        {
            //if presence of wall 
            if (grille[new_pos.x, new_pos.y] == Etat.Wall)
            { return false; }

            //if ship_box exist
            // we create a  an instance of ship_box and we check the position with the position
            Position ship_box = Caisses_inPos(new_pos);
            
            if (ship_box != null) // if at this  posistion there is a ship_box  then we create a new instance of box with the new position to move it 
            {
                Position new_position_box = new Position(ship_box.x,ship_box.y);
                Calcul_New_Pos_Player(new_position_box, key);


                if (grille[new_position_box.x,new_position_box.y] == Etat.Wall )
                {
                    return false;
                }
                else if (Caisses_inPos(new_position_box) !=null)
                {
                    return false;
                }
                else
                {
                    ship_box.x = new_position_box.x;
                    ship_box.y = new_position_box.y;
                    return true;
                }
            }

            return true;
        }

        public void restart()
        {
            InitCard();
            number_of_moves = 0;
        }

        private Position Caisses_inPos(Position newpos)
        {
            foreach (Position box in caisses)
            {
                if (box.x == newpos.x && box.y == newpos.y)
                {
                    return box;
                }
            }
            return null;
        }



        public Etat Case(int ligne, int colonne)
        {
             return grille[ligne, colonne];
        }
    }


            
}
