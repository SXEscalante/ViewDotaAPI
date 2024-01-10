using FullStackAuth_WebAPI.Models;
using Newtonsoft.Json;

namespace FullStackAuth_WebAPI.Services
{
    public class SteamApiService
    {
        //
        public async Task<AccountInfo> GetSteamInfoAsync(string accountId)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage responce = await client.GetAsync($"https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/v1/?Key=0BEC74DD9AEF94FC1816B2F07F64233A&matches_requested=100&account_id={accountId}");

                if (responce.IsSuccessStatusCode)
                {
                    string jsonResponce = await responce.Content.ReadAsStringAsync();
                    AccountInfo accountInfo = JsonConvert.DeserializeObject<AccountInfo>(jsonResponce);

                    return accountInfo;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
