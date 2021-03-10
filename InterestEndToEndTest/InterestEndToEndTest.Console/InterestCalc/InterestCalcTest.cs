using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace InterestEndToEndTest.Console.InterestCalc
{
    public class InterestCalcTest
    {
        public const string InterestCalcUrlVariable = "INTEREST_CALC_URL";
        public const string DefaultInterestCalcUrl = "http://localhost:8002/v1/interest-calc";
        private readonly string _interestCalcUrl;

        public InterestCalcTest()
        {
            var interestCalcUrl = Environment.GetEnvironmentVariable(InterestCalcUrlVariable);
            _interestCalcUrl = string.IsNullOrEmpty(interestCalcUrl)
                ? DefaultInterestCalcUrl
                : interestCalcUrl;
        }

        public void ExecuteInterestCalcTest()
        {
            try
            {
                InterestCalc_ShouldBeExecutedWithoutError()
                    .GetAwaiter()
                    .GetResult();

                System.Console.WriteLine($"SUCCESS: The end to end test was executed with success");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"ERROR: Occurred an error at test. Url: {_interestCalcUrl}, message: {ex.Message}");
            }
        }

        private async Task InterestCalc_ShouldBeExecutedWithoutError()
        {
            var url = $"{_interestCalcUrl}?months=1&initialValue=100";
            const decimal expectedResult = 101m;

            using var client = new HttpClient();

            var response = await client.GetAsync(url);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRequestException($"ERROR: Inavalid response status. Expect {HttpStatusCode.OK}, bus was found {response.StatusCode}");
            };

            var body = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<InterestCalcResponse>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (result?.CalcResult != expectedResult)
            {
                throw new Exception($"ERROR: InterectCalc return a invalid value. Expect {expectedResult}, bus was found {result.CalcResult}");
            }
        }
    }
}