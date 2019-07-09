using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using src;
using Xunit;

namespace test
{
    public class ValidationTests
    {
        [Fact]
        public void Test_Receipe_Validation()
        {
            var recipe = new Recipe();
            var context = new ValidationContext(recipe, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(recipe, context, results);
            Assert.False(isValid);
            Assert.True(results.Count > 0);

            if (!isValid)
            {
                foreach (var validationResult in results)
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }
            }

            recipe.Name = "Something";
            results = new List<ValidationResult>();
            isValid = Validator.TryValidateObject(recipe, context, results);
            Assert.True(isValid);
            Assert.True(results.Count == 0);
        }

        [Fact]
        public void Test_Game_Validation()
        {
            var invalidGame = new Game
            {
                Name = "My name is way over 20 characters",
                Price = 300,
            };

            if (!Validate(invalidGame, out var results))
            {
                Console.WriteLine(String.Join("\n", results.Select(o => o.ErrorMessage)));
            }
            else
            {
                Console.WriteLine("I'm a valid object!");
            }
        }

        static bool Validate<T>(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }

    }
}
