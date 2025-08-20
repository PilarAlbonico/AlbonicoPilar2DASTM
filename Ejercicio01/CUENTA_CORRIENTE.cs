using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VISTA
{
  public class CUENTA_CORRIENTE: CUENTA
    {

        public decimal LIMITE_DESCUBIERTO { get; set; }
        public override void EXTRAER(decimal IMPORTE)
        {
            if (IMPORTE <= (SALDO + LIMITE_DESCUBIERTO))
            {
                SALDO -= IMPORTE;
            }
            else
            {
                throw new Exception("El importe a extraer es superior al permitido por el saldo actual de la cuenta");
            }
        }
    }
}
