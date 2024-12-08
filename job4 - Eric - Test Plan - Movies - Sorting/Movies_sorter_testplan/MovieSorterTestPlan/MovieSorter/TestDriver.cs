using System.Reflection;

namespace MovieSorter
{
    static class TestDriver
    {
        static List<Type> testClasses = new List<Type>();
        static Dictionary<string, TestResult> testResults = new Dictionary<string, TestResult>();
        static string testOutput = "";

        /// <summary>
        /// Add a number of test classes to the list of classes to be tested.
        /// </summary>
        /// <param name="testClasses">The test class to add</param>
        public static void AddTestClass(params Type[] testClasses)
        {
            TestDriver.testClasses.AddRange(testClasses);
        }

        /// <summary>
        /// Run all tests added to the test driver.
        /// </summary>
        public static void RunAllTests()
        {
            DateTime testStartTime = DateTime.Now;
            foreach (Type testClass in testClasses)
            {
                RunTestClass(testClass, testStartTime);
            }
        }

        /// <summary>
        /// Run all tests in the given test class.
        /// </summary>
        /// <param name="testClass">The test class to run</param>
        public static void RunTestClass(Type testClass)
        {
            RunTestClass(testClass, DateTime.Now);
        }

        /// <summary>
        /// Run all tests in the given test class.
        /// </summary>
        /// <param name="testClass">The test class to run</param>
        /// <param name="testStartTime">The time the tests started</param>
        static void RunTestClass(Type testClass, DateTime testStartTime)
        {
            // If the test class has inner classes, run those tests first
            Type[] innerClasses = testClass.GetNestedTypes();
            foreach (Type innerClass in innerClasses)
            {
                RunTestClass(innerClass, testStartTime);
            }

            // Initialize test results
            int passed = 0;
            int longest = GetLongestTestName(testClass);
            testOutput = "";
            testResults = new Dictionary<string, TestResult>();

            // Display the test class name
            Console.ForegroundColor = ConsoleColor.Yellow;
            WriteSeparator(longest, testClass.ToString());
            Console.ResetColor();
            object? instance = Activator.CreateInstance(testClass);

            // Get test methods
            MethodInfo[] methods = testClass.GetMethods().Where(m => m.GetCustomAttributes(typeof(TestAttribute), false).Length > 0).ToArray();
            foreach (MethodInfo method in methods)
            {
                object[] attributes = method.GetCustomAttributes(typeof(TestAttribute), false);
                if (attributes.Length > 0)
                {
                    // Display the test name
                    TestAttribute attribute = (TestAttribute)attributes[0];
                    WriteSeparator(longest, attribute.DisplayName, '─', "╟", "╢");
                    TestResult result = null;

                    // Try to run the test
                    try
                    {
                        // If the method returns a TestResult, use that
                        if (method.ReturnType == typeof(TestResult))
                        {
                            result = (TestResult)method.Invoke(instance, null);
                        }
                        // Else show the return value as the actual result
                        else
                        {
                            object? returnValue = method.Invoke(instance, null);
                            result = new TestResult(
                                attribute.DisplayName,
                                "Method return an object of type " + method.ReturnType.ToString(),
                                "Method should return a TestResult object",
                                false
                            );
                        }
                    }
                    // If the method throws a TargetParameterCountException
                    catch (TargetParameterCountException)
                    {
                        result = new TestResult(attribute.DisplayName,
                            "Method expects " + method.GetParameters().Length.ToString() + " parameters",
                            "Test method must have no parameters",
                            false
                        );
                    }
                    // If the test throws an exception, the result is the exception message
                    catch (TargetInvocationException e)
                    {
                        result = new TestResult(
                            attribute.DisplayName,
                            $"Method threw an exception: ({e.GetType()}) with message {e.InnerException.Message}",
                            "No exception should be thrown",
                            false);
                    }
                    catch (Exception e)
                    {
                        result = new TestResult(
                            attribute.DisplayName,
                            $"An exception was thrown: ({e.GetType()}) with message {e.Message}",
                            "No exception should be thrown",
                            false);
                    }

                    // Display the test result
                    DisplayResult($"{"> Input:",-12}{result.Input}");
                    DisplayResult($"{"> Expected:",-12}{result.Expected}");
                    DisplayResult($"{"> Actual:",-12}{result.Actual}");

                    if (result.Passed)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        passed++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    string passedStatus = result.Passed ? "Passed" : "Failed";
                    WriteSeparator(longest, passedStatus, '─', "╟", "╢");
                    Console.ResetColor();
                    WriteSeparator(longest, "", '═', "╠", "╣");
                    testResults.Add(attribute.DisplayName, result);
                }
            }
            WriteTestSummary(longest);
            Console.ForegroundColor = ConsoleColor.Yellow;
            WriteSeparator(longest, $"{passed} / {methods.Length.ToString()} passed", '─', leftCorner: "╙", rightCorner: "╜");
            Console.ResetColor();
            SaveResults(testClass.ToString(), testStartTime);
        }

