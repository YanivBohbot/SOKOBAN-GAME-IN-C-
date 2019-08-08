using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SOKOBAN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        Game game;
        public MainWindow()
        {
            InitializeComponent();

            game = new Game();
            this.KeyDown += MainWindow_KeyDown;     
            DRAW();

        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key.Equals(Key.Up) || e.Key.Equals(Key.Down) || e.Key.Equals(Key.Left) || e.Key.Equals(Key.Right))
            {
                game.key_touched(e.Key);
                Redraw_all_items();

                if(game.End())
                {
                    MessageBoxResult message = MessageBox.Show("Congratulation you win ! with " + game.Number_of_moves + "moves ", "Do YOu want to Restart ?", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if(message == MessageBoxResult.Yes)
                    {
                        game.restart();
                        Redraw_all_items();
                    }



                }
            }
        }

        private void Redraw_all_items()
        {
            cnv_Mobile.Children.Clear();
            DessinerCArd();
            Draw_Box();
            Draw_Player();
            Draw_count_of_moves();
        }

        private void DRAW()
        {
            DessinerCArd();
            Redraw_all_items();
         

        }

        private void Draw_count_of_moves()
        {
            txt_bock_count.Text = game.Number_of_moves.ToString();
        }

        private void Draw_Player()
        {
            Rectangle r = new Rectangle();
            r.Width = 30;
            r.Height = 30;
            r.Margin = new Thickness(game.Player.y * 50 + 10, game.Player.x* 50 + 10, 0, 0);
            r.Fill = new ImageBrush(new BitmapImage(new Uri("C:/Users/yaniv/Documents/Visual Studio 2015/Projects/SOKOBAN/SOKOBAN/images/10522.png", UriKind.Relative)));
            cnv_Mobile.Children.Add(r);
        }

        private void Draw_Box()
        {
            foreach(Position pos in game.Caisses)
            {
                Rectangle r = new Rectangle();
                r.Width = 42;
                r.Height = 42;
                r.Margin = new Thickness( pos.y* 50+4, pos.x*50+4, 0, 0);
                r.Fill = new ImageBrush(new BitmapImage(new Uri("C:/Users/yaniv/Documents/Visual Studio 2015/Projects/SOKOBAN/SOKOBAN/images/shipping-box.png", UriKind.Relative)));
                cnv_Mobile.Children.Add(r);
            }
        }

        private void DessinerCArd()
        {

            for (int ligne = 0; ligne < 10; ligne++)
            {
                for (int colonne = 0; colonne < 10; colonne++)
                {
                    Rectangle r = new Rectangle();
                    r.Width = 50;
                    r.Height = 50;
                    r.Margin = new Thickness(colonne * 50, ligne * 50, 0, 0);



                    switch (game.Case(ligne, colonne))
                    {
                        case Game.Etat.Voide:
                            r.Fill = new ImageBrush(new BitmapImage(new Uri("C:/Users/yaniv/Documents/Visual Studio 2015/Projects/SOKOBAN/SOKOBAN/images/Diamond_block.png", UriKind.Relative)));
                            break;

                        case Game.Etat.Target:
                            r.Fill = new ImageBrush(new BitmapImage(new Uri("C:/Users/yaniv/Documents/Visual Studio 2015/Projects/SOKOBAN/SOKOBAN/images/target.png", UriKind.Relative)));
                            break;

                        case Game.Etat.Wall:
                            r.Fill = new ImageBrush(new BitmapImage(new Uri("C:/Users/yaniv/documents/visual studio 2015/Projects/SOKOBAN/SOKOBAN/images/video_game_play_wall_brik-512.png", UriKind.Relative)));
                            break;

                    }

                    canvas_gride.Children.Add(r);



                }
            }





        }

        private void btn_restart_Click(object sender, RoutedEventArgs e)
        {
            game.restart();
            Redraw_all_items();
        }
    }
}
