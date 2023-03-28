using System.Collections.Generic;

    public class InsClaim // POCO
{
    public int IDForClaim { get; set; }
    public string TypeClaim { get; set; }
    public decimal ClaimAmount { get; set; }
    public DateTime IncidentDate { get; set; }
    public DateTime ClaimDate { get; set; }
    public bool IsValid 
            { 
        get
        {
            if ((IncidentDate-ClaimDate).TotalDays>=30)
                {return false;}
           else
                {return true;}
        }
             }
      
    public InsClaim(){}

    public InsClaim(int idForClaim, string typeClaim, decimal claimAmount, DateTime incidentDate, DateTime claimDate) //
    {
        IDForClaim = idForClaim;
        TypeClaim = typeClaim;  //argument(s)
        ClaimAmount = claimAmount;
        IncidentDate = incidentDate;
        ClaimDate = claimDate;
    }
}



