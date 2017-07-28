using Newtonsoft.Json;
using ServidorNotas.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorNotas.Models
{
    class Periodo
    {
        #region Datos
        public int Id { get; set; }
        public string Nombre { get; set; }
        #endregion
        #region Metodos Estaticos
        private static Periodo[] StringAObjetos(string datos)
        {
            var separacion1 = datos.Split(Separadores.Sep2);
            Periodo[] periodos = new Periodo[separacion1.Length];
            for (int i = 0; i < separacion1.Length - 1; i++)
            {
                periodos[i] = new Periodo();
                var separacion2 = separacion1[i].Split(Separadores.Sep1);
                periodos[i].Nombre = separacion2[0];
                periodos[i].Id = int.Parse(separacion2[1]);
            }
            return periodos;
        }
        public static Periodo[] GetPeriodos(string dni)
        {
            if (dni == "")
                return null;
            var strPeriodos = Servicios.ServicioUsuario.getPeriodos(dni);
            if (strPeriodos == "")
                return null;
            return StringAObjetos(strPeriodos);
        }
        #endregion
        #region Override
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        #endregion
    }
}

