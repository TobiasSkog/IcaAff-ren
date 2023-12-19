using IcaAffären.Models;

namespace IcaAffären.Application.Data;

internal class DatabaseManager
{
    private IcaAffärenContext Context { get; set; }
    public DatabaseManager()
    {
        Context = new();
    }

    public List<PersonalAvdelningar> GetAllAvdelningar()
    {
        /*
            -- 1 Hitta alla avdelningar en personal kan arbeta på
            -- Angelica = 4
            -- Daniel = 5
            -- Tobias = 6
            -- Zia = 7
            SELECT PersonalNamn AS Namn, AvdelningsNamn AS Avedelning
            FROM ((PersonalAvdelningar
            INNER JOIN Personal ON FK_PersonalId = PersonalId)
            INNER JOIN Avdelning ON FK_AvdelningId = AvdelningsId)
            WHERE PersonalId = 7
       */

        throw new NotImplementedException();
    }




    public List<Personal> GetAllPersonalOnAvdelning(string avdelning)
    {
        /*
        -- 2 Hitta all personal som arbetar på en avdelning
        -- Chark = 1
        -- Kassa = 2
        -- Kolonial = 3
        -- Administratör = 4
        -- AvdelningsChef = 5
        -- ButiksChef = 6
        SELECT AvdelningsNamn AS Avedelning, PersonalNamn AS Namn
        FROM ((PersonalAvdelningar
        INNER JOIN Avdelning ON FK_AvdelningId = AvdelningsId)
        INNER JOIN Personal ON FK_PersonalId = PersonalId)
    WHERE AvdelningsId = 2
    */
        throw new NotImplementedException();
    }


    public List<string> GetAllPersonalAndWorkLength()
    {
        /*
        -- 3 Visa hur länge all personal har arbetat
        SELECT PersonalNamn AS Namn,AnställningsDatum AS Anställd, DATEDIFF(YEAR, AnställningsDatum, GETDATE()) AS "Jobbat här i år:", RollNamn AS Roll, ButikNamn AS Butik
        FROM ((PersonalRoller
        INNER JOIN Personal ON FK_PersonalId = PersonalId)
        INNER JOIN Roll ON FK_RollId = RollId), Butik
    */
        throw new NotImplementedException();
    }

}
