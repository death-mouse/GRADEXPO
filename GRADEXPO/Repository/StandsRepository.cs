﻿using System.Threading.Tasks;
using GRADEXPO.Models;
using GRADEXPO.Context;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Net;

namespace GRADEXPO.Repository
{
    public class StandsRepository : IStandsRepository
    {
        public StandsRepository() { }

        /// <summary>
        /// Получение конкретного стенда для выставки
        /// </summary>
        /// <param name="_expoId">ID выставки</param>
        /// <param name="_stendId">ID стенда в выставке</param>
        /// <returns>Stands конкретный стенд в выставке</returns>
        public async Task<Stands> GetStandAsync(int _expoId, int _stendId)
        {
            Stands result = null;
            switch( Properties.Settings.Default.GetDataFrom)
            {
                case "db":
                    using (var standsContext = new StandsContext())
                    {
                        result = await standsContext.Stands.FirstOrDefaultAsync(f => f.expoId == _expoId && f.standId == _stendId);
                    }
                    break;
                case "Json":
                    string json = await GRADEXPO.HttpClient.Browser.GetAsync(string.Format("{0}{1}({2})", Properties.Settings.Default.BaseUrlApi,
                                                                                                             Properties.Settings.Default.postfixGetStand,
                                                                                                             _stendId));
                    Stands stands = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Stands>(json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore }));
                    result = stands;
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
                    break;
            }
            return result;
        }
        /// <summary>
        /// Получения всех стендов по выставке
        /// </summary>
        /// <param name="_expoId">Id выставки по которой нужно получить список стендов</param>
        /// <returns>List<Stands> список стендов в выставке</returns>
        public async Task<IEnumerable<Stands>> GetStandsAsync(int _expoId)
        {
            List<Stands> result = null;//new List<Stands>();
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "db":
                    using (var standsContext = new StandsContext())
                    {
                        result = await standsContext.Stands.Where(f => f.expoId == _expoId).ToListAsync();
                    }
                    break;
                case "Json": 
                    string json = await GRADEXPO.HttpClient.Browser.GetAsync(string.Format("{0}{1}({2})/{3}", Properties.Settings.Default.BaseUrlApi, 
                                                                                                             Properties.Settings.Default.postfixGetExpo,
                                                                                                             _expoId,
                                                                                                             Properties.Settings.Default.postfixGetStand));
                    StandsFromJson.Values rootObject = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<StandsFromJson.Values>(json));
                    if (rootObject.value == null)
                    {
                        throw new WebException(string.Format("Не удалось найти стенды для выставки с Id = {0}. Убедитесь в корретности выбранной выставки", _expoId));
                    }
                    result = rootObject.value;
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
                    break;
            }
            return result;
        }
        /// <summary>
        /// Получения списка всех стендов.
        /// </summary>
        /// <returns>List<Stands> список всех стендов из контекста</returns>
        public async Task<IEnumerable<Stands>> GetStandsAsync()
        {
            List<Stands> result = null;//new List<Stands>();
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "db":
                    using (var standsContext = new StandsContext())
                    {
                        result = await standsContext.Stands.ToListAsync();
                    }
                    break;
                case "Json":
                    string json = await GRADEXPO.HttpClient.Browser.GetAsync(string.Format("{0}{1}/{2}/{3}", Properties.Settings.Default.BaseUrlApi,
                                                                                                             Properties.Settings.Default.postfixGetExpo,
                                                                                                             "",
                                                                                                             Properties.Settings.Default.postfixGetStand));
                    StandsFromJson.RootObject rootObject = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<StandsFromJson.RootObject>(json));
                    if (rootObject.Stands == null)
                    {
                        throw new WebException(string.Format("Не удалось получить список всех стендов. Обратитесь к администратору"));
                    }
                    result = rootObject.Stands.Stand;
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
                    break;
            }
            return result;
        }
        /// <summary>
        /// Добавления нового стенда
        /// </summary>
        /// <param name="_stand">Стенд</param>
        /// <returns></returns>
        public async Task<Stands> AddStandAsync(Stands _stand)
        {
            Stands result = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "db":
                    using (var standsContext = new StandsContext())
                    {
                        result = standsContext.Stands.Add(_stand);
                        await standsContext.SaveChangesAsync();
                    }
                    break;
                case "Json":
                    string json = JsonConvert.SerializeObject(_stand, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore });
                    string res = await HttpClient.Browser.ByMethodAsync(string.Format("{0}{1}", Properties.Settings.Default.BaseUrlApi, Properties.Settings.Default.postfixGetStand), json, "POST");
                    result = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Stands>(res, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
                    break;
            }
            return result;
        }
        /// <summary>
        /// Удаление стенда
        /// </summary>
        /// <param name="_expoId">Id выставки</param>
        /// <param name="_standId">Id стенда</param>
        /// <returns></returns>
        public async Task DeleteStendsAsync(int _expoId, int _standId)
        {
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "db":
                    using (var standsContext = new StandsContext())
                    {
                        var stand = await standsContext.Stands.FirstOrDefaultAsync(f => f.expoId == _expoId && f.standId == _standId);

                        standsContext.Entry(stand).State = EntityState.Deleted;

                        await standsContext.SaveChangesAsync();
                    }
                    break;
                case "Json":
                    break;
            }
        }
        /// <summary>
        /// Удаление стенда
        /// </summary>
        /// <param name="_standId">id стенда</param>
        /// <returns></returns>
        public async Task DeleteStendsAsync(int _standId)
        {
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "db":
                    using (var standsContext = new StandsContext())
                    {
                        var stand = await standsContext.Stands.FirstOrDefaultAsync(f => f.standId == _standId);

                        standsContext.Entry(stand).State = EntityState.Deleted;

                        await standsContext.SaveChangesAsync();
                    }
                    break;
                case "Json":
                    break;
            }
        }
        /// <summary>
        /// Изменение стенда
        /// </summary>
        /// <param name="_stands">Стенд</param>
        /// <returns></returns>
        public async Task<Stands> UpdateStendAsync(Stands _stands)
        {
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "db":
                    using (var standsContext = new StandsContext())
                    {
                        standsContext.Entry(_stands).State = EntityState.Modified;

                        await standsContext.SaveChangesAsync();
                    }
                    break;
                case "Json":
                    GRADEXPO.Models.Stands stands = new GRADEXPO.Models.Stands()
                    {
                        expoId = _stands.expoId,
                        description = _stands.description,
                        hall = _stands.hall,
                        vendorId = _stands.vendorId
                    };
                    string json = JsonConvert.SerializeObject(stands, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore });
                    string res = await HttpClient.Browser.ByMethodAsync(string.Format("{0}{1}({2})", Properties.Settings.Default.BaseUrlApi, Properties.Settings.Default.postfixGetStand, _stands.standId), json, "PUT");
                    break;
            }
            return _stands;
        }

        public async Task<StandFromJson.Value> getStands(int _expoId)
        {
            StandFromJson.Value result = null;//new List<Stands>();
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    //http://zskpk02.z.loc:8280/odata/data/GREXPO/Stand?$expand=Expo,Vendor&$filter=expoId%20eq%202
                    string json = await GRADEXPO.HttpClient.Browser.GetAsync(string.Format("{0}{1}?$expand=Expo,Vendor&$filter=expoId%20eq%20{2}", Properties.Settings.Default.BaseUrlApi,
                                                                                                             Properties.Settings.Default.postfixGetStand,
                                                                                                             _expoId));
                    result = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<StandFromJson.Value>(json));
                    if (result.value == null)
                    {
                        throw new WebException(string.Format("Не удалось получить список всех стендов. Обратитесь к администратору"));
                    }
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
                    break;
            }
            return result;
        }
    }
}