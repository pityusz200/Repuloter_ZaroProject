using repuloterProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace repuloterProject.Presenters
{
    public partial class UtasokPresenter
    {
        /// <summary>
        /// A view rétegen megadott nevet ellenőrzi
        /// </summary>
        /// <param name="Egy utas -t kell megadni"></param>
        /// <returns>Egy bool értéket ad vissza arról, hogy megfelelő-e a név</returns>
        public bool teljesNevEllenorzo(utas utas)
        {
            string[] nevek = utas.nev.Split(' ');

            Regex rx = new Regex("^(([A-ZÁÉÍÓÖŐÚÜŰ]+[A-Za-zÁÉÍÓÖŐÚÜŰáéíóöőúüű]+))$");

            return rx.IsMatch(nevek[0]) && rx.IsMatch(nevek[1]);
        }
        /// <summary>
        /// A view rétegen megadott felhasználó nevet ellenőrzi
        /// </summary>
        /// <param name="Egy utast -t kell megadni"></param>
        /// <returns>Egy bool értéket ad vissza arról, hogy megfelelő-e a felhasználó név</returns>
        public bool felhasznalonevErvenyes(utas utas)
        {
            Regex rx = new Regex("^.{4,}$");

            return rx.IsMatch(utas.felhasznalonev);
        }
        /// <summary>
        /// A view rétegen megadott emailt ellenőrzi
        /// </summary>
        /// <param name="Egy utast -t kell megadni"></param>
        /// <returns>Egy bool értéket ad vissza arról, hogy megfelelő-e a megadott email</returns>
        public bool emailErvenyes(utas utas)
        {
            return Regex.IsMatch(utas.email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }
        /// <summary>
        /// A view rétegen megadott jelszót ellenőrzi
        /// </summary>
        /// <param name="Egy utast -t kell megadni"></param>
        /// <returns>Egy bool értéket ad vissza arról, hogy megfelelő-e a jelszó</returns>
        public bool jelszoErvenyes(utas utas)
        {
            Regex rx = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$");

            return rx.IsMatch(utas.jelszo);
        }
        /// <summary>
        /// A view rétegen megadott mobil számot ellenőrzi
        /// </summary>
        /// <param name="Egy utast -t kell megadni"></param>
        /// <returns>Egy bool értéket ad vissza arról, hogy megfelelő-e a mobil szám</returns>
        public bool mobilErvenyes(utas utas)
        {
            Regex rx = new Regex(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$");

            return rx.IsMatch(utas.mobiltelefonszam.ToString());
        }
    }
}