        private static void WriteTestSummary(int longest)
        {
            Dictionary<string, TestResult> passedTests = new Dictionary<string, TestResult>();
            Dictionary<string, TestResult> failedTests = new Dictionary<string, TestResult>();
            foreach (KeyValuePair<string, TestResult> result in testResults)
            {
                if (result.Value.Passed)
                {
                    passedTests.Add(result.Key, result.Value);
                }
                else
                {
                    failedTests.Add(result.Key, result.Value);
                }
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            WriteSeparator(longest, "Test Summary", '═', "╠", "╣");
            // Display passed tests
            Console.ForegroundColor = ConsoleColor.Green;
            DisplayResult("Passed:");
            foreach (KeyValuePair<string, TestResult> result in passedTests)
            {
                DisplayResult($"> {result.Key}");
            }
            // Display failed tests
            Console.ResetColor();
            WriteSeparator(longest, "", '─', "─", "─");
            Console.ForegroundColor = ConsoleColor.Red;
            DisplayResult("Failed:");
            foreach (KeyValuePair<string, TestResult> result in failedTests)
            {
                DisplayResult($"> {result.Key}");
            }
            Console.ResetColor();
        }

        private static int GetLongestTestName(Type testClass)
        {
            MethodInfo[] methods = testClass.GetMethods().Where(m => m.GetCustomAttributes(typeof(TestAttribute), false).Length > 0).ToArray();
            int longest = 0;
            foreach (MethodInfo method in methods)
            {
                object[] attributes = method.GetCustomAttributes(typeof(TestAttribute), false);
                if (attributes.Length > 0)
                {
                    TestAttribute attribute = (TestAttribute)attributes[0];
                    if (attribute.DisplayName.Length > longest)
                    {
                        longest = attribute.DisplayName.Length;
                    }
                }
            }
            return longest > testClass.ToString().Length ? longest : testClass.ToString().Length;
        }

        private static void DisplayResult(string text)
        {
            Console.WriteLine(text);
            testOutput += text + "\n";
        }

        private static void WriteSeparator(int totalLength, string text = "", char separator = '═', string leftCorner = "╔", string rightCorner = "╗")
        {
            // Write the text in the middle of a line of dashes
            int length = text.Length;
            totalLength = totalLength + 4;
            int left = (totalLength - length) / 2;
            int right = totalLength - length - left;
            string line = $"{leftCorner}{new string(separator, left)}{text}{new string(separator, right)}{rightCorner}";
            Console.WriteLine(line);
            testOutput += line + "\n";
        }

        private static void SaveResults(string name, DateTime testStartTime)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"results_{testStartTime.ToString("yyyy-MM-dd_HH-mm-ss")}");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fileName = $"{name.Replace(" ", "_")}";
            string filePath = Path.Combine(path, fileName + ".txt");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(testOutput);
            }
        }
    }

    static class Assertions
    {
        /// <summary>
        /// Tests if an exception is thrown when a given action is executed
        /// </summary>
        /// <param name="action">The action to execute</param>
        /// <param name="input">The string describing the input</param>
        /// <param name="expectedExceptions">One or more exceptions that are expected to be thrown</param>
        /// <returns>A TestResult object containing the results of the test</returns>
        public static TestResult AssertThrows(Action action, string input, params Type[] expectedExceptions)
        {
            try
            {
                action();
                return new TestResult(input, "An exception of type " + expectedExceptions[0].ToString() + " should be thrown", "No exception was thrown", false);
            }
            catch (Exception e)
            {
                if (expectedExceptions.Contains(e.GetType()))
                {
                    return new TestResult(input, "An exception of type " + expectedExceptions[0].ToString() + " should be thrown", "An exception of type " + e.GetType().ToString() + " was thrown", true);
                }
                else
                {
                    return new TestResult(input, "An exception of type " + expectedExceptions[0].ToString() + " should be thrown", "An exception of type " + e.GetType().ToString() + " was thrown", false);
                }
            }
        }
    }

    class TestAttribute : System.Attribute
    {
        public string DisplayName { get; }
        public TestAttribute(string displayName)
        {
            DisplayName = displayName;
        }
    }

    /// <summary>
    /// A record to hold the results of a test. This should be returned by all test methods.
    /// </summary>
    /// <param name="Input">The string representation of the input to the test</param>
    /// <param name="Expected">The string representation of the expected output</param>
    /// <param name="Actual">The string representation of the actual output</param>
    /// <param name="Passed">Whether the test passed or not</param>
    /// <returns></returns>
    public record TestResult(string Input, string Expected, string Actual, bool Passed);
}
