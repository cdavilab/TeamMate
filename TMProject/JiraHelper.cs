using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TMProject
{
    public class JiraHelper
    {
        private static string apiToken = "ATATT3xFfGF09zXDbsh61QHGWF2Y0gQtLNzb5E9MMJhVc6GNdmhnWEshXnhQ0iD6dmai5qkdjK76cXfVStH2FlYilyT4ujL0E1CQDf4Q2-YOW7xyIowL5YX5jJwtPW1d8ZZIvUJVmDnMvGc-r1WNgTfrHQ9d1JzJb0Z1WdFPdWEY2-XSjetDMTY=563184DD";
        //private static string apiToken = "ATCTT3xFfGN0xOdkRKf9j3IqoNHNbY69cTLE52i7RaAIBmQxwIUIPxNWYwo9iBdPAfXZ_c55Li2hLiOUCZQZHffeDzTCDCOAJg_S4XTodtetKH-XXJSWwnY9utxD5xlTH1uNG_9HnCL6FJjAYy_459rtRlEZ09cpgtJsvtEKlZybnQVK3ZYo9Es=A52C6164";
        private static string jiraUrl = "https://infoarchbol.atlassian.net/rest/api/2/issue";
        private static string jiraUser = "cdavila@info-arch.com";
        private static string projectKey = "TEAM";
        private static readonly HttpClient client = new HttpClient();

        public static async Task CreateJiraDefectAsync(string summary, string description)
        {

            //using (HttpClient client = new HttpClient()) {
            // client.BaseAddress = new Uri(jiraUrl);
            try
            {
                //client.Timeout = TimeSpan.FromSeconds(30);
                var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{jiraUser}:{apiToken}"));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authToken);
                Console.WriteLine($"Ingresó a crear el defect '{summary}' with desc  {description} ");
                var newIssue = new
                {
                    fields = new
                    {
                        project = new { key = projectKey },
                        summary = summary,
                        description = description,
                        issuetype = new { name = "Bug" },
                        labels = new[] { "automation", "selenium" }

                    }
                };

                var jsonIssue = JsonConvert.SerializeObject(newIssue);
                Console.WriteLine($"Json '{jsonIssue}'json error {jsonIssue.ToString()} ");
                var content = new StringContent(jsonIssue, Encoding.UTF8, "application/json");
                Console.WriteLine($"Content '{content}'content error {content.ToString()} ");
                HttpResponseMessage response = await client.PostAsync(jiraUrl, content);
                response.EnsureSuccessStatusCode();

               // string responseBody = await response.Content.ReadAsStringAsync();
               // Console.WriteLine("Issue created successfully: " + responseBody);
                
                //Console.WriteLine($"Response '{response.IsSuccessStatusCode}'response error {response.StatusCode} ");
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Issue created successfully: " + responseBody);
                }
                else {
                    Console.WriteLine("Error creating Jira Issue:" + response.StatusCode);
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Request error: " + ex.Message);
            }
            catch (TaskCanceledException ex) {
                Console.WriteLine("Request timeout: " + ex.Message);
            }
            catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

           // }
        }

        public static string GetScreenshot(string testName,IWebDriver driver)
        {

            try
            {
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string screenshotPath = $"{testName}_screenshot.png";
                screenshot.SaveAsFile(screenshotPath);
                return screenshotPath;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Failed to capture scrennshot:" + ex.Message);
                return "Screenshot capture failed.";
            }
        }

        public static void createVector()
        {
            //Create and Initialize
            int[] testCases1 = new int[2];
            testCases1[0] = 1;
            testCases1[1] = 2;

            int[] testResults = { 10, 21, 3, 45, 5, 6, 20, 8, 91, 10 };//0-9
            string[] testMessage = { "", "", "" };//0-2
            bool[] testStatus = { true, false, true, false };//0-3

            //access and modify
            int value = testResults[0];//first element
            testResults[0] = value;//update value;
            testStatus[1] = true;

            //Iterate
            for (int i = 0; i < testResults.Length; i++) {
                Console.WriteLine("The Array's items  using For are: " + string.Join(", ",testResults[i]));
            }
            foreach (int item in testResults) {
                Console.WriteLine("The Array's items  using Foreach are: " + item);
            }
            Array.Reverse(testResults);
            Console.WriteLine("The Array's items  after reverse: " + string.Join(", ", testResults));
                       
            Array.Sort(testResults);
            Console.WriteLine("The Array's items  after sorting: " + string.Join(", ", testResults));

            //Applying Array to test Automation
            string[] testCases = { "LoginTest", "CreateAditPlanTest", "CreateAssessmentTest" };
            bool[] testResultTests = { true, false, true };
            for (int i = 0; i < testCases.Length; i++) {
                Console.WriteLine($"The Test {testCases[i]}:{(testResultTests[i]?"passed":"failed")}");
                }

            
        }

    }


}
