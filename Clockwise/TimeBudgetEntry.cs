﻿using System;

namespace Clockwise
{
    public class TimeBudgetEntry
    {
        private TimeSpan remainingDuration;

        internal TimeBudgetEntry(
            string name,
            TimeBudget budget)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
            }

            Name = name;
            ElapsedDuration = budget.ElapsedDuration;
            remainingDuration = budget.RemainingDuration;
            BudgetWasExceeded = budget.IsExceeded;
        }

        public string Name { get; }

        internal TimeSpan ElapsedDuration { get; }

        public bool BudgetWasExceeded { get; }

        public override string ToString()
        {
            var symbol = BudgetWasExceeded
                             ? "❌"
                             : "✔";

            var exceededMessage = BudgetWasExceeded
                                      ? $" (budget exceeded by {Math.Abs(remainingDuration.TotalSeconds)} seconds)"
                                      : string.Empty;

            return $"{symbol} {Name} @ {ElapsedDuration.TotalSeconds} seconds{exceededMessage}";
        }
    }
}
