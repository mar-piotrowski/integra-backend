using System.Net;
using Domain.Common.Models;

namespace Domain.Common.Errors; 

public static class JobPositionErrors {
   public static Error TitleExists => 
       new Error(HttpStatusCode.Conflict, "JobPosition.TitleExists","Stanowisko o podanej nazwie istnieje");

   public static Error TitleDoesNotExists =>
       new Error(HttpStatusCode.NotFound, "JobPosition.NotFount", "Podane stanowisko nie istnieje");
}