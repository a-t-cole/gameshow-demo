using gameshow_core.Models;
using gameshow_core.Models.Classes; 
using gameshow_core.Models.Rounds;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Text.RegularExpressions;

namespace QuestionBuilder
{
    public class DummyDataBuilder
    {
        public ConnectionRound GetConnectionRound(ConnectionType connectionType) 
        {
            var round = new ConnectionRound()
            {
                Qestions = new Dictionary<int, ConnectionQuestion>()
            };
            int currentItemIndex = 1; 
            for (var i = 0; i < 6; i++) 
            {
                round.Qestions.Add(i, GetConnectionQuestion(currentItemIndex, connectionType));
            }
            return round;
        }
        public ConnectionQuestion GetConnectionQuestion(int itemStartIndex, ConnectionType connectionType) 
        {
            var question = new ConnectionQuestion()
            {
                Answer = $"Answer {itemStartIndex}",
                QuestionType = connectionType,
                Steps = new Dictionary<int, ConnectionItem>()
            };
            for (int i = 0; i < 4; i++) 
            {
                var item = new ConnectionItem()
                {
                    Name = i == 3 && connectionType == ConnectionType.SEQUENCE ? "?" :  $"Item {++itemStartIndex}",
                    ImageURL = "",
                    Postition = i
                };
                question.Steps.Add(i, item);
            }
            return question; 
        }

        public IEnumerable<WallGroup> GetWallRound() 
        {
            var wallGroups = new List<WallGroup>();
            for (var i = 0; i < 4; i++) 
            {
                int itemCount = 0;
                var group = new WallGroup()
                {
                    Connection = $"Group {i}",
                    Items = Enumerable.Repeat(new ConnectionItem() { Name = $"Wall Group {i} - {itemCount++}" }, 4)
                };
                wallGroups.Add(group);
            }
            return wallGroups; 
        }

        public MissingVowelRound GetMissingVowelRound() 
        {
            var round = new MissingVowelRound() { Categories = new List<MissingVowelCategory>() };

            round.Categories.Append(
            new MissingVowelCategory()
            {
                CategoryName = "Addam's Family Characters",
                Questions = new List<MissingVowelItem>()
                {
                    GetMissingVowelItemFromString("Mortitia Addams"),
                    GetMissingVowelItemFromString("Uncle Fester"),
                    GetMissingVowelItemFromString("Wednesday Addams"),
                    GetMissingVowelItemFromString("Gomez Addams")
                }
            });

            round.Categories.Append(
            new MissingVowelCategory()
            {
                CategoryName = "Desserts",
                Questions = new List<MissingVowelItem>()
                {
                    GetMissingVowelItemFromString("Strawberry Yohgurt"),
                    GetMissingVowelItemFromString("Blackcurrant Cheesecake"),
                    GetMissingVowelItemFromString("Chocolate Lava Cake"),
                    GetMissingVowelItemFromString("Genoise Sponge Cake")
                }
            });
            round.Categories.Append(
            new MissingVowelCategory()
            {
                CategoryName = "Doctor Who",
                Questions = new List<MissingVowelItem>()
                {
                    GetMissingVowelItemFromString("The TARDIS"),
                    GetMissingVowelItemFromString("Cybermen"),
                    GetMissingVowelItemFromString("Gallifrey"),
                    GetMissingVowelItemFromString("The Matrix")
                }
            });

            return round; 
        }

        public MissingVowelItem GetMissingVowelItemFromString(string item) 
        {
            return new MissingVowelItem() {Answer = item, Question = Regex.Replace(item, "[aeiou]", "", RegexOptions.IgnoreCase) }; 
        }
    }
}
