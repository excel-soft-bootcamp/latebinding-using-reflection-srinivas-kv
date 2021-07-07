using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game_App
{
    //Named Constants
    //Constant Value is - int
    public enum Options
    {
        BASIC = 1, INTERMEDIATE, ADVANCED
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Word Guess Game");

            string message = string.Format("Enter Your Choice {0}->Basic , {1}->Intermediate ,{2}->Advanced", Options.BASIC, Options.INTERMEDIATE, Options.ADVANCED);// 1->Basic,2->Intermediate
            //String Interpollation 
            string displayMessage = $"Enter Your Choice {(int)Options.BASIC}->Basic,{(int)Options.INTERMEDIATE}->Intermediate,{(int)Options.ADVANCED}->Advanced";
            Console.WriteLine(displayMessage);
            Options _choice = (Options)Int32.Parse(Console.ReadLine());

            try{
                switch (_choice)
                {
                    case Options.BASIC:
                        Console.WriteLine("Basic Level");
                        //Use Reflection  
                        //Assembly Load
                        System.Reflection.Assembly basicLevelLib = System.Reflection.Assembly.LoadFile(@"C:\Users\srinivas.kv\source\repos\Game_App\Game_App\bin\Debug\LevelLibs\BasicLevelLib.dll");
                        // Search For Class - BasicLevelType
                        System.Type basicLevelTypeClassRef = basicLevelLib.GetType("BasicLevelLib.BasicLevelType");
                        if (basicLevelTypeClassRef != null)
                        {
                            if (basicLevelTypeClassRef.IsClass)
                            {
                                //Instantiate Type
                                Object objRef = System.Activator.CreateInstance(basicLevelTypeClassRef); //LateBinding Code
                                                                                                         //Discove Method
                                System.Reflection.MethodInfo _methodRef = basicLevelTypeClassRef.GetMethod("Play");
                                if (!_methodRef.IsStatic)
                                {
                                    //Invoke NonStatic Method
                                    object result = _methodRef.Invoke(objRef, new object[] { });
                                    Console.WriteLine(result.ToString());
                                }

                            }

                        }
                        break;
                    case Options.INTERMEDIATE:
                        Console.WriteLine("Intermediate Level");


                        //Use Reflection  
                        //Assembly Load
                        System.Reflection.Assembly intermediateLevelLib =
                        System.Reflection.Assembly.LoadFile(@"C:\Users\srinivas.kv\source\repos\Game_App\Game_App\bin\Debug\LevelLibs\IntermediateLevelLib.dll");
                        // Search For Class - IntermediateLevelType
                        System.Type intermediateLevelTypeClassRef = intermediateLevelLib.GetType("IntermediateLevelLib.IntermediateLevelType");
                        if (intermediateLevelTypeClassRef != null)
                        {
                            if (intermediateLevelTypeClassRef.IsClass)
                            {
                                //Instantiate Type
                                Object objRef = System.Activator.CreateInstance(intermediateLevelTypeClassRef); //LateBinding Code
                                                                                                                //Discove Method
                                System.Reflection.MethodInfo _methodRef = intermediateLevelTypeClassRef.GetMethod("Start");
                                if (!_methodRef.IsStatic)
                                {
                                    //Invoke NonStatic Method
                                    object result = _methodRef.Invoke(objRef, new object[] { "Srinivas" });
                                    Console.WriteLine(result.ToString());
                                }

                            }

                        }
                        break;
                    case Options.ADVANCED:
                        Console.WriteLine("Advanced Level");

                        //Use Reflection  
                        //Assembly Load
                        System.Reflection.Assembly advancedLevelLib =
                        System.Reflection.Assembly.LoadFile(@"C:\Users\srinivas.kv\source\repos\Game_App\Game_App\bin\Debug\LevelLibs\AdvancedLevelLib.dll");
                        // Search For Class - AdvancedLevelType
                        System.Type advancedLevelTypeClassRef = advancedLevelLib.GetType("AdvancedLevelLib.AdvancedLevelType");
                        if (advancedLevelTypeClassRef != null)
                        {
                            if (advancedLevelTypeClassRef.IsClass)
                            {
                                //Instantiate Type
                                Object objRef = System.Activator.CreateInstance(advancedLevelTypeClassRef); //LateBinding Code
                                                                                                            //Discove Method
                                System.Reflection.MethodInfo _methodRef = advancedLevelTypeClassRef.GetMethod("Begin");
                                if (!_methodRef.IsStatic)
                                {
                                    //Invoke NonStatic Method
                                    object result = _methodRef.Invoke(objRef, new object[] { "Srinivas", 10 });
                                    Console.WriteLine(result.ToString());
                                }

                            }

                        }
                        break;
                    }
                }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {

            }
            Console.ReadLine();

            }
        }
    }


