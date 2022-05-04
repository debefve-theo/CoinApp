namespace ClassLibrary
{
    public class ClassCalcul
    {
        #region METHODES TOTAL

        public static float CalculSoldeActuel()
        {
            float result = 0;

            // prendre chaque crypto possédée et calculer avec la valeur actuelle
            // peut etre une boucle avec la méthode CalculValeurTotalCrypto

            return result;
        }

        public static float CalculSolde24H()
        {
            float result = 0;

            // prendre chaque crypto possédée et calculer avec la valeur 24h

            return result;
        }

        public static float CalculPourcentage24H()
        {
            float result = ((CalculSoldeActuel() / CalculSolde24H() * 100) - 100);
            return result;
        }

        public static float CalculValeurTotalAchat()
        {
            float result = 0;

            // récupérer pour chaque transaction quantité * prix par token et les additionner

            return result;
        }

        public static float CalculGainPerteTotal()
        {
            float result = CalculSoldeActuel() - CalculValeurTotalAchat();
            return result;
        }

        #endregion

        #region METHODES CRYPTO

        public static float CalculValeurTotalCrypto(int id)
        {
            float result = 0;

            // prendre toute les transaction d'une crypto (id param) et recup quantity et la valeur actuel pour faire le total

            return result;
        }

        public static float CalculGainPerteCrypto(int id)
        {
            float result = 0;

            // prendre toute les transaction la méthode CalculPrixAvecFraisTransaction

            return result;
        }

        public static float CalculAllocationCrypto(int id)
        {
            float result = CalculSoldeActuel() / CalculValeurTotalCrypto(id);
            return result;
        }

        #endregion

        #region METHODES TRANSACTION

        public static float CalculPrixSansFraisTransaction(double id)
        {
            float result = 0;

            // recup la transaction sa quantite et son prix par token

            return result;
        }

        public static float CalculPrixAvecFraisTransaction(double id)
        {
            float result = 0;

            // recup la transaction sa quantite et son prix par token et les frais

            return result;
        }

        #endregion
    }
}

