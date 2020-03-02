using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control - Mission 3
    // Description: A program designed to showcase the finch 
    //              and all that it can do at the very most
    //              basic level. Lights, sounds, and movement
    // Application Type: Console
    // Author: Quinn, Luke
    // Dated Created: 2/22/2020
    // Last Modified: 3/1/2020
    //
    // **************************************************

    class Program
    {
        /// <summary>
        /// 
        /// first method run when the app starts up
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();

            DisplayMenuScreen();

            DisplayClosingScreen();

        }

        /// <summary>
        /// 
        /// Set the console theme
        /// 
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.BackgroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// 
        ///  Main Menu
        ///      
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

           

            Finch finchRobot = new Finch(); //instatiate an object

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice: ");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        DisplayTalentShowMenuScreen(finchRobot);
                        break;

                    case "c":
                        DisplayDataRecorderMenuScreen(finchRobot);
                        break;

                    case "d":

                        break;

                    case "e":

                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }
                                     

        
        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        static void DisplayTalentShowMenuScreen(Finch myFinch)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) Moovin' and Groovin' ");
                Console.WriteLine("\tc) Mixing it Up"); 
                Console.WriteLine("\td) Song Bird");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayLightAndSound(myFinch);
                        break;

                    case "b":
                        DisplayDance(myFinch);
                        break;

                    case "c":
                        DisplayMixingItUp(myFinch);
                        break;

                    case "d":
                        DisplaySongBird(myFinch);
                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayLightAndSound(Finch myFinch)
        {
            Console.CursorVisible = false;
                            
            DisplayScreenHeader("Lights and Sounds");

            Console.WriteLine("\tTHE FINCH ROBOT WILL NOW YELL AND GLOW");
            DisplayContinuePrompt();

            myFinch.setLED(204, 0, 102);
            myFinch.wait(1000);
            myFinch.setLED(0, 204, 102);
            myFinch.wait(1000);
            myFinch.setLED(204, 102, 0);
            myFinch.wait(1000);



            for (int lightSoundLevel = 0; lightSoundLevel < 70; lightSoundLevel++)
            {
                myFinch.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                myFinch.noteOn(lightSoundLevel * 200);

            }

            for (int lightSoundLevel = 0; lightSoundLevel < 40; lightSoundLevel++)
            {
                myFinch.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                myFinch.noteOn(lightSoundLevel * 200);

            }

            for (int lightSoundLevel = 0; lightSoundLevel < 40; lightSoundLevel++)
            {
                myFinch.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                myFinch.noteOn(lightSoundLevel * 100);

            }

            myFinch.noteOff();
            string userResponse;

            Console.Write("\tWhich color would you like to illumiate the Finch with? (Red, Green, or Blue): ");
            userResponse = Console.ReadLine();

            if (userResponse == "red")
            {
                myFinch.setLED(255, 0, 0);
                myFinch.wait(3000);
                myFinch.setLED(0, 0, 0);
            }
            if (userResponse == "blue")
            {
                myFinch.setLED(0, 0, 255);
                myFinch.wait(3000);
                myFinch.setLED(0, 0, 0);
            }
            if (userResponse == "green")
            {
                myFinch.setLED(0, 255, 0);
                myFinch.wait(3000);
                myFinch.setLED(0, 0, 0);
            }

            DisplayMenuPrompt("Talent Show Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Moovin and Groovin                *
        /// *****************************************************************
        /// </summary>
        /// <param name="myFinch">finch robot object</param>
        static void DisplayDance(Finch myFinch)
        {
            Console.CursorVisible = false;
            

            DisplayScreenHeader("Moovin' and Groovin'");

            Console.WriteLine("\tTHE FINCH ROBOT WILL NOW EXECUTE SOME SWEET MOVES ");
            DisplayContinuePrompt();

            string userInput;

            Console.WriteLine("\tThe Square Dance");
            
            
            for (int count = 0;  count < 4; count++)
            {
                myFinch.setMotors(200, 200);
                myFinch.wait(500);
                myFinch.setMotors(0, 255);
                myFinch.wait(500);
                myFinch.setMotors(0, 0);
            }

            for (int count = 0; count < 4; count++)
            {
                myFinch.setMotors(200, 200);
                myFinch.wait(500);
                myFinch.setMotors(255, 0);
                myFinch.wait(500);
                myFinch.setMotors(0, 0);
            }

            Console.Clear();

            Console.CursorVisible = true;
            DisplayScreenHeader("Moovin' and Groovin'");


            Console.Write("\t Would you like to do some donuts with the Finch?: ");
            userInput = Console.ReadLine();

            int userDonuts;


            Console.WriteLine();
            Console.WriteLine("\tYou said, {0}!\n\tGood Choice!", MyReturnStringMethod(userInput));
            Console.WriteLine();
            Console.Write("\tPress any key to continue:");
            Console.ReadKey();

            if (userInput == "yes")
            {
                Console.WriteLine();
                Console.Write("\tHow many would you like to do? 1-5: ");
                userDonuts = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\tYou Have Chosen {0} donuts....", MyReturnNumericMethod(userDonuts));
                    

                if (userDonuts <= 5 && userDonuts >=1)
                {
                    Console.WriteLine("\tPress a key to whip some donuts:");
                    Console.ReadKey();
                    
                    for (int donuts = 0; donuts < userDonuts; donuts++)
                    {
                        myFinch.setMotors(-255, 255);
                        myFinch.wait(1500);
                        myFinch.setMotors(0, 0);
                    }

                    Console.Clear();

                }

                if (userDonuts > 5 || userDonuts < 1)
                {
                    Console.WriteLine("\tSorry that is not an accepted number");
                }
                      
                
            }

            else
            {
                Console.WriteLine("\tThanks for Dancing with the Finch Robot!");
                Console.WriteLine();
                
            } 
                   

          DisplayMenuPrompt("\tTalent Show Menu");  
                                 
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Mixing It Up                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="myFinch">finch robot object</param>
        static void DisplayMixingItUp(Finch myFinch)
        {
            Console.CursorVisible = false;


            DisplayScreenHeader("Mixing It Up");

            Console.WriteLine("\tTHE FINCH ROBOT WILL NOW MIX IT UP ON YA' ");
            DisplayContinuePrompt();


            myFinch.setLED(255, 0, 0);

            myFinch.noteOn(261);
            myFinch.wait(1000);
            myFinch.noteOff();

            myFinch.setLED(0, 255, 0);
            myFinch.setMotors(50, 200);
           
             for (int frequency = 0; frequency < 20000; frequency = frequency + 100)
             {
                    myFinch.noteOn(frequency);
                    myFinch.wait(2);
                    myFinch.noteOff();
             }

            myFinch.wait(3000);
            myFinch.setMotors(0, 0);
            myFinch.setMotors(-200, -200);
            myFinch.wait(1000);
            myFinch.setMotors(0, 0);
            myFinch.setLED(0, 0, 0);



            DisplayMenuPrompt("Talent Show Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Song Bird                         *
        /// *****************************************************************
        /// </summary>
        /// <param name="myFinch">finch robot object</param>
        static void DisplaySongBird(Finch myFinch)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Song Bird");

            Console.WriteLine("\tTHE FINCH ROBOT WILL SING A SPECIAL SONG FOR YOU");
            Console.WriteLine();
            Console.WriteLine("\tImperial March - By VADER");
            DisplayContinuePrompt();


            ImperialMarch(myFinch);


            DisplayMenuPrompt("Talent Show Menu");

        }
        #endregion

        #region DATA RECORDER

        /// <summary>
        /// *****************************************************************
        /// *                     Data Recorder Menu                        *
        /// *****************************************************************
        /// </summary>
        /// <param name="myFinch">finch robot object</param>

        static void DisplayDataRecorderMenuScreen(Finch myFinch)
        {
            Console.CursorVisible = true;

            bool quitDataRecorderMenu = false;
            string menuChoice;
            int numberOfDataPoints = 0;
            double frequencyOfDataPoints = 0;
            double sum = 0;
            double[] temperatures = null;         



            do
            {
                DisplayScreenHeader("Data Recorder Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Number of Data Points");
                Console.WriteLine("\tb) Frequency of Data Points ");
                Console.WriteLine("\tc) Get Data");
                Console.WriteLine("\td) Show Data");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //

                switch (menuChoice)
                {
                    case "a":
                        numberOfDataPoints = DataRecorderDisplayGetNumberOfDataPoints();
                        break;

                    case "b":
                        frequencyOfDataPoints = DataRecorderDisplayGetFrequencyOfDataPoints();
                        break;

                    case "c":
                        temperatures = DataRecorderDisplayGetData(numberOfDataPoints,frequencyOfDataPoints, myFinch);
                        break;

                    case "d":
                        DataRecorderDisplayData(temperatures);
                        break;

                    case "q":
                        quitDataRecorderMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitDataRecorderMenu);


        }


        /// <summary>
        /// Show Temperature Data
        /// </summary>
        /// <param name="temperatures"></param>
        static void DataRecorderDisplayData(double[] temperatures)
        {
            DisplayScreenHeader("Show Temperature Data");

            DataRecorderDisplayTable(temperatures);


            DisplayContinuePrompt();

        }


        /// <summary>
        /// Display Table For temperatures
        /// </summary>
        /// <param name="temperatures"></param>
        static void DataRecorderDisplayTable(double[]temperatures)
        {
            //
            // Display the table headers
            //

            Console.WriteLine(
                "Recording #".PadLeft(15) +
                "Temp in  °F".PadLeft(15)
                );
            Console.WriteLine(
                "___________".PadLeft(15) +
                "___________".PadLeft(15)
                );

            //
            // Display Table Data
            //

            for (int index = 0; index < temperatures.Length; index++)
            {
                Console.WriteLine(
                    (index + 1).ToString().PadLeft(15) +
                    temperatures[index].ToString("n2").PadLeft(15)
                    );
            }


            

            
        }

        static double [] DataRecorderDisplayGetData(int numberOfDataPoints, double frequencyOfDataPoints, Finch finchRobot)
        {
            double[] temperatures = new double[numberOfDataPoints]; // Instatiating a new array
            DisplayScreenHeader("\tGet Temperatures");

            Console.WriteLine($"\tNumber of Temperatures: {numberOfDataPoints}");
            Console.WriteLine($"\tTemperature Frequency: {frequencyOfDataPoints}");
            Console.WriteLine();
            Console.WriteLine("\tThe Finch is now ready to begin recording the temperature data");
            DisplayContinuePrompt();


            for (int index = 0; index < numberOfDataPoints; index++)
            {
                temperatures[index] = finchRobot.getTemperature() * 9 / 5 + 32 ;
                
                Console.WriteLine($"\tReading {index + 1}:      {temperatures[index].ToString("n2")} °F".PadLeft(10));

                int waitInSeconds = (int)(frequencyOfDataPoints * 1000);
                finchRobot.wait(waitInSeconds);



            }




            DisplayContinuePrompt();

            return temperatures;
        }

        



        /// <summary>
        /// Get the number of data points 
        /// </summary>
        /// <returns> Number of data points </returns>
        static int DataRecorderDisplayGetNumberOfDataPoints()
        {
            int numberOfDataPoints;

            DisplayScreenHeader("\tNumber Of Data Points");

            Console.Write("\tHow many times would you like us to record the temp? (1-50): ");

            int.TryParse(Console.ReadLine(), out numberOfDataPoints);


            DisplayContinuePrompt();

            return numberOfDataPoints;
        }

        /// <summary>
        /// Get the freq of the data points
        /// </summary>
        /// <returns> freq of data points </returns>
        static double DataRecorderDisplayGetFrequencyOfDataPoints()
        {
            double frequencyOfDataPoints;

            DisplayScreenHeader("\tFrequency of Temperatures");

            Console.Write("\tHow often, in seconds, would you like to record the temperature?(1-30): ");

            double.TryParse(Console.ReadLine(), out frequencyOfDataPoints);


            DisplayContinuePrompt();

            return frequencyOfDataPoints;

        }

       
        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnected.");

            DisplayMenuPrompt("Main Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = finchRobot.connect();

            // TODO test connection and provide user feedback - text, lights, sounds

            DisplayMenuPrompt("Main Menu");

            //
            // reset finch robot
            //
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();

            return robotConnected;
        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Continue Prompt                           *
        /// *****************************************************************
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// *************************************************************
        /// *                     Menu Prompt                           *
        /// *************************************************************
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// ***************************************************************
        /// *                     Screen Header                           *
        /// ***************************************************************
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }


        #endregion
        
        #region QUINN'S STUFF & JUNK

        /// <summary>
        /// *****************************************************************
        /// *                     Imperial March                            *
        /// *****************************************************************
        /// </summary>
        static void ImperialMarch(Finch myFinch)
        {
            for (int count = 0; count < 3; count++)
            {
                myFinch.noteOn(880);
                myFinch.wait(500);
                myFinch.noteOff();

            }

            // f-c
            myFinch.noteOn(698);
            myFinch.wait(500);
            myFinch.noteOff();

            myFinch.noteOn(1046);
            myFinch.wait(500);
            myFinch.noteOff();
            //

            myFinch.noteOn(880);
            myFinch.wait(500);
            myFinch.noteOff();

            myFinch.noteOn(698);
            myFinch.wait(250);
            myFinch.noteOff();

            myFinch.noteOn(1046);
            myFinch.wait(250);
            myFinch.noteOff();

            myFinch.noteOn(880);
            myFinch.wait(500);
            myFinch.noteOff();

            //2nd line

            for (int count = 0; count < 3; count++)
            {
                myFinch.noteOn(1318);
                myFinch.wait(500);
                myFinch.noteOff();

            }

            myFinch.noteOn(1396);
            myFinch.wait(500);
            myFinch.noteOff();

            myFinch.noteOn(1046);
            myFinch.wait(500);
            myFinch.noteOff();

            myFinch.noteOn(880);
            myFinch.wait(500);
            myFinch.noteOff();

            myFinch.noteOn(698);
            myFinch.wait(500);
            myFinch.noteOff();

            myFinch.noteOn(1046);
            myFinch.wait(500);
            myFinch.noteOff();

            myFinch.noteOn(880);
            myFinch.wait(500);
            myFinch.noteOff();

            //

            myFinch.noteOn(1760);
            myFinch.wait(500);
            myFinch.noteOff();

            myFinch.noteOn(880);
            myFinch.wait(500);
            myFinch.noteOff();

            myFinch.noteOn(880);
            myFinch.wait(500);
            myFinch.noteOff();

            myFinch.noteOn(1760);
            myFinch.wait(500);
            myFinch.noteOff();

            myFinch.noteOn(1760);
            myFinch.wait(500);
            myFinch.noteOff();

            myFinch.noteOn(1567);
            myFinch.wait(500);
            myFinch.noteOff();

            //line3

            myFinch.noteOn(1567);
            myFinch.wait(500);
            myFinch.noteOff();

            myFinch.noteOn(1396);
            myFinch.wait(500);
            myFinch.noteOff();

            myFinch.noteOn(1567);
            myFinch.wait(500);
            myFinch.noteOff();

            myFinch.noteOn(987);
            myFinch.wait(500);
            myFinch.noteOff();

            myFinch.noteOn(1318);
            myFinch.wait(500);
            myFinch.noteOff();

            myFinch.noteOn(1174);
            myFinch.wait(500);
            myFinch.noteOff();

            myFinch.noteOn(1174); //D
            myFinch.wait(500);
            myFinch.noteOff();

            myFinch.noteOn(1046);
            myFinch.wait(500);
            myFinch.noteOff();

            myFinch.noteOn(987); //b
            myFinch.wait(500);
            myFinch.noteOff();

            myFinch.noteOn(1046); //c
            myFinch.wait(500);
            myFinch.noteOff();

            myFinch.noteOn(698);
            myFinch.wait(500);
            myFinch.noteOff();

            myFinch.noteOn(880);
            myFinch.wait(500);
            myFinch.noteOff();

            myFinch.noteOn(698);
            myFinch.wait(500);
            myFinch.noteOff();

            myFinch.noteOn(880);
            myFinch.wait(500);
            myFinch.noteOff();
        }


        /// <summary>
        /// BS Num RETURN METHOD
        /// </summary>
        /// <param name="userDonuts"></param>
        /// <returns></returns>
        private static int MyReturnNumericMethod(int userDonuts)
        {
            int result = userDonuts;
            return result;


        }

        /// <summary>
        /// BS STRING RETURN METHOD
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        private static string MyReturnStringMethod(string userInput)
        {
            string result = userInput;
            return result;

        }


        //(C* 9) / 5 + 32
        
        #endregion

    }
}
