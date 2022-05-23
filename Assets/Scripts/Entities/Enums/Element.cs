
namespace Assets.Scripts.Entities.Enums
{
    public enum Element : int
    {
        Water = 0,
        Fire = 1,
        Earth = 2,
        Thunder = 3,
        Mage = 4,
    }

    public static class ElementExtensions
    {
        static int[,] MatrizElementos = new int[5, 5]
        {
            { 3, 8, 5, 2, 6 },
            { 2, 3, 10, 7, 8 },
            { 6, 2, 3, 9, 7 },
            { 8, 5, 2, 3, 5 },
            { 6, 5, 7, 5, 0 },
        };

        public static float GetElementalDamage(Element? elementAttack, Element? elementDefense)
        {
            if (elementAttack == null)
                elementAttack = Element.Mage;

            if (elementDefense == null)
                elementDefense = Element.Mage;

            return MatrizElementos[(int) elementAttack, (int) elementDefense];
        }
    }

}