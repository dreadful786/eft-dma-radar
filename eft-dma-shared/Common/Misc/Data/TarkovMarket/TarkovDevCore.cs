using System.Net.Http.Headers;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Reflection;
using System.Text;
using System.IO;
using System.Text.Json.Serialization;

namespace eft_dma_shared.Common.Misc.Data.TarkovMarket
{
    internal static class TarkovDevCore
    {
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public static async Task<TarkovDevQuery> QueryTarkovDevAsync()
        {
            var query = new Dictionary<string, string>()
            {
                { "query",
                """
                {
                    items(gameMode:pve) { 
                        id 
                        name 
                        shortName 
                        width 
                        height 
                        sellFor { 
                            vendor { 
                                name 
                            } 
                            priceRUB 
                        } 
                        basePrice 
                        avg24hPrice 
                        historicalPrices { 
                            price 
                        } 
                        categories { 
                            name 
                        } 
                    }
                    questItems { 
                        id shortName 
                    }
                    lootContainers { 
                        id 
                        normalizedName 
                        name 
                    }
                    tasks {
                        id
                        name
                        objectives {
                            id
                            type
                            description
                            maps {
                                id
                                name
                                normalizedName
                            }
                            ... on TaskObjectiveItem {
                                item {
                                id
                                name
                                shortName
                                }
                                zones {
                                id
                                map {
                                    id
                                    normalizedName
                                    name
                                }
                                position {
                                    y
                                    x
                                    z
                                }
                                }
                                requiredKeys {
                                id
                                name
                                shortName
                                }
                                count
                                foundInRaid
                            }
                            ... on TaskObjectiveMark {
                                id
                                description
                                markerItem {
                                id
                                name
                                shortName
                                }
                                maps {
                                id
                                normalizedName
                                name
                                }
                                zones {
                                id
                                map {
                                    id
                                    normalizedName
                                    name
                                }
                                position {
                                    y
                                    x
                                    z
                                }
                                }
                                requiredKeys {
                                id
                                name
                                shortName
                                }
                            }
                            ... on TaskObjectiveQuestItem {
                                id
                                description
                                requiredKeys {
                                id
                                name
                                shortName
                                }
                                maps {
                                id
                                normalizedName
                                name
                                }
                                zones {
                                id
                                map {
                                    id
                                    normalizedName
                                    name
                                }
                                position {
                                    y
                                    x
                                    z
                                }
                                }
                                requiredKeys {
                                id
                                name
                                shortName
                                }
                                questItem {
                                    id
                                    name
                                    shortName
                                    normalizedName
                                    description
                                }
                                count
                            }
                            ... on TaskObjectiveBasic {
                                id
                                description
                                requiredKeys {
                                id
                                name
                                shortName
                                }
                                maps {
                                id
                                normalizedName
                                name
                                }
                                zones {
                                id
                                map {
                                    id
                                    normalizedName
                                    name
                                }
                                position {
                                    y
                                    x
                                    z
                                }
                                }
                                requiredKeys {
                                id
                                name
                                shortName
                                }
                            }
                        }
                    }
                }
                """
                }
            };
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(20));
            using var response = await SharedProgram.HttpClient.PostAsJsonAsync(
                requestUri: "https://api.tarkov.dev/graphql",
                value: query,
                cancellationToken: cts.Token);
            response.EnsureSuccessStatusCode();
            return await JsonSerializer.DeserializeAsync<TarkovDevQuery>(await response.Content.ReadAsStreamAsync(), _jsonOptions);
        }

        /// <summary>
        /// Compares default_data.json with data.json and adds any missing items to data.json
        /// </summary>
        /// <returns>Task representing the operation</returns>
        public static async Task MergeDefaultDataWithDataJsonAsync()
        {
            string dataFilePath = Path.Combine(SharedProgram.ConfigPath.FullName, "data.json");

            // Check if data.json exists
            if (!File.Exists(dataFilePath))
            {
                return; // Nothing to merge if data.json doesn't exist
            }

            try
            {
                // Load default data
                string defaultJson = await GetDefaultDataAsync();
                var jsonOptions = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                    NumberHandling = JsonNumberHandling.AllowReadingFromString
                };

                var defaultData = JsonSerializer.Deserialize<EftDataManager.TarkovMarketData>(defaultJson, jsonOptions);

                // Load current data.json
                string dataJson = await File.ReadAllTextAsync(dataFilePath);
                var currentData = JsonSerializer.Deserialize<EftDataManager.TarkovMarketData>(dataJson, jsonOptions);

                bool hasChanges = false;

                // Create dictionary of existing items by BsgId for quick lookup
                var existingItemsDict = currentData.Items.ToDictionary(i => i.BsgId, StringComparer.OrdinalIgnoreCase);

                // Find missing items from default data
                foreach (var defaultItem in defaultData.Items)
                {
                    if (!existingItemsDict.ContainsKey(defaultItem.BsgId))
                    {
                        // Add missing item to current data
                        currentData.Items.Add(defaultItem);
                        hasChanges = true;
                    }
                }

                // Create dictionary of existing tasks by Id for quick lookup
                var existingTasksDict = currentData.Tasks?.ToDictionary(t => t.Id, StringComparer.OrdinalIgnoreCase)
                    ?? new Dictionary<string, EftDataManager.TaskElement>(StringComparer.OrdinalIgnoreCase);

                // Check if Tasks collection exists, if not, initialize it
                if (currentData.Tasks == null)
                {
                    currentData.Tasks = new List<EftDataManager.TaskElement>();
                }

                // Find missing tasks from default data
                if (defaultData.Tasks != null)
                {
                    foreach (var defaultTask in defaultData.Tasks)
                    {
                        if (!existingTasksDict.ContainsKey(defaultTask.Id))
                        {
                            // Add missing task to current data
                            currentData.Tasks.Add(defaultTask);
                            hasChanges = true;
                        }
                    }
                }

                // Save updated data if there were changes
                if (hasChanges)
                {
                    var outputJson = JsonSerializer.Serialize(currentData, new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });
                    await File.WriteAllTextAsync(dataFilePath, outputJson);
                }
            }
            catch (Exception ex)
            {
                // Log error but don't throw since this is a non-critical operation
                Console.WriteLine($"Error merging default data with data.json: {ex}");
            }
        }

        /// <summary>
        /// Gets the embedded default data JSON
        /// </summary>
        private static async Task<string> GetDefaultDataAsync()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("eft-dma-shared.DEFAULT_DATA.json"))
            {
                var data = new byte[stream!.Length];
                await stream.ReadExactlyAsync(data);
                return Encoding.UTF8.GetString(data);
            }
        }
    }
}
