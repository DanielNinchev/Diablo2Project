using Diablo2Project.Core.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diablo2Project.Core
{
    public class Engine
    {
        private bool isRunning;
        private readonly IReader _reader;
        private readonly IWriter _writer;

        private readonly Server server;

        public Engine(IReader reader, IWriter writer)
        {
            _reader = reader;
            _writer = writer;

            server = new Server();
        }

        public void Run()
        {
            _writer.WriteLine("Welcome to Diablo 2: Console Game. Choose from the following operations:");
            _writer.WriteLine("");
            _writer.WriteLine("Join CharacterClass CharacterName // to create a new character;");
            _writer.WriteLine("You can choose from the following character classes: Amazon, Assasin, Barbarian, Druid, Necromancer, Paladin, Sorceress;");

            _writer.WriteLine("Pick CharacterName Item // to pick an item in your gear;");
            _writer.WriteLine("Use CharacterName Item // to use an item from your gear;");

            _writer.WriteLine("Attack AttackerName ReceiverName // to attack a character only with weapon;");
            _writer.WriteLine("AbilityAttack AttackerName ReceiverName // to attack a character with a special ability;");
            _writer.WriteLine("Barbarians can choose from the following abilities: Battlecry, Ferocity");
            _writer.WriteLine("Paladin can choose from the following abilities: Charge, Zealotry");

            _writer.WriteLine("Stats // to view the current stats of all characters;");
            _writer.WriteLine("EndTurn // to end the round and let the characters that are still alive recover;");

            isRunning = true;

            while (isRunning)
            {
                string command = _reader.ReadLine();

                try
                {
                    ReadCommand(command);
                }
                catch (ArgumentException e)
                {
                    _writer.WriteLine($"Parameter error: {e.Message}");
                }
                catch(InvalidOperationException e)
                {
                    _writer.WriteLine($"Invalid operation: {e.Message}");
                }

                if (server.IsGameOver() || isRunning == false)
                {
                    _writer.WriteLine("Final stats:");
                    _writer.WriteLine(server.GetStats());
                    isRunning = false;

                }
            }
        }

        private void ReadCommand(string command)
        {

            if (string.IsNullOrEmpty(command))
            {
                isRunning = true;
            }

                var commandArgs = command.Split(' ');
                var commandName = commandArgs[0];
                var args = commandArgs.Skip(1).ToArray();

                var output = string.Empty;

            switch (commandName)
            {
                case "Join":
                     output = server.JoinServer(args);
                     break;

                case "Pick":
                     output = server.CollectItemsByCharacters(args);
                     break;

                case "Use":
                     output = server.UseItemBy(args);
                     break;

                case "AbilityAttack":
                     output = server.AbilityAttack(args);
                     break;

                case "GetStats":
                     output = server.GetStats();
                     break;

                case "Attack":
                     output = server.Attack(args);
                     break;

                case "EndTurn":
                    output = server.EndTurn();
                    break;

                case "Exit":
                    output = "Goodbye!";
                    isRunning = false;
                    break;

                default:
                        output = "Please, enter a valid command!";
                        break;
            }

            if (output != string.Empty)
            {
              _writer.WriteLine(output);
            }

        }
    }
}