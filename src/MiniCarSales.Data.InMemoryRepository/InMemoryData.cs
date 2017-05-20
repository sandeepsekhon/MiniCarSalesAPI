using Microsoft.Extensions.Logging;
using MiniCarsales.Data.Models;
using System;
using System.Collections.Generic;

namespace MiniCarSales.Data.InMemoryRepository
{
    /// <summary>
    /// Implementation of contract for In Memory storage.
    /// </summary>
    /// <typeparam name="T">Type of objects to store</typeparam>
    public class InMemoryData<T> : IInMemoryData<T> where T : Vehicle
    {
        //In memory storage of objects. The data type can be changed based upon the requirement.
        private static List<T> dataList = new List<T>();
        private readonly ILogger<T> _logger;
        public InMemoryData(ILogger<T> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get all the elemets in thw storage.
        /// </summary>
        /// <returns>List</returns>
        public List<T> GetAll()
        {
            return dataList;
        }

        /// <summary>
        /// Add a new object to the storage. Used by POST method of the API.
        /// </summary>
        /// <param name="t"></param>
        /// <returns>returns true if successful</returns>
        public T Add(T t)
        {
            if (t == null)
            {
                _logger.LogError("Null is not valid value for posting to Add method");
                return null;
            }
            if (t.Id == null || t.Id == Guid.Empty)
            {
                t.Id = Guid.NewGuid();
            }
            try
            {
                dataList.Add(t);
                _logger.LogInformation($"New vehicle added with Id {t?.Id} and type {t?.Type}");
            }
            catch(Exception ex)
            {
                _logger.LogCritical($"Error while adding a vehicle with type {t?.Type}", ex, t);
            }
            return t;
        }

        /// <summary>
        /// Find an object by Id
        /// </summary>
        /// <param name="id">Unique identifier</param>
        public T Find(Guid id)
        {
            return dataList.Find(t => t.Id == id);
        }

        /// <summary>
        /// Edit the object at particular location. Used by PUT method of API.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="t"></param>
        /// <returns>true if successful</returns>
        public bool Edit(Guid id, T t)
        {
            var index = dataList.FindIndex(d => d.Id == id);
            if(index==0)
            {
                _logger.LogError($"No item with Id {id} found for edit");
                return false;
            }
            dataList[index] = t;
            return true;
        }
    }
}
