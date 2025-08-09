/*
================================================================================
CREATIVITY AND EXCEEDING REQUIREMENTS REPORT
================================================================================

To exceed the requirements for this project and achieve 100%, I have implemented
the following features:

1.  **New Goal Type: Negative Goal**
    -   I've added a `NegativeGoal` class. This allows users to track bad habits
        they want to break.
    -   When a user records an event for a negative goal (e.g., "Skipped a workout"),
        they lose points, adding a new dimension to the gamification.

2.  **Gamification: Leveling System**
    -   The program includes a simple but effective leveling system. The user's
        level increases for every 1000 points they earn.
    -   The current level is displayed along with the score, giving the user a
        sense of progression and achievement beyond just a raw score.
        For example: "You have 2550 points. (Level 2)"

3.  **Enhanced User Interface (UI) and Experience (UX)**
    -   I've used `Console.ForegroundColor` to add color to the UI, making it
        more visually appealing and easier to read.
    -   Informative messages, loading spinners (e.g., "Saving..."), and clear
        prompts guide the user through the program, making it more intuitive
        and user-friendly.

4.  **Robust Error Handling**
    -   User input is validated to prevent the program from crashing. For example,
        if the user is asked to enter a number and types text instead, the
        program will show a friendly error message and prompt again, rather
        than throwing an exception.

================================================================================
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}