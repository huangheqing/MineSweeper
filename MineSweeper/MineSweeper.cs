using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class MineSweeperForm : Form
    {
        //private static Timer timer = new Timer();
        private static Button[,] buttonGrid;
        private static int[,] map;
        private static int mines = 0;
        private static int currentGameSize = 0;
        private static int _ticks = 0;

        //initialize the UI
        public MineSweeperForm()
        {
            InitializeComponent();
            generateGameSizeComboBox();
        }

        //initilize game size list
        private void generateGameSizeComboBox()
        {
            for (int i = 1; i <= 12; i++)
            {
                gameSize.Items.Add(i + " * " + i);
            }
        }

        //start the game
        private void start_Click(object sender, EventArgs e)
        {
            //check number of mines and selected size, if valid start the game
            if (isValueValid())
            {
                clearPreviousGame();
                generateGame(currentGameSize, mines);
                //print the map in console
                for (int i = 0; i < map.GetLength(0); ++i)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int j = 0; j < map.GetLength(1); ++j)
                    {
                        sb.Append(map[j, i] + " ");
                        //Trace.Write(map[j, i] + " ");
                    }
                    Trace.WriteLine(sb.ToString());
                }
                //start timer when game is generated
                timer1.Start();
            }
        }

        //change the current selected size
        private void gameSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentGameSize = gameSize.SelectedIndex + 1;
        }

        //check the insert value and select option is valid
        private bool isValueValid()
        {
            int tmp = 0;
            try
            {
                if (currentGameSize <= 0)
                {
                    MessageBox.Show("please select size of your game!");
                    return false;
                }
                tmp = Convert.ToInt32(numberOfMines.Text);
                if (tmp <= 0 || tmp > Math.Pow(currentGameSize, 2))
                {
                    MessageBox.Show(String.Format("please insert a valid number of mines! {0} is less than 1 or greater than the gamesize {1}", tmp, Math.Pow(currentGameSize, 2)));
                    return false;
                }
                else
                {
                    mines = tmp;
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("please insert a valid integer!"));
                Program.logIt(ex.ToString());
                return false;
            }
        }

        //clear previous game
        private void clearPreviousGame()
        {
            try
            {
                _ticks = 0;
                if (buttonGrid != null | buttonGrid.Length != 0)
                {
                    for (int i = 0; i < buttonGrid.GetLength(0); ++i)
                    {
                        for (int j = 0; j < buttonGrid.GetLength(1); ++j)
                        {
                            if (Controls.Contains(buttonGrid[i, j]))
                            {
                                Controls.Remove(buttonGrid[i, j]);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Program.logIt(e.ToString());
            }
        }

        //generate the game grid panel here
        private void generateGame(int size, int mines)
        {
            try
            {
                Program.logIt(String.Format("size:{0}  mines:{1}", size, mines));

                //create buttons
                buttonGrid = new Button[size, size];
                //start point is 20, 76
                int buttonSize = 300 / size;
                for (int i = 0; i < size; ++i)
                {
                    for (int j = 0; j < size; ++j)
                    {
                        buttonGrid[i, j] = new Button();
                        buttonGrid[i, j].Name = i + "," + j;
                        buttonGrid[i, j].Size = new System.Drawing.Size(buttonSize, buttonSize);//because the panel size is 300*300
                        buttonGrid[i, j].Location = new System.Drawing.Point(20 + (i * buttonSize), 76 + (j * buttonSize));//keep adding from the start point
                        Controls.AddRange(new System.Windows.Forms.Control[] { buttonGrid[i, j], });
                        buttonGrid[i, j].Click += new System.EventHandler(gameButtonClick);
                    }
                }

                //get randomized mines
                map = new int[size, size];
                int randomMine = mines;
                Random random = new Random();
                while (randomMine > 0)
                {
                    int i = 0;
                    int j = 0;
                    i = random.Next(0, size);
                    //Random rndomJ = new Random();
                    j = random.Next(0, size);

                    Console.Write(string.Format("{0},{1} ", i, j));
                    if (map[i, j] != 1)
                    {
                        map[i, j] = 1;
                        randomMine--;
                    }
                    else
                    {
                        continue;
                    }
                }
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Program.logIt(e.ToString());
            }
        }

        //hit each game button
        void gameButtonClick(object sender, EventArgs e)
        {
            Button bttnClick = sender as Button;

            string[] split = bttnClick.Name.Split(new Char[] { ',' });

            int i = System.Convert.ToInt32(split[0]);
            int j = System.Convert.ToInt32(split[1]);

            Program.logIt("this position value = " + map[i, j].ToString());

            //change the font size based on the button size
            int fontSize = Convert.ToInt16(buttonGrid[0, 0].Height);
            if (fontSize > 0 && fontSize < 100)
                fontSize = 15;
            else if (fontSize >= 100 && fontSize <= 200)
                fontSize = 25;
            else
                fontSize = 30;

            if (map[i, j] != 1)
            {
                Program.logIt(string.Format("clicked button[{0},{1}]", i, j));
                //Game Over!
                bool isMineNearBy = false;
                int countMine = 0;
                //check surrounding 8 cells and see how many mines are there
                if ((i - 1 >= 0 && j - 1 >= 0) && map[i - 1, j - 1] == 1)
                {
                    isMineNearBy = true;
                    countMine++;
                }

                if (i - 1 >= 0 && map[i - 1, j] == 1)
                {
                    isMineNearBy = true;
                    countMine++;
                }

                if (j - 1 >= 0 && map[i, j - 1] == 1)
                {
                    isMineNearBy = true;
                    countMine++;
                }

                if ((i + 1 < buttonGrid.GetLength(0) && j + 1 < buttonGrid.GetLength(1)) && map[i + 1, j + 1] == 1)
                {
                    isMineNearBy = true;
                    countMine++;
                }

                if (i + 1 < buttonGrid.GetLength(0) && map[i + 1, j] == 1)
                {
                    isMineNearBy = true;
                    countMine++;
                }

                if (j + 1 < buttonGrid.GetLength(1) && map[i, j + 1] == 1)
                {
                    isMineNearBy = true;
                    countMine++;
                }

                if (i + 1 < buttonGrid.GetLength(0) && j - 1 >= 0 && map[i + 1, j - 1] == 1)
                {
                    isMineNearBy = true;
                    countMine++;
                }

                if (i - 1 >= 0 && j + 1 < buttonGrid.GetLength(1) && map[i - 1, j + 1] == 1)
                {
                    isMineNearBy = true;
                    countMine++;
                }

                //caution move
                if (isMineNearBy)
                {
                    Program.logIt("mine near this position");
                    buttonGrid[i, j].Text = countMine.ToString();
                    buttonGrid[i, j].Font = new Font("Microsoft Sans Serif", (float)fontSize, buttonGrid[i, j].Font.Style, buttonGrid[i, j].Font.Unit);
                    buttonGrid[i, j].Enabled = false;
                }
                //safe move
                else
                {
                    Program.logIt("no mine near this position");
                    buttonGrid[i, j].Text = "";
                    buttonGrid[i, j].Enabled = false;
                }
            }
            else
            {
                //GAME END HERE AND SHOW ALL MINES AND DESABLE ALL CELLS
                Program.logIt(string.Format("clicked button[{0},{1}]", i, j));
                Program.logIt("Gameover");
                timer1.Stop();//timer stops here
                buttonGrid[i, j].Text = "*";
                buttonGrid[i, j].Font = new Font("Microsoft Sans Serif", (float)fontSize * 2, buttonGrid[i, j].Font.Style, buttonGrid[i, j].Font.Unit);
                buttonGrid[i, j].Enabled = false;
                buttonGrid[i, j].BackColor = Color.Red;
                for (int a = 0; a < buttonGrid.GetLength(0); ++a)
                {
                    for (int b = 0; b < buttonGrid.GetLength(1); ++b)
                    {
                        if (map[a, b] == 1)
                        {
                            buttonGrid[a, b].Text = "*";
                            buttonGrid[a, b].Font = new Font("Microsoft Sans Serif", (float)fontSize * 2, buttonGrid[a, b].Font.Style, buttonGrid[i, j].Font.Unit);
                            buttonGrid[a, b].Enabled = false;
                            continue;
                        }
                        buttonGrid[a, b].Enabled = false;
                    }
                }
                MessageBox.Show("GameOver!");
            }
        }

        //clear game
        private void newGame_Click_1(object sender, EventArgs e)
        {
            clearPreviousGame();
        }

        //time tick update
        private void timer1_Tick(object sender, EventArgs e)
        {
            _ticks++;
            timeText.Text = _ticks.ToString();
        }

    }
}

