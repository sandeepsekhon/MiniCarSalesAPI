using MiniCarsales.Data.Models;
using System;
using System.Collections.Generic;

namespace MiniCarSales.Data.InMemoryRepository
{
    public interface IInMemoryData<T> where T : Vehicle
    {
        /// <summary>
        /// Get all the elemets in thw storage.
        /// </summary>
        /// <returns>List</returns>
        List<T> GetAll();

        /// <summary>
        /// Add a new object to the storage. Used by POST method of the API.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Add(T t);

        /// <summary>
        /// Find an object by Id
        /// </summary>
        /// <param name="id">Unique identifier</param>
        /// <returns>true if successful</returns>
        T Find(Guid id);


        /// <summary>
        /// Edit the object at particular location. Used by PUT method of API.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Edit(Guid id, T t);
    }
}
