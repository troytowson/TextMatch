using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMatch.Services
{
    /// <summary>
    /// Represents a contract for all service that implement text matching.
    /// </summary>
    public interface ITextMatchingService
    {
        string Match(string text, string subtext);
    }

    /// <summary>
    /// Represents a service for text matching
    /// </summary>
    public class TextMatchingService : ITextMatchingService
    {
        /// <summary>
        /// Matches the whole subtext against the text.
        /// </summary>
        public string Match(string text, string subtext)
        {
            // If either inputs are noting then respond with a missing input message
            if (String.IsNullOrWhiteSpace(text) || String.IsNullOrWhiteSpace(subtext))
                return "Please provide Text and Subtext";

            var output = new List<int>();

            // Iterate through each element of the text.
            for (int i = 0; i < text.Length; i++)
            {
                var match = true;
                // Iterate throguh all elements of the subtext.
                for (int j = 0; j < subtext.Length; j++)
                {
                    // Compares the characters against each other
                    match &= (Char.ToLower(text[i + j]) == Char.ToLower(subtext[j]));

                    // If a single fail happens then this will break the loop preventing 
                    // any further check allowing it to start over, not missing any characters.
                    if (!match)
                    {
                        break;
                    }
                }

                // If a successful match then record the index of occurence. 
                // Then increment the index by the length of the subtext.
                if (match)
                {
                    output.Add(i + 1);
                    i += subtext.Length - 1;
                }
            }

            // If record found then join the list of indexed by a ','
            return output.Count == 0
                ? "There is no output"
                : String.Join(",", output);
        }
    }
}
