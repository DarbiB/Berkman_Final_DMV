using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Berkman_Final_DMV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictionaryListController : ControllerBase
    {
        // POST api/<DictionaryListController>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<List<Dictionary<string, string>>> ProcessInput([FromBody] List<Dictionary<string, string>> inputList)
        {
            Dictionary<string, string> uniqueDict = new Dictionary<string, string>();
            Dictionary<string, int> duplicateDict = new Dictionary<string, int>();

            foreach (var input in inputList)
            {
                foreach (var item in input)
                {
                    if (uniqueDict.ContainsKey(item.Key))
                    {
                        if (!duplicateDict.ContainsKey(item.Key))
                        {
                            // Second occurrence of the key, add it to the duplicate dictionary
                            duplicateDict.Add(item.Key, 2);
                        }
                        else
                        {
                            // 3rd or more occurrence of the key, increase the count in the duplicate dictionary
                            duplicateDict[item.Key]++;
                        }
                    }
                    else
                    {
                        // First occurence, add to unique dictionary
                        uniqueDict.Add(item.Key, item.Value);
                    }
                }
            }

            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            result.Add(uniqueDict);
            result.Add(duplicateDict.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToString()));

            return result;
        }
    }
}
