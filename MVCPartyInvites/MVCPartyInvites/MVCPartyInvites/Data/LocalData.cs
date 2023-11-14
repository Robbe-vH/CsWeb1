using MVCPartyInvites.Models;

namespace MVCPartyInvites.Data
{
    public static class LocalData
    {
        static LocalData()
        {
            AddDefault();
        }
        public static List<Gast> GastList = new List<Gast>();

        private static void AddDefault()
        {
            Gast gast=new Gast();                      
            gast.Email = "kristof.palmaers@pxl.be";
            gast.Naam = "Kristof";
            gast.Aanwezig = true;
            GastList.Add(gast);
        }
    }

}
