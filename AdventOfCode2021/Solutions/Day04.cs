using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Solutions
{
    public class Day04
    {
        public (List<int> numbers, List<BingoCard> bingoCards) ParseInput(string[] input)
        {
            var numbers = input.Take(1).Single().Split(',').Select(int.Parse).ToList();
            var cards = input.Skip(2);

            var bingoCards = cards.Chunk(6).Select(x=> new BingoCard(x)).ToList();

            return (numbers, bingoCards);
        }

        public int Part1(string[] input)
        {
            var game = ParseInput(input);

            foreach(var number in game.numbers)
            {
                //process each number
                foreach(var card in game.bingoCards)
                {
                    card.MarkNumber(number);
                }
                var winningCard = game.bingoCards.SingleOrDefault(x => x.HasWon());
                if (winningCard == null)
                    continue;

                return winningCard.SumOfUnmarkedNumbers() * number;
            }

            game.bingoCards[0].MarkNumber(22);
            
            return 0;
        }


        public int Part2(string[] input)
        {
            return 0;
        }
    }
    
    public record BingoCard
    {
        private BingoCardSlot[][] _card;

        public BingoCard(string[] input)
        {
            //Ignore blank line separator
            _card =  input.Take(5)
                .Select(x => x.Split(" ")
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Select(x => new BingoCardSlot(int.Parse(x))).ToArray())
                .ToArray();
        }

        public void MarkNumber(int number)
        {
            foreach(var cardNumber in _card.SelectMany(x => x.Where(x => x.Number == number)))
            {
                cardNumber.Chosen = true;
            }
        }

        public bool HasWon()
        {
            var winningRow = _card.Any(x => x.All(x => x.Chosen));
            var winningColumn = Enumerable.Range(0, 5).Any(i => _card.All(x => x[i].Chosen));

            return winningRow || winningColumn;
        }

        public int SumOfUnmarkedNumbers()
        {
            return _card.SelectMany(x => x.Where(y => !y.Chosen)).Sum(x => x.Number);
        }
    }

    public record BingoCardSlot(int Number)
    {
        public bool Chosen { get;set; }
    };
}
