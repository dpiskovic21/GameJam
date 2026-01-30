using System.Text;
using System.Text.Json;
using WinFormsApp1.models;

namespace WinFormsApp1.service
{
    public static class GoogleSheetService
    {
        private static string SheetUrl = "https://script.google.com/macros/s/AKfycbxm_GisTfwY3CqeNZ893W6MxPA8jpcA0SeNKkl1OCO4jzPZKDt3WyymTIBa5MvBOG4-/exec";

        public static async Task SubmitScore(string username, int score)
        {

            var payload = new
            {
                username = username,
                score = score,
                timestamp = DateTime.UtcNow
            };

            using var client = new HttpClient();
            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await client.PostAsync(SheetUrl, content);
        }

        public static async Task<List<LeaderboardDTO>> getLeaderboardEntries()
        {
            using var client = new HttpClient();
            var json = await client.GetStringAsync(SheetUrl);

            return JsonSerializer.Deserialize<List<LeaderboardDTO>>(json);
        }
    }
}
