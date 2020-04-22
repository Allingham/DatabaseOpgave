using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage
{
    public interface IManage<T>
    {
        /// <summary>
        /// henter alle objekter fra databasen
        /// </summary>
        /// <returns>Liste af objekter</returns>
        List<T> GetAll();

        /// <summary>
        /// Henter et specifikt objekt fra database 
        /// </summary>
        /// <param name="objNr">Udpeger det objekt der ønskes fra databasen</param>
        /// <returns>Det fundne objekt eller null hvis objektet ikke findes</returns>
        T GetFromId(int objNr);

        /// <summary>
        /// Indsætter et nyt objekt i databasen
        /// </summary>
        /// <param name="obj">Objektet der skal indsættes</param>
        /// <returns>Sand hvis der er gået godt ellers falsk</returns>
        bool Create(T obj);

        /// <summary>
        /// Opdaterer en objekt i databasen
        /// </summary>
        /// <param name="obj">De nye værdier til objektet</param>
        /// <param name="objNr">Nummer på det objekt der skal opdateres</param>
        /// <returns>Sand hvis der er gået godt ellers falsk</returns>
        bool Update(T obj, int objNr);

        /// <summary>
        /// Sletter et objekt fra databasen
        /// </summary>
        /// <param name="objNr">Nummer på det objekt der skal slettes</param>
        /// <returns>Det objekt der er slettet fra databasen, returnere null hvis objektet ikke findes</returns>
        T Delete(int objNr);

    }
}
