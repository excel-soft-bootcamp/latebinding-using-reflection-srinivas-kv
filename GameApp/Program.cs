using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    public enum Options
    {
        BASIC = 1, INTERMEDIATE, ADVANCED
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Word Guess Game");
            string displayMessage = $"Enter Your Choice {(int)Options.BASIC}->Basic,{(int)Options.INTERMEDIATE}->Intermediate,{(int)Options.ADVANCED}->Advanced";
            Console.WriteLine(displayMessage);
            do
            {
                try
                {
                    Options _choice = (Options)Int32.Parse(Console.ReadLine());
                    int choose = (int)_choice;
                    if (_choice == Options.BASIC || _choice == Options.INTERMEDIATE || _choice == Options.ADVANCED)
                    {
                        switch (_choice)
                        {
                            case Options.BASIC:
                                Console.WriteLine("Basic Level");
                                System.Reflection.Assembly basicLevelLib =
                                System.Reflection.Assembly.LoadFile(@"C:\Users\srinivas.kv\source\repos\GameApp\bin\Debug\LevelLibs\BasicLevelLib.dll");
                                System.Type basicLevelTypeClassRef = basicLevelLib.GetType("BasicLevelLib.BasicLevelType");
                                CheckNull(basicLevelTypeClassRef, "Play");
                                break;
                            case Options.INTERMEDIATE:
                                Console.WriteLine("Intermediate Level");
                                System.Reflection.Assembly intermediateLevelLib =
                                System.Reflection.Assembly.LoadFile(@"C:\Users\srinivas.kv\source\repos\GameApp\bin\Debug\LevelLibs\IntermediateLevelLib");
                                System.Type intermediateLevelTypeClassRef = intermediateLevelLib.GetType("IntermediateLevelLib.IntermediateLevelType");
                                CheckNull(intermediateLevelTypeClassRef, "Start");
                                break;
                            case Options.ADVANCED:
                                Console.WriteLine("Advanced Level");
                                System.Reflection.Assembly advancedLevelLib =
                                System.Reflection.Assembly.LoadFile(@"C:\Users\srinivas.kv\source\repos\GameApp\bin\Debug\LevelLibs\AdvancedLevelLib.dll");
                                System.Type advancedLevelTypeClassRef = advancedLevelLib.GetType("AdvancedLevelLib.AdvancedLevelType");
                                CheckNull(advancedLevelTypeClassRef, "Begin");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                }
                catch (SystemException)
                {
                    Console.WriteLine("Warning : Choose a number");
                }

            } while (true);
        }
        public static void CheckNull(System.Type classRef, string methodPerformed)
        {
            if (classRef != null)
            {
                if (classRef.IsClass)
                {
                    Object _obj = System.Activator.CreateInstance(classRef);
                    System.Reflection.MethodInfo _methodAction = classRef.GetMethod(methodPerformed);

                    if (!_methodAction.IsStatic)
                    {
                        if (methodPerformed == "Play")
                        {
                            object result = _methodAction.Invoke(_obj, new object[] { });
                            Console.WriteLine(result.ToString());
                        }
                        else if (methodPerformed == "Start")
                        {
                            object result = _methodAction.Invoke(_obj, new object[] { "Srinivas" });
                            Console.WriteLine(result.ToString());
                        }
                        else if (methodPerformed == "Begin")
                        {
                            object result = _methodAction.Invoke(_obj, new object[] { "Srinivas", 99 });
                            Console.WriteLine(result.ToString());
                        }
                    }

                }
            }

        }
    }

}
