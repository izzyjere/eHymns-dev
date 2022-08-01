
using EHymns.Interfaces;
using EHymns.Models;

using System.Reflection;

namespace EHymns.Data
{
    public static class Database
    {
       
        static string Data { get; set; }
        public static async Task ChangeLanguage(string language)
        {

            await SecureStorage.SetAsync("language", language);
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Database)).Assembly;
            Stream stream = assembly.GetManifestResourceStream($"EHymns.Data.{language}.json");

            using (var reader = new StreamReader(stream))
            {
                Data = await reader.ReadToEndAsync();
            }
            ToastService.Show($"Language changed to {language}");

        }
        public static async Task Initialize()
        {

            var language = await SecureStorage.GetAsync("language");
            if (string.IsNullOrEmpty(language))
            {
                language = "english";
                await SecureStorage.SetAsync("language", language);
            }
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Database)).Assembly;
            Stream stream = assembly.GetManifestResourceStream($"EHymns.Data.{language}.json");
            using var reader = new StreamReader(stream);
            Data = await reader.ReadToEndAsync();

        }
        //public static async Task UpdateRecent(Hymn hymn)
        //{
        //    //await SecureStorage.SetAsync("recent", JsonConvert.SerializeObject(hymn));
        //    return;
        //}
        //public static async Task<Hymn> GetRecent()
        //{
        //    var recent = await SecureStorage.GetAsync("recent");
        //    if (string.IsNullOrEmpty(recent))
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        return JsonConvert.DeserializeObject<Hymn>(recent);
        //    }
        //}
        public static async Task AddToFavorites(Hymn hymn)
        {
            var data = await SecureStorage.GetAsync("favourites");
            var list = new List<Hymn>();
            if (string.IsNullOrEmpty(data))
            {
                list.Add(hymn);
                await SecureStorage.SetAsync("favourites", JsonConvert.SerializeObject(list));
                return;
            }
            list = JsonConvert.DeserializeObject<List<Hymn>>(data);
            if (list.Any(x => x.Number == hymn.Number))
            {
                return;
            }
            list.Add(hymn);
            await SecureStorage.SetAsync("favourites", JsonConvert.SerializeObject(list));
            ToastService.Show("Song was added to favourites");
        }
        public static async Task<HashSet<Hymn>> GetFavourites()
        {
            var data = await SecureStorage.GetAsync("favourites");
            var list = new List<Hymn>();
            if (!string.IsNullOrEmpty(data))
            {
                list = JsonConvert.DeserializeObject<List<Hymn>>(data);
            }
            return new(list);
        }
        public static async Task RemoveFromFavorites(Hymn hymn)
        {
            var data = await SecureStorage.GetAsync("favourites");
            var list = JsonConvert.DeserializeObject<List<Hymn>>(data);
            if (!list.Any(h => h.Number == hymn.Number) || !list.Any())
            {
                return;
            }
            list.Remove(list.FirstOrDefault(h => h.Number == hymn.Number));
            await SecureStorage.SetAsync("favourites", JsonConvert.SerializeObject(list));
            ToastService.Show("Song was removed from favourites");
        }
        public static async Task<HashSet<Hymn>> GetHymns()
        {
            var root = JsonConvert.DeserializeObject<Root>(Data);
            return new(root.Hymns);
        }
        public static async Task<Hymn> GetHymn(string number)
        {
            return (await GetHymns()).FirstOrDefault(x => x.Number == number);
        }
        public static async Task<List<Hymn>> Search(string searchText, bool fav = false)
        {
            var result = new List<Hymn>();
            if (!string.IsNullOrEmpty(searchText))
            {
                if (!fav)
                {
                    result = (await GetHymns()).Where(
                        h => h.Number.Contains(searchText) ||
                                h.Title.Contains(searchText) ||
                                h.Category.Contains(searchText) ||
                                h.TitleWithHymnNumber.Contains(searchText) ||
                                h.Chorus.Contains(searchText) ||
                                h.Verses.Any(v => v.Contains(searchText))

                     ).ToList();
                }
                else
                {
                    result = (await GetFavourites()).Where(
                        h => h.Number.Contains(searchText) ||
                                h.Title.Contains(searchText) ||
                                h.Category.Contains(searchText) ||
                                h.TitleWithHymnNumber.Contains(searchText) ||
                                h.Chorus.Contains(searchText) ||
                                h.Verses.Any(v => v.Contains(searchText))

                     ).ToList();
                }

            }
            return result;
        }
    }
}
