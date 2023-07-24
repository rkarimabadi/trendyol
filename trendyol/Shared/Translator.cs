using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Web;

namespace trendyol.Shared;

public class Translator : ITranslator
{
    public const string ecoEscapeBlank = "'";
    private readonly HttpClient HttpClient;
    public Translator(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }
    public async Task<string> Translate(string input, string fromLanguage= "fa", string toLanguage = "tr")
    {
        //ArgumentNullException.ThrowIfNull(nameof(input));
        //var modifiedinput = input.Replace("‘","'");
        var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(input)}";

        try
        {
            var result = await HttpClient.GetStringAsync(url);
            //result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);                

            JArray jj = JsonConvert.DeserializeObject(result) as JArray;
            var stringList = ReadJArrayRes(jj);
            result = stringList.Count > 1 ? stringList.Aggregate((i, j) => i + " " + j) : stringList.Count > 0 ? stringList[0] : string.Empty;

            result = result.Replace("\\u200c", "‌");
            return result;

        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message);
        }
    }
    private List<string> ReadJArrayRes(JArray jj)
    {
        if (jj == null)
        {
            return null;
        }
        List<string> li = new List<string>();
        bool bEndCell = false;
        JToken j_0 = jj[0];
        StringBuilder sb = new StringBuilder();
        int iLen = j_0.Count();
        for (int i = 0; i < iLen; i++)
        {
            JToken item = j_0[i];
            if (item != null)
            {
                if (item[0] != null)
                {
                    string j_0_0 = item[0].ToString();
                    if (j_0_0.EndsWith("\n") || i == iLen - 1)
                    {
                        bEndCell = true;
                    }
                    else
                    {
                        sb.Append(j_0_0);
                    }

                    if (bEndCell)
                    {
                        string[] rowppT = j_0_0.Split(new string[] { "\n" }, StringSplitOptions.None);
                        string[] rowpp = new string[rowppT.Length > 1 ? rowppT.Length - 1 : rowppT.Length];
                        rowpp[0] = rowppT[0] == "..." ? null : rowppT[0];
                        if (sb.Length > 0)
                        {
                            rowpp[0] = sb.ToString() + rowpp[0];
                            //when first line is blank, tip: insert 「。。。」, than after translated return value = [. . .]
                            if (rowpp[0] == ". . .")
                            {
                                rowpp[0] = null;
                            }
                        }
                        li.AddRange(rowpp);
                        sb.Clear();
                        bEndCell = false;
                    }
                }
            }
        }
        return li;
    }
